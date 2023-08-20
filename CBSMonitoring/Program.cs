using CBSMonitoring.Data;
using CBSMonitoring.Models;
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

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IQuestionBlockService, QuestionBlockService>();
builder.Services.AddScoped<IFormItemService, FormItemService>();
builder.Services.AddScoped<IFileWorkRoom, FileWorkRoom>();


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
