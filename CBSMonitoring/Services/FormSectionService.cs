using AutoMapper;
using CBSMonitoring.Constants;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;
using static System.Collections.Specialized.BitVector32;

namespace CBSMonitoring.Services
{
    public class FormSectionService : IFormSectionService
    {
        private readonly IGenericRepository _fsRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        public FormSectionService(IGenericRepository fsRepository, IMapper mapper,
            IApplicationUserService applicationUserService)
        {
            _fsRepository = fsRepository;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
        }
        public async Task<Result<string>> AddFormSection(FormSectionRequest section)
        {
            FormSection FormSection = _mapper.Map<FormSection>(section);

            try
            {
                await _fsRepository.AddAsync(FormSection);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");

        }

        public async Task<Result<string>> DeleteFormSection(int id)
        {
            var section = await _fsRepository.GetByIdAsync<FormSection>(id);
            if (section == null)
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Неуспешно: форма с id={id} не найден!");

            await _fsRepository.DeleteAsync(section);

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<string>> EditFormSection(FormSectionRequest section, int id)
        {
            var formSection = await _fsRepository.GetByIdAsync<FormSection>(id);

            if (formSection == null)
                return await Result<string>.FailAsync(StatusCodes.Status404NotFound, $"Неуспешно: форма с id={id} не найден!");

            _mapper.Map(section, formSection);

            try
            {
                await _fsRepository.UpdateAsync(formSection);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, $"Успешно!");
        }

        public async Task<Result<IEnumerable<FormSectionResponse>>> GetAllFormSectionsByQuestionBlockId(int questionBlockId, LevelRequest request)
        {
            // Get current user's organization id or check if user is authorized for this organization info
            var orgIdResult = await _applicationUserService.GetOrganizationId(request.OrganizationId);

            if (!orgIdResult.Succeeded)
            {
                return await Result<IEnumerable<FormSectionResponse>>.FailAsync(
                    orgIdResult.StatusCode, orgIdResult.Messages);
            }

            request.OrganizationId = orgIdResult.Data;

            try
            {
                var sections = await _fsRepository.GetAllAsync<FormSection>(f => f.IsActive && f.QuestionBlockId == questionBlockId);

                // fetch all organization reports for the given period into dictionary
                var orgReportsLookup = (await _fsRepository.GetAllAsync<OrgMonitoring>(
                    o => o.OrganizationId == request.OrganizationId
                    && o.Year == request.Period.Year && o.QuarterIndex == request.Period.Quarter))
                    .ToDictionary(r => r.SectionNumber, r => r);

                // fetch form section items into dictionary
                var sectionItemsLookup = (await _fsRepository.GetAllAsync<FormItem>(
                    e => e.IsActive, query => query.Include(e => e.FormSection)))
                    .GroupBy(e => e.FormSection.SectionNumber)
                    .ToDictionary(r => r.Key, r => r.Count());

                // Build the response list
                var fsResponseList = sections.Select(section =>
                {
                    bool isFilled = orgReportsLookup.TryGetValue(section.SectionNumber, out var report);
                    int numberOfItems = sectionItemsLookup.TryGetValue(section.SectionNumber, out var itemsCount) ? itemsCount : 0;
                    return _mapper.Map<FormSectionResponse>(section, opt => opt.AfterMap((src, dest) =>
                    {
                        dest.IsFilled = isFilled;
                        dest.NumberOfItems = numberOfItems;
                    }));
                }).OrderBy(e => e.SectionId).ToList();

                return await Result<IEnumerable<FormSectionResponse>>.SuccessAsync(StatusCodes.Status200OK, fsResponseList);
            }

            catch(Exception ex)
            {
                return await Result<IEnumerable<FormSectionResponse>>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        public async Task<Result<FormSectionResponse>> GetFormSectionById(int id)
        {
            var section = await _fsRepository.GetByIdAsync<FormSection>(id);
            if (section == null)
                return await Result<FormSectionResponse>.FailAsync(StatusCodes.Status404NotFound, $"Неуспешно: форма с id={id} не найден!");

            return await Result<FormSectionResponse>.SuccessAsync(StatusCodes.Status200OK, _mapper.Map<FormSectionResponse>(section));
        }
        
    }
}
