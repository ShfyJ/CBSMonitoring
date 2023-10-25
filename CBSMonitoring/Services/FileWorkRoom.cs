using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace CBSMonitoring.Models
{
    public class FileWorkRoom : IFileWorkRoom
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public FileWorkRoom(IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<Result<FileToStream>> GetFileAsStream(int id)
        {

            var file = await _context.FileModels.Where(x => x.FileId == id).FirstOrDefaultAsync();

            if (file is null)
            {
                return await Result<FileToStream>.FailAsync($"File entity is not found in the database");
            }

            if (File.Exists(file.FilePath))
            {

                try
                {
                    byte[] fileBytes = await File.ReadAllBytesAsync(file.FilePath);
                    var memory = new MemoryStream(fileBytes);

                    return await Result<FileToStream>.SuccessAsync(new FileToStream(memory, file.ContentType, file.Name + file.Extension));
                }

                catch(Exception ex)
                {
                    return await Result<FileToStream>.FailAsync(ex.Message);
                }

                
            }

            else
            {
                return await Result<FileToStream>.FailAsync($"File is not found in the file system");
            }
        }

        public async Task<Result<FileModel>> SaveFile(FileItem file, OrgMonitoringDto dto)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            var basePath = Path.Combine(wwwRootPath + "/files/" + dto.OrganizationName, dto.Year.ToString(), dto.QuarterIndex.ToString(), dto.SectionNumber);
            var date = DateTime.Now;
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(file.File.FileName) + "(" + date.ToFileTimeUtc().ToString() + ")";
            var extension = Path.GetExtension(file.File.FileName);
            var filePath = Path.Combine(basePath, fileName + extension);
            string temp = fileName;

            for (int i = 1; ; i++)
            {
                if (System.IO.File.Exists(filePath))
                {
                    temp = "";
                    temp += fileName + "(" + i.ToString() + ")";
                    filePath = Path.Combine(basePath, temp + extension);
                    continue;
                }
                break;
            }
            var systemPath = Path.Combine("/files/" + dto.OrganizationName, dto.Year.ToString(), dto.QuarterIndex.ToString(), dto.SectionNumber, temp + extension);

            FileModel docFile;

            try
            {
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.File.CopyToAsync(fileStream);
                }

                docFile = new()
                {
                    FilePath = filePath,
                    SystemPath = systemPath,
                    BasePath = basePath,
                    Name = temp,
                    Extension = extension,
                    ContentType = file.File.ContentType,
                    Description = file.Description,
                    DocNumber = file.DocNumber,
                    DocDate = file.DocDate
                };

                //await _context.FileModels.AddAsync(docfile);
                //await _context.SaveChangesAsync();

                //fileModelId = docfile.FileId;

            }

            catch (Exception ex)
            {
                return await Result<FileModel>.FailAsync($"Failed - {ex.Message}");
            }

            //if (fileType.Equals(EDocFileTypeConst.MainDocument))
            //    QRCodeGenerate("dsfasfsd", filePath);

            return await Result<FileModel>.SuccessAsync(docFile);
        }
    }
}
