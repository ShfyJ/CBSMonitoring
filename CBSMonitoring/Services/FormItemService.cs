using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Services
{
    public class FormItemService : IFormItemService
    {
        private readonly AppDbContext _context;
        public FormItemService(AppDbContext context)
        {
           _context = context;
        }
        public async Task<Result<string>> AddFormItem(FormItemDTO item)
        {
            FormItem formItem = new()
            {
                IsActive = item.IsActive,
                Order = item.Order,
               
                SelectOptions = item.SelectOptions,
                ItemLabel = item.ItemLabel,
                ItemName = item.ItemName,
                ItemType = item.ItemType,
                FormSectionId = item.FormId
            };

            try
            {
                await _context.AddAsync(formItem);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed: {ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
            
        }

        public async Task<Result<string>> DeleteFormItem(int id)
        {
            var item = await _context.FormItems.FindAsync(id);
            
            if(item == null)
            {
                return await Result<string>.FailAsync($"item with id={id} not found!");
            }

            try
            {
                _context.FormItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
            
        }
                

        public async Task<Result<string>> EditFormItem(FormItemDTO item)
        {
            var itemToUpdate = await _context.FormItems.FindAsync(item.ItemId);

            if(itemToUpdate == null )
            {
                return await Result<string>.FailAsync($"item with id={item.ItemId} not found");
            }

            itemToUpdate.IsActive = item.IsActive;
            itemToUpdate.Order = item.Order;            
            itemToUpdate.SelectOptions = item.SelectOptions;
            itemToUpdate.ItemLabel = item.ItemLabel;
            itemToUpdate.ItemName = item.ItemName;
            itemToUpdate.ItemType = item.ItemType;
            itemToUpdate.FormSectionId = item.FormId;

            _context.Update(itemToUpdate);
            await _context.SaveChangesAsync();

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<FormItem>> GetFormItem(int id)
        {
            var item = await _context.FormItems.FindAsync(id);

            if (item == null)
                return await Result<FormItem>.FailAsync($"item with id={id} not found");

            return await Result<FormItem>.SuccessAsync(item);
        }

        public async Task<Result<IEnumerable<FormItem>>> GetFormItemsByFormId(int formId)
        {
            throw new NotImplementedException();
            //var items = await _context.FormItems.Where(i => i.FormId == formId).ToListAsync();

            //return await Result<IEnumerable<FormItem>>.SuccessAsync(items);
        }
    }
}
