using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ReservasHotelPetAPI.Controllers;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPITests.UnitTests;

namespace ApiCatalogoxUnitTests.UnitTests;

public class DeleteAnimaisUnitTests : IClassFixture<AnimaisUnitTestController>
{
    private readonly AnimaisController _controller;

    public DeleteAnimaisUnitTests(AnimaisUnitTestController controller)
    {
        _controller = new AnimaisController(controller.repository, controller.mapper);
    }

    //testes para o Delete
    [Fact]
    public async Task DeleteAnimalById_Return_OkResult()
    {
        var prodId = 3;

        // Act
        var result = await _controller.Delete(prodId) as ActionResult<AnimalDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<OkObjectResult>(); // Verifica se o resultado é OkResult
    }

    [Fact]
    public async Task DeleteAnimalById_Return_NotFound()
    {
        // Arrange  
        var prodId = 999;

        // Act
        var result = await _controller.Delete(prodId) as ActionResult<AnimalDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<NotFoundObjectResult>(); // Verifica se o resultado é NotFoundResult

    }
}
