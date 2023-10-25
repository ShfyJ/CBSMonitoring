using CBSMonitoring.Data;
using CBSMonitoring.Models;
using CBSMonitoring.Services;
using CBSMonitoring.Services.FormReports;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using CBSMonitoring.Webframework;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Extensions;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Integrations;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.EnableDetailedErrors();
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//builder.Services.Configure<JsonConfig>(builder.Configuration.GetSection("JsonOptions"));
//builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<JsonConfig>>().Value.JsonSerializerSettings);

builder.Services.AddJsonMultipartFormDataSupport(JsonSerializerChoice.Newtonsoft);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IQuestionBlockService, QuestionBlockService>();
builder.Services.AddScoped<IFormItemService, FormItemService>();
builder.Services.AddScoped<IFormSectionService, FormSectionService>();
builder.Services.AddScoped<IFileWorkRoom, FileWorkRoom>();
builder.Services.AddScoped<IMonitoringFactory, FormReportService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IRankingService, RankingService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
//builder.Services.AddScoped<IMonitoringIndicatorService, MonitoringIndicatorService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)
            ),
        };
    });

builder.Services
    .AddCors(opt =>
    {
        opt.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Disposition");
        });
    });

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
