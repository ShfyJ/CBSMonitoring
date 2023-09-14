﻿using AutoMapper;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public class FormSectionService : IFormSectionService
    {
        private readonly IGenericRepository _fsRepository;
        private readonly IMapper _mapper;
        public FormSectionService(IGenericRepository fsRepository, IMapper mapper)
        {
            _fsRepository = fsRepository;
            _mapper = mapper;
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
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Success");

        }

        public async Task<Result<string>> DeleteFormSection(int id)
        {
            var section = await _fsRepository.GetByIdAsync<FormSection>(id);
            if (section == null)
                return await Result<string>.FailAsync($"form with id={id} not found");

            await _fsRepository.DeleteAsync(section);

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<string>> EditFormSection(FormSectionRequest section, int id)
        {
            var formSection = await _fsRepository.GetByIdAsync<FormSection>(id);

            if (formSection == null)
                return await Result<string>.FailAsync($"Form with id={id} not found");

            _mapper.Map(section, formSection);

            try
            {
                await _fsRepository.UpdateAsync(formSection);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<IEnumerable<FormSectionResponse>>> GetAllFormSectionsByQuestionBlockId(int questionBlockId, LevelRequest request)
        {
            var sections = await _fsRepository.GetAllByParameterAsync<FormSection>(f => f.IsActive && f.QuestionBlockId == questionBlockId);
            
            List<FormSectionResponse> fsResponseList = new();
            
            foreach (var section in sections)
            {
                bool isFilled = false;

                if (await _fsRepository.GetFirstByParameterAsync<OrgMonitoring>(o => o.SectionNumber == section.SectionNumber
                                                && o.OrganizationId == request.OrganizationId && o.Year == request.Year
                                                && o.QuarterIndex == request.Quarter) is not null)
                {
                    isFilled = true;
                }

                FormSectionResponse fsResponse = _mapper.Map<FormSectionResponse>(section, opt => opt.AfterMap((src, dest) =>
                {
                    dest.IsFilled = isFilled;
                }));

                fsResponseList.Add(fsResponse);

            }

            return await Result<IEnumerable<FormSectionResponse>>.SuccessAsync(fsResponseList);
        }

        public async Task<Result<FormSectionResponse>> GetFormSectionById(int id)
        {
            var section = await _fsRepository.GetByIdAsync<FormSection>(id);
            if (section == null)
                return await Result<FormSectionResponse>.FailAsync($"Form with id={id} not found!");

            return await Result<FormSectionResponse>.SuccessAsync(_mapper.Map<FormSectionResponse>(section));
        }
    }
}
