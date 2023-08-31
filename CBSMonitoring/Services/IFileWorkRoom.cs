using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;

namespace CBSMonitoring.Services
{
    public interface IFileWorkRoom
    {
        Task<Result<int>> SaveFile(FileItem file, int monitoringId);
        Task<Result<FileToStream>> GetFileAsStream(int id);
    }
}
