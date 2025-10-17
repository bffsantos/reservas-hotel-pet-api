using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using ReservasHotelPetAPI.Controllers;
using ReservasHotelPetAPI.DTOs;
using ReservasHotelPetAPITests.UnitTests;

namespace ApiCatalogoxUnitTests.UnitTests;

public class GetAnimaisUnitTests : IClassFixture<AnimaisUnitTestController>
{
    private readonly AnimaisController _controller;

    public GetAnimaisUnitTests(AnimaisUnitTestController controller)
    {
        _controller = new AnimaisController(controller.repository, controller.mapper);
    }

    [Fact]
    public async Task GetAnimalById_OKResult()
    {
        //Arrange
        var prodId = 2;

        //Act
        var data = await _controller.Get(prodId);

        ////Assert (xunit)
        //var okResult = Assert.IsType<OkObjectResult>(data.Result);
        //Assert.Equal(200, okResult.StatusCode);

        //Assert (fluentassertions)
        data.Result.Should().BeOfType<OkObjectResult>()//verifica se o resultado é do tipo OkObjectResult.
                   .Which.StatusCode.Should().Be(200);//verifica se o código de status do OkObjectResult é 200.
    }

    [Fact]
    public async Task GetAnimalById_Return_NotFound()
    {
        //Arrange  
        var prodId = 999;

        // Act  
        var data = await _controller.Get(prodId);

        // Assert  
        data.Result.Should().BeOfType<NotFoundObjectResult>()
                    .Which.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetAnimalById_Return_BadRequest()
    {
        //Arrange  
        int prodId = -1;

        // Act  
        var data = await _controller.Get(prodId);

        // Assert  
        data.Result.Should().BeOfType<BadRequestObjectResult>()
                   .Which.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task GetAnimais_Return_ListOfProdutoDTO()
    {
        // Act  
        var data = await _controller.Get();

        // Assert
        data.Result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeAssignableTo<IEnumerable<AnimalDTO>>() //Verifica se o valor do OkObjectResult é atribuível a IEnumerable<ProdutoDTO>.
            .And.NotBeNull();
    }

    [Fact]
    public async Task GetAnimais_Return_BadRequestResult()
    {
        // Act  
        var data = await _controller.Get();

        //Assert
        data.Result.Should().BeOfType<BadRequestResult>();
    }
}
