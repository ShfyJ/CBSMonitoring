using AutoMapper;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Services
{
    public class FormItemService : IFormItemService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        public FormItemService(IGenericRepository genericRepository, IMapper mapper)
        {
           _genericRepository = genericRepository;
           _mapper = mapper;
        }
        public async Task<Result<string>> AddFormItem(FormItemRequest item)
        {
            FormItem formItem = _mapper.Map<FormItem>(item);

            try
            {
                await _genericRepository.AddAsync(formItem);
            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
            
        }

        public async Task<Result<string>> DeleteFormItem(int id)
        {
            var item = await _genericRepository.GetByIdAsync<FormItem>(id);
            
            if(item == null)
            {
                return await Result<string>.FailAsync($"item with id={id} not found!");
            }

            try
            {
                await _genericRepository.DeleteAsync(item);
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
            
        }
                

        public async Task<Result<string>> EditFormItem(FormItemRequest item, int id)
        {
            var itemToUpdate = await _genericRepository.GetByIdAsync<FormItem>(id);

            if(itemToUpdate == null )
            {
                return await Result<string>.FailAsync($"item with id={id} not found");
            }

            _mapper.Map(item, itemToUpdate);

            try
            {
                await _genericRepository.UpdateAsync(itemToUpdate);
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<FormItem>> GetFormItem(int id)
        {
            var item = await _genericRepository.GetByIdAsync<FormItem>(id);

            if (item == null)
                return await Result<FormItem>.FailAsync($"item with id={id} not found");

            return await Result<FormItem>.SuccessAsync(item);
        }

        public async Task<Result<IEnumerable<FormItem>>> GetFormItemsByFormSectionId(int formSectionId)
        {
            
            var items = await _genericRepository.GetAllAsync<FormItem>();
            items = items.Where(i => i.FormSectionId == formSectionId);

            return await Result<IEnumerable<FormItem>>.SuccessAsync(items);
        }
    }
}
