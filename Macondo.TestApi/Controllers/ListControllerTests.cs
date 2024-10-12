using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Macondo.Api.Controller;
using Macondo.Model;
using Macondo.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Macondo.TestApi.Controllers
{
public class ListControllerTests
    {
        // private readonly Mock<ListService> _mockListService;
        // private readonly ListController _controller;

        // public ListControllerTests()
        // {
        //     _mockListService = new Mock<ListService>();
        //     _controller = new ListController(_mockListService.Object);
        // }

        // [Fact]
        // public async Task GetAllLists_ReturnsOkResult_WithListOfLists()
        // {
        //     // Arrange
        //     var lists = new List<Macondo.Model.List> { new Macondo.Model.List("Test List") };
        //     _mockListService.Setup(service => service.GetAllListsAsync()).ReturnsAsync(lists);

        //     // Act
        //     var result = await _controller.GetAllLists();

        //     // Assert
        //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //     var returnLists = Assert.IsType<List<List>>(okResult.Value);
        //     Assert.Single(returnLists);
        }
    }
}