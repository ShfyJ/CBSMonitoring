using AutoMapper;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

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

            if (item == null)
            {
                return await Result<string>.FailAsync($"item with id={id} not found!");
            }

            try
            {
                await _genericRepository.DeleteAsync(item);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");

        }


        public async Task<Result<string>> EditFormItem(FormItemRequest item, int id)
        {
            var itemToUpdate = await _genericRepository.GetByIdAsync<FormItem>(id);

            if (itemToUpdate == null)
            {
                return await Result<string>.FailAsync($"item with id={id} not found");
            }

            _mapper.Map(item, itemToUpdate);

            try
            {
                await _genericRepository.UpdateAsync(itemToUpdate);
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<FormItemResponse>> GetFormItem(int id)
        {
            var item = await _genericRepository.GetByIdAsync<FormItem>(id);

            if (item == null)
                return await Result<FormItemResponse>.FailAsync($"item with id={id} not found");

            return await Result<FormItemResponse>.SuccessAsync(_mapper.Map<FormItemResponse>(item));
        }

        public async Task<Result<IEnumerable<FormItemResponse>>> GetFormItemsByFormSectionId(int formSectionId)
        {

            var items = await _genericRepository.GetAllAsync<FormItem>(null,query => query.Include(e => e.FormItemType));
            items = items.Where(i => i.FormSectionId == formSectionId);

            List<FormItemResponse> result = new();

            try
            {
                foreach (var item in items)
                {
                    var rItem = _mapper.Map<FormItemResponse>(item);
                    result.Add(rItem);
                }
            }

            catch (Exception ex)
            {
                return await Result<IEnumerable<FormItemResponse>>.FailAsync(ex.Message);
            }


            return await Result<IEnumerable<FormItemResponse>>.SuccessAsync(result);
        }
    }
}
