using AutoMapper;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using ERPBlazor.Shared.Wrappers;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Models
{
    public class FileWorkRoom : IFileWorkRoom
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FileWorkRoom(IWebHostEnvironment webHostEnvironment, AppDbContext context, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<string>> AddCatalogs(CatalogFile catalog)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            var basePath = Path.Combine(wwwRootPath + "/files/" + "catalogs");
            var date = DateTime.Now;
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(catalog.File.FileName);
            var extension = Path.GetExtension(catalog.File.FileName);
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
            var systemPath = Path.Combine("/files/" + "catalogs", temp + extension);

            FileModel catalogFile;

            try
            {
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await catalog.File.CopyToAsync(fileStream);
                }

                catalogFile = new()
                {
                    FilePath = filePath,
                    SystemPath = systemPath,
                    BasePath = basePath,
                    Name = temp,
                    Extension = extension,
                    ContentType = catalog.File.ContentType,
                    Description = catalog.Description,
                    IsCatalog = true
                };

                await _context.FileModels.AddAsync(catalogFile);
                await _context.SaveChangesAsync();

            }

            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, "Успешно!");
        }

        public async Task<Result<List<CatalogResponse>>> GetCatalogs()
        {
            var catalogs = await _context.FileModels
                .Where(f => f.IsCatalog)
                .Select(f => new CatalogResponse(f.FileId, f.Name, f.Description))
                .ToListAsync();

            return await Result<List<CatalogResponse>>.SuccessAsync(catalogs);
        }

        public async Task<Result<FileToStream>> GetFileAsStream(int id)
        {

            var file = await _context.FileModels.Where(x => x.FileId == id).FirstOrDefaultAsync();

            if (file is null)
            {
                return await Result<FileToStream>.FailAsync(StatusCodes.Status404NotFound, $"Объект файла не найден в базе данных");
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
                    return await Result<FileToStream>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
                }
                
            }

            else
            {
                return await Result<FileToStream>.FailAsync(StatusCodes.Status404NotFound, $"Файл не найден в файловой системе");
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
                return await Result<FileModel>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            //if (fileType.Equals(EDocFileTypeConst.MainDocument))
            //    QRCodeGenerate("dsfasfsd", filePath);

            return await Result<FileModel>.SuccessAsync(StatusCodes.Status200OK, docFile);
        }
    }
}
