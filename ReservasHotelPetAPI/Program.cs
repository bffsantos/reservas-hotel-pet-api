using Microsoft.EntityFrameworkCore;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.Extensions;
using ReservasHotelPetAPI.Filters;
using ReservasHotelPetAPI.Logging;
using ReservasHotelPetAPI.Repositories;
using ReservasHotelPetAPI.Repositories.Interfaces;
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

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiReservasHotelPetContext>(optionss => 
                                    optionss.UseMySql(mySqlConnection, 
                                    ServerVersion.AutoDetect (mySqlConnection)));

builder.Services.AddScoped<ApiLoggingFilter>();

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

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
