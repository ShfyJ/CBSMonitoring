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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using CBSMonitoring.DTOs;
using ERPBlazor.Shared.Wrappers;
using CBSMonitoring.Hubs;
using System.Security.Claims;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var validationErrors = context.ModelState
            .SelectMany(kvp => kvp.Value.Errors.Select(error => new ValidationError(kvp.Key, error.ErrorMessage)))
            .ToList(); 
        
        return new BadRequestObjectResult(new Result<string?>(StatusCodes.Status400BadRequest, null, validationErrors,
            false, new List<string> { "Проверка: Один или несколько неверных входных данных!" }));
    };
}); 

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IPasswordService, PasswordService>();

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
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

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
builder.Services.AddScoped<IMessageService, MessageService>();
//builder.Services.AddScoped<IMonitoringIndicatorService, MonitoringIndicatorService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<EmailService>();

builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<AuthorizeFirstLoginAttribute>();
builder.Services.AddSignalR();
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

// Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(hostingContext.Configuration["Serilog:LogFile"] ?? "logs/ib.ung.uz-.txt", rollingInterval: RollingInterval.Day));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JWT");
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"], //jwtSettings.GetSection("ValidIssuers").Get<string[]>(),
            ValidAudience = builder.Configuration["JWT:ValidAudience"], //jwtSettings.GetSection("ValidAudiences").Get<string[]>(),
            NameClaimType = ClaimTypes.NameIdentifier,
            RoleClaimType = ClaimTypes.Role,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:AccessKey"]!)
            ),
        };

        // Configure WebSocket support
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // If the request is for a websocket, the token comes from the query string.
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    path.StartsWithSegments("/chathub"))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };


    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequirePasswordChange", policy =>
        policy.RequireClaim("IsFirstLogin", "False"));
});

builder.Services.AddHostedService<BlacklistCleanupService>();

builder.Services
    .AddCors(opt =>
    {
        opt.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.WithOrigins( "http://192.168.89.163", "https://ib.ung.uz", "http://192.168.88.118:3000", "http://localhost:3000",
                "http://192.168.95.93:443","http://192.168.89.93", "http://localhost:4990", "http://ibtest.ung.uz", "https://ibtest.ung.uz")
            //builder.AllowAnyOrigin()
            .WithMethods("GET","POST")
            .AllowAnyHeader()
            .AllowAnyMethod()          
            .AllowCredentials()
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

app.Use(async (context, next) =>
{
    Console.WriteLine(context.Request.Method);
    Console.WriteLine(context.Request.Headers);
    await next.Invoke();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseSwagger();
//app.UseSwaggerUI();


//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseMiddleware<TokenBlacklistMiddleware>(); // Check if the token is blacklisted.
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chathub").RequireCors("CorsPolicy");

app.Run();
