using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace CBSMonitoring.Services
{
    public class FormSectionService : IFormSectionService
    {
        private readonly IGenericRepository<FormSection> _fsRepository;
        public FormSectionService(IGenericRepository<FormSection> fsRepository)
        {
            _fsRepository = fsRepository;
        }
        public async Task<Result<string>> AddFormSection(FormSectionInDTO section)
        {
            FormSection FormSection = new()
            {
                IsActive = section.IsActive,
                SectionNumber = section.SectionNumber,
                SectionName = section.SectionName,
                QuestionBlockId = section.QuestionBlockId,
            };

            try
            {
                await _fsRepository.Add(FormSection);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Success");
            
        }

        public async Task<Result<string>> DeleteFormSection(int id)
        {
            var section = await _fsRepository.GetById(id);
            if (section == null)
                return await Result<string>.FailAsync($"form with id={id} not found");

            await _fsRepository.Delete(section);

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<string>> EditFormSection(FormSectionInDTO section, int id)
        {
            var formSection = await _fsRepository.GetById(id);

            if (formSection == null)
                return await Result<string>.FailAsync($"Form with id={id} not found");

            formSection.SectionNumber = section.SectionNumber;
            formSection.SectionName = section.SectionName;
            formSection.QuestionBlockId = section.QuestionBlockId;
            formSection.IsActive = section.IsActive;

            try
            {
                await _fsRepository.Update(formSection);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<IEnumerable<FormSectionOutDTO>>> GetAllFormSectionsByQuestionBlockId(int questionBlockId)
        {
            var sections = await _fsRepository.GetAll();
            sections = sections.Where(s => s.QuestionBlockId == questionBlockId);
            List<FormSectionOutDTO> formSectionOutDTOs = new();
            foreach (var section in sections)
            {
                FormSectionOutDTO formSectionOutDTO = new()
                {
                    SectionId = section.SectionId,
                    SectionName = section.SectionName,
                    SectionNumber = section.SectionNumber,
                    QuestionBlockId = questionBlockId
                };

                formSectionOutDTOs.Add(formSectionOutDTO);
            }
            return await Result<IEnumerable<FormSectionOutDTO>>.SuccessAsync(formSectionOutDTOs);
        }

        public async Task<Result<FormSectionOutDTO>> GetFormSectionById(int id)
        {
            var section = await _fsRepository.GetById(id);
            if (section == null)
                return await Result<FormSectionOutDTO>.FailAsync($"Form with id={id} not found!");

            FormSectionOutDTO formSectionOutDTO = new()
            {
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                SectionNumber = section.SectionNumber,
                IsActive = section.IsActive,
                QuestionBlockId = section.QuestionBlockId
            };

            return await Result<FormSectionOutDTO>.SuccessAsync(formSectionOutDTO);
        }
    }
}
