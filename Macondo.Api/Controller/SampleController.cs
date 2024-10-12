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
    public class SampleController : ControllerBase
    {
         private readonly SampleService _Service;

        public SampleController(SampleService service)
        {
            _Service = service;
        }

        // GET: api/list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model.Sample>>> GetAllSamples()
        {
            var samples = await _Service.GetAllAsync();
            return Ok(samples);
        }

        // GET: api/list/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Macondo.Model.Sample>> GetSampleById(int id)
        {
            var sample = await _Service.GetByIdAsync(id);
            if (sample == null)
            {
                return NotFound();
            }
            return Ok(sample);
        }

        // POST: api/list
        [HttpPost]
        public async Task<ActionResult> AddSample([FromBody] Macondo.Model.Sample sample)
        {
            Console.WriteLine("in post list ... ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _Service.AddAsync(sample);
            return CreatedAtAction(nameof(GetSampleById), new { id = sample.Id }, sample);
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateSample(Guid id, Macondo.Model.Sample sample)
{
    if (id != sample.Id) return BadRequest("list ID mismatch");
    await _Service.UpdateAsync(sample);
    return NoContent();
}

        // DELETE: api/list/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var sample = await _Service.GetByIdAsync(id);
            if (sample == null)
            {
                return NotFound();
            }
            await _Service.DeleteAsync(id);
            return NoContent();
        }
    }
}