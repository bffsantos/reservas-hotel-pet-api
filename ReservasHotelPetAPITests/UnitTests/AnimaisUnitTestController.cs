using AutoMapper;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using ReservasHotelPetAPI.Context;
using ReservasHotelPetAPI.DTOs.Mappings;
using ReservasHotelPetAPI.Repositories;
using ReservasHotelPetAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasHotelPetAPITests.UnitTests
{
    public class AnimaisUnitTestController
    {
        public IUnitOfWork repository;
        public IMapper mapper;
        public static DbContextOptions<ApiReservasHotelPetContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost;DataBase=reservashotelpetdb;Uid=root;Pwd=admin123";

        static AnimaisUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApiReservasHotelPetContext>()
               .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
               .Options;
        }

        public AnimaisUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelsToDTOMappingProfile());
                
            },
            NullLoggerFactory.Instance);

            mapper = config.CreateMapper();

            var context = new ApiReservasHotelPetContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }
    }
}
