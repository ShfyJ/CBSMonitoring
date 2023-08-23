using CBSMonitoring.Data;
using CBSMonitoring.Models;
using CBSMonitoring.Models.Forms;
using CBSMonitoring.Services;
using CBSMonitoring.Services.FormReports;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.EnableDetailedErrors();
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IQuestionBlockService, QuestionBlockService>();
builder.Services.AddScoped<IFormItemService, FormItemService>();
builder.Services.AddScoped<IFormSectionService, FormSectionService>();
builder.Services.AddScoped<IFileWorkRoom, FileWorkRoom>();
builder.Services.AddScoped<IMonitoringFactory, FormReportService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
