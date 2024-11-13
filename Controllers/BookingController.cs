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
    public class BookingController : ControllerBase
    {
        private readonly HotelContext context;



        public BookingController(HotelContext _context)
        {
            context = _context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            return await context.Bookings.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(int id)
        {
            var ToDisp = await context.Bookings.FindAsync(id);
            if (ToDisp == null)
            {
                return NotFound();
            }
            return ToDisp;
        }
        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
            //return Ok(alap);
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            context.Entry(booking).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Bookings.FindAsync(id);
            if (toDel == null)
            {
                return NotFound();
            }
            context.Bookings.Remove(toDel);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
