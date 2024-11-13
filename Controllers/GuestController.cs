using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using SzallodaFoglalasAPI.Context;
using SzallodaFoglalasAPI.Entities;

namespace SzallodaFoglalasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly HotelContext context;



        public GuestController(HotelContext _context)
        {
            context = _context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
        {
            return await context.Guests.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetById(int id)
        {
            var ToDisp = await context.Guests.FindAsync(id);
            if (ToDisp == null)
            {
                return NotFound();
            }
            return ToDisp;
        }
        [HttpPost]
        public async Task<ActionResult<Guest>> Create([FromBody] Guest guest)
        {
            context.Guests.Add(guest);
            await context.SaveChangesAsync();
            //return Ok(alap);
            return CreatedAtAction(nameof(GetById), new { id = guest.Id }, guest);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Guest guest)
        {
            if (id != guest.Id)
            {
                return BadRequest();
            }
            context.Entry(guest).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Guests.FindAsync(id);
            if (toDel == null)
            {
                return NotFound();
            }
            context.Guests.Remove(toDel);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
