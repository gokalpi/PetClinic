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
    public class SpecialtiesController : ControllerBase
    {
        private readonly PetClinicDbContext _context;
        private readonly IMapper _mapper;

        public SpecialtiesController(PetClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Specialties
        [HttpGet]
        public ActionResult<IEnumerable<SpecialtyDto>> GetSpecialties()
        {
            var specialities = _mapper.Map<IEnumerable<SpecialtyDto>>(_context.Specialties);
            return Ok(specialities);
        }

        // GET: api/Specialties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialtyDto>> GetSpecialty(int id)
        {
            var specialty = await _context.Specialties.SingleOrDefaultAsync(s => s.Id == id);

            if (specialty == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SpecialtyDto>(specialty));
        }

        // PUT: api/Specialties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialty(int id, SpecialtyDto specialty)
        {
            if (id != specialty.Id)
            {
                return BadRequest();
            }

            var specialtyUpdated = await _context.Specialties.FindAsync(id);

            if (specialtyUpdated == null)
            {
                return NotFound();
            }

            specialtyUpdated.Name = specialty.Name;

            _context.Entry(specialtyUpdated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialtyExists(id))
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

        // POST: api/Specialties
        [HttpPost]
        public async Task<ActionResult<SpecialtyDto>> CreateSpecialty(SpecialtyDto specialty)
        {
            var specialtyCreate = _mapper.Map<Specialty>(specialty);

            _context.Specialties.Add(specialtyCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialty", new { id = specialty.Id }, specialty);
        }

        // DELETE: api/Specialties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialtyDto>> DeleteSpecialty(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }

            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();

            return _mapper.Map<SpecialtyDto>(specialty);
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialties.Any(e => e.Id == id);
        }
    }
}