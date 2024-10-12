using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Macondo.Services; 

namespace Macondo.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
         private readonly ListService _listService;

        public ListController(ListService listService)
        {
            _listService = listService;
        }

        // GET: api/list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.List>>> GetAllLists()
        {
            var lists = await _listService.GetAllListsAsync();
            return Ok(lists);
        }

        // GET: api/list/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Macondo.Model.List>> GetListById(int id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // POST: api/list
        [HttpPost]
        public async Task<ActionResult> AddList([FromBody] Macondo.Model.List list)
        {
            Console.WriteLine("in post list ... ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _listService.AddListAsync(list);
            return CreatedAtAction(nameof(GetListById), new { id = list.Id }, list);
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateItem(Guid id, Macondo.Model.List list)
{
    if (id != list.Id) return BadRequest("list ID mismatch");
    await _listService.UpdateListAsync(list);
    return NoContent();
}

        // DELETE: api/list/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var list = await _listService.GetListByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            await _listService.DeleteListAsync(id);
            return NoContent();
        }
    }
}