using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinic.Data;
using PetClinic.Dtos;
using PetClinic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly PetClinicDbContext _context;
        private readonly IMapper _mapper;

        public OwnersController(PetClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Owners
        [HttpGet]
        public ActionResult<IEnumerable<OwnerDto>> GetOwners()
        {
            var owners = _mapper.Map<IEnumerable<OwnerDto>>(_context.Owners.Include(o => o.Pets).ThenInclude(p => p.Visits));
            return Ok(owners);
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerDto>> GetOwner(int id)
        {
            var owner = await _context.Owners.Include(o => o.Pets).ThenInclude(p => p.Visits).SingleOrDefaultAsync(o => o.Id == id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OwnerDto>(owner));
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, OwnerDto owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }

            var ownerUpdated = await _context.Owners.FindAsync(id);

            if (ownerUpdated == null)
            {
                return NotFound();
            }

            _mapper.Map(owner, ownerUpdated);

            _context.Entry(ownerUpdated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<ActionResult<OwnerDto>> CreateOwner(OwnerDto owner)
        {
            var ownerCreate = _mapper.Map<Owner>(owner);

            _context.Owners.Add(ownerCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OwnerDto>> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return _mapper.Map<OwnerDto>(owner);
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}