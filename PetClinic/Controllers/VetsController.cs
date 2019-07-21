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
    public class VetsController : ControllerBase
    {
        private readonly PetClinicDbContext _context;
        private readonly IMapper _mapper;

        public VetsController(PetClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Vets
        [HttpGet]
        public ActionResult<IEnumerable<VetDto>> GetVets()
        {
            var vets = _mapper.Map<IEnumerable<VetDto>>(_context.Vets.Include(v => v.Specialties));
            return Ok(vets);
        }

        // GET: api/Vets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VetDto>> GetVet(int id)
        {
            var vet = await _context.Vets.Include(v => v.Specialties).SingleOrDefaultAsync(v => v.Id == id);

            if (vet == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VetDto>(vet));
        }

        // PUT: api/Vets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVet(int id, VetDto vet)
        {
            if (id != vet.Id)
            {
                return BadRequest();
            }

            var vetUpdated = await _context.Vets.FindAsync(id);

            if (vetUpdated == null)
            {
                return NotFound();
            }

            _mapper.Map(vet, vetUpdated);

            _context.Entry(vet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetExists(id))
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

        // POST: api/Vets
        [HttpPost]
        public async Task<ActionResult<VetDto>> CreateVet(VetDto vet)
        {
            var vetCreate = _mapper.Map<Vet>(vet);

            _context.Vets.Add(vetCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVet", new { id = vet.Id }, vet);
        }

        // DELETE: api/Vets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VetDto>> DeleteVet(int id)
        {
            var vet = await _context.Vets.FindAsync(id);
            if (vet == null)
            {
                return NotFound();
            }

            _context.Vets.Remove(vet);
            await _context.SaveChangesAsync();

            return _mapper.Map<VetDto>(vet);
        }

        private bool VetExists(int id)
        {
            return _context.Vets.Any(e => e.Id == id);
        }
    }
}