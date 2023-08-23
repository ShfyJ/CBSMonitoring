using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFormItemService
    {
        Task<Result<string>> AddFormItem(FormItemDTO item);
        Task<Result<string>> EditFormItem(FormItemDTO item, int id);
        Task<Result<string>> DeleteFormItem (int id);
        Task<Result<FormItem>> GetFormItem (int id);
        Task<Result<IEnumerable<FormItem>>> GetFormItemsByFormSectionId(int formSectionId);
    }
}
