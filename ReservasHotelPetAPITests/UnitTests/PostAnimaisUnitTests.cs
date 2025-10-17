using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ReservasHotelPetAPI.Controllers;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPITests.UnitTests;

namespace ApiCatalogoxUnitTests.UnitTests
{
    public class PostAnimaisUnitTests : IClassFixture<AnimaisUnitTestController>
    {
        private readonly AnimaisController _controller;

        public PostAnimaisUnitTests(AnimaisUnitTestController controller)
        {
            _controller = new AnimaisController(controller.repository, controller.mapper);
        }

        //metodos de testes para POST
        [Fact]
        public async Task PostAnimal_Return_CreatedStatusCode()
        {
            // Arrange  
            var novoProdutoDto = new AnimalDTO
            {
                Nome = "Novo Animal",
                Idade = 2,
                Raca = "Raca do animal",
                Sexo = 'M',
                Tipo = "Gato",
                TutorId = 1
            };

            // Act  
            var data = await _controller.Post(novoProdutoDto);

            // Assert  
            var createdResult = data.Result.Should().BeOfType<CreatedAtRouteResult>();
            createdResult.Subject.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task PostAnimal_Return_BadRequest()
        {
            AnimalDTO prod = null;

            // Act              
            var data = await _controller.Post(prod);

            // Assert  
            var badRequestResult = data.Result.Should().BeOfType<BadRequestResult>();
            badRequestResult.Subject.StatusCode.Should().Be(400);
        }
    }
}
