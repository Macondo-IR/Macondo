using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Macondo.Services;
using Macondo.Api.Controller;
using Macondo.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Macondo.TestApi.Controllers
{
    public class ItemsControllerTests
    {
        //   private readonly Mock<ItemService> _mockItemService;
        // private readonly ItemsController _controller;

        // public ItemsControllerTests()
        // {
        //     _mockItemService = new Mock<ItemService>();
        //     _controller = new ItemsController(_mockItemService.Object);
        // }

        // [Fact]
        // public async Task GetItems_ReturnsOkResult_WithListOfItems()
        // {
        //     // Arrange
        //     var items = new List<Item> { new Item("Test Item", Macondo.Model.Enums.ItemType.String) };
        //     _mockItemService.Setup(service => service.GetAllItemsAsync()).ReturnsAsync(items);

        //     // Act
        //     var result = await _controller.GetItems();

        //     // Assert
        //     var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //     var returnItems = Assert.IsType<List<Item>>(okResult.Value);
        //     Assert.Single(returnItems);
        // }
    }
}