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
    public class RoomController : ControllerBase
    {
        private readonly HotelContext context;



        public RoomController(HotelContext _context)
        {
            context = _context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            return await context.Rooms.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetById(int id)
        {
            var ToDisp = await context.Rooms.FindAsync(id);
            if (ToDisp == null)
            {
                return NotFound();
            }
            return ToDisp;
        }
        [HttpPost]
        public async Task<ActionResult<Room>> Create([FromBody] Room room)
        {
            context.Rooms.Add(room);
            await context.SaveChangesAsync();
            //return Ok(alap);
            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            context.Entry(room).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDel = await context.Rooms.FindAsync(id);
            if (toDel == null)
            {
                return NotFound();
            }
            context.Rooms.Remove(toDel);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
