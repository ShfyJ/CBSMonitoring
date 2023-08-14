using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace CBSMonitoring.Services
{
    public class FormService : IFormService
    {
        private readonly AppDbContext _context;
        public FormService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<string>> AddForm(MonitoringFormDTO form)
        {
            MonitoringForm monitoringForm = new()
            {
                IsActive = form.IsActive,
                FormNumber = form.FormNumber,
            };

            try
            {
                await _context.AddAsync(monitoringForm);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"Success");
            
        }

        public async Task<Result<string>> DeleteForm(int id)
        {
            var form = await _context.MonitoringForms.FindAsync(id);
            if (form == null)
                return await Result<string>.FailAsync($"form with id={id} not found");

            _context.Remove(form);
            await _context.SaveChangesAsync();

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<string>> EditForm(MonitoringForm form)
        {
            var monitoringForm = await _context.MonitoringForms.FindAsync(form.FormId);

            if (monitoringForm == null)
                return await Result<string>.FailAsync($"Form with id={form.FormId} not found");

            try
            {
                _context.Update(form);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Failed:{ex.Message}");
            }

            return await Result<string>.SuccessAsync($"success");
        }

        public async Task<Result<IEnumerable<MonitoringForm>>> GetAllForm()
        {
            var forms = await _context.MonitoringForms.ToListAsync();
            return await Result<IEnumerable<MonitoringForm>>.SuccessAsync(forms);
        }

        public async Task<Result<MonitoringForm>> GetForm(int id)
        {
            var form = await _context.MonitoringForms.FindAsync(id);
            if (form == null)
                return await Result<MonitoringForm>.FailAsync($"Form with id={id} not found!");
            return await Result<MonitoringForm>.SuccessAsync(form);
        }
    }
}
