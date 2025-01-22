using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IFileWorkRoom
    {
        Task<Result<FileModel>> SaveFile(FileItem file, OrgMonitoringDto dto);
        Task<Result<FileToStream>> GetFileAsStream(int id);
        Task<Result<string>> AddCatalogs(CatalogFile catalog);
        Task<Result<List<CatalogResponse>>> GetCatalogs();
    }
}
