using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IFormItemService
    {
        Task<Result<string>> AddFormItem(FormItemRequest item);
        Task<Result<string>> EditFormItem(FormItemRequest item, int id);
        Task<Result<string>> DeleteFormItem(int id);
        Task<Result<FormItemResponse>> GetFormItem(int id);
        Task<Result<IEnumerable<FormItemResponse>>> GetFormItemsByFormSectionId(int formSectionId);
    }
}
