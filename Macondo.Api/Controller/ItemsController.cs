using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Macondo.Model;
using Macondo.Services; 


namespace Macondo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
          private readonly ItemService _itemService;

    public ItemsController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        var items = await _itemService.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _itemService.GetItemByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(Item item)
    {
        await _itemService.AddItemAsync(item);
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
public async Task<IActionResult> UpdateItem(Guid id, Item item)
{
    if (id != item.Id) return BadRequest("Item ID mismatch");
    await _itemService.UpdateItemAsync(item);
    return NoContent();
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        await _itemService.DeleteItemAsync(id);
        return NoContent();
    }
    }
}