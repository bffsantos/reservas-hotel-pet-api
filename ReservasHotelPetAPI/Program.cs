using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs.Mappings;
using ReservasHotelPetAPI.Extensions;
using ReservasHotelPetAPI.Filters;
using ReservasHotelPetAPI.Logging;
using ReservasHotelPetAPI.Models;
using ReservasHotelPetAPI.Repositories;
using ReservasHotelPetAPI.Repositories.Interfaces;
using ReservasHotelPetAPI.Services;
using ReservasHotelPetAPI.Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddControllers()
        .AddJsonOptions(options => 
            options.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);*/
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExcpetionFilter));
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApiReservasHotelPetContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiReservasHotelPetContext>(optionss => 
                                    optionss.UseMySql(mySqlConnection, 
                                    ServerVersion.AutoDetect (mySqlConnection)));

var secretKey = builder.Configuration["JWT:Secretkey"] ?? throw new ArgumentException("Invalid secret key!!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JET:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

builder.Services.AddAutoMapper(cfg => { }, typeof(ModelsToDTOMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
