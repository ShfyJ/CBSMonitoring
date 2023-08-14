using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using System.IO;

namespace CBSMonitoring.Services
{
    public interface IFileWorkRoom
    {
        Task<Result<string>> SaveFile(FileItem file, int monitoringId);
        Task<Result<FileToStream>> GetFileAsStream(int id);
    }
}
