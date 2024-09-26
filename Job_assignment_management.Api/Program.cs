using Job_assignment_management.Api.Hubs;
using Job_assignment_management.Application.Services;
using Job_assignment_management.Domain.Interfaces;
using Job_assignment_management.Infrastructure.Data;
using Job_assignment_management.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RefreshToken.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection") ?? throw new InvalidOperationException("Connectionstring not found."));
});
builder.Services.AddCors(option =>
{
    option.AddPolicy("ApiPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTRefreshTokens", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Scheme="oauth2",
                Name="Bearer",
                In= ParameterLocation.Header,

            },
            new string[]{}
        }
    });
});
builder.Services.AddTransient<IJwtService,JwtService>();
builder.Services.AddTransient<INhomQuyenRepository, NhomQuyenRepository>();
builder.Services.AddTransient<IChucNangRepository, ChucNangRepository>();
builder.Services.AddTransient<IChiTietQuyenReposity, ChiTietQuyenRepository>();
builder.Services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddTransient<INhanVienRepository, NhanVienRepository>();
builder.Services.AddTransient<IPhongBanRepository, PhongBanRepository>();
builder.Services.AddTransient<IDuAnRepository, DuAnRepository>();
builder.Services.AddTransient<IPhanDuAnRepository,PhanDuAnRepository>();
builder.Services.AddTransient<ICongViecRepository, CongViecRepository>();
var jwtKey = builder.Configuration.GetValue<string>("Jwt:key");
var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
TokenValidationParameters TokenValidation = new TokenValidationParameters
{
    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
    ValidateLifetime = true,
    ValidateAudience = false,
    ValidateIssuer = false,
    ClockSkew = TimeSpan.Zero
};
builder.Services.AddSingleton(TokenValidation);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = TokenValidation;
    options.Events = new JwtBearerEvents();
    options.Events.OnTokenValidated = async (context) =>
    {
        var ipAddress = context?.Request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        var jwtService = context?.Request.HttpContext.RequestServices.GetService<IJwtService>();
        var jwtToken = context?.SecurityToken as JwtSecurityToken;
        if (!await jwtService?.IsTokenValid(jwtToken?.RawData,ipAddress))
        {
            context?.Fail("Invalid Token Details");
        }
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapHub<myHub>("/hub");
app.UseAuthorization();

app.MapControllers();

app.Run();
