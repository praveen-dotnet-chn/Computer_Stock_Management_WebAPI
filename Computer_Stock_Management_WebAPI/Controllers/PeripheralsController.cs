﻿using Computer_Stock_Management_WebAPI.Data;
using Computer_Stock_Management_WebAPI.Models;
using Computer_Stock_Management_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Computer_Stock_Management_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeripheralsController : ControllerBase
    {
        private readonly IPeripheralService _service;

        public PeripheralsController(IPeripheralService service)
        {
            _service = service;
        }

        // GET: api/peripherals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peripheral>>> GetAll()
        {
            var peripherals = await _service.GetAllAsync();
            return Ok(peripherals);
        }

        // GET: api/peripherals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Peripheral>> GetById(int id)
        {
            var peripheral = await _service.GetByIdAsync(id);
            if (peripheral == null)
                return NotFound();

            return Ok(peripheral);
        }

        // POST: api/peripherals
        [HttpPost]
        public async Task<ActionResult<Peripheral>> Create([FromBody] Peripheral peripheral)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(peripheral);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/peripherals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Peripheral peripheral)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, peripheral);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/peripherals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
