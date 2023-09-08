using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFileWorkRoom
    {
        Task<Result<FileModel>> SaveFile(FileItem file, OrgMonitoringDto dto);
        Task<Result<FileToStream>> GetFileAsStream(int id);
    }
}
