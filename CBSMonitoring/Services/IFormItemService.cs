using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Services
{
    public interface IFormItemService
    {
        Task<Result<string>> AddFormItem(FormItemRequest item);
        Task<Result<string>> EditFormItem(FormItemRequest item, int id);
        Task<Result<string>> DeleteFormItem (int id);
        Task<Result<FormItem>> GetFormItem (int id);
        Task<Result<IEnumerable<FormItem>>> GetFormItemsByFormSectionId(int formSectionId);
    }
}
