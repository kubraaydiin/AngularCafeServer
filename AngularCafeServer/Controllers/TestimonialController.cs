using AngularCafeServer.Context;
using AngularCafeServer.DTOs.TestimonialDtos;
using AngularCafeServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularCafeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
        {
            var testimonial = await _context.Testimonials.ToListAsync();
            return testimonial;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return testimonial;
        }

        [HttpPost]
        public async Task<ActionResult<Testimonial>> PostTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = new Testimonial
            {
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Rating = createTestimonialDto.Rating,
                IsActive = createTestimonialDto.IsActive,
                DisplayOrder = createTestimonialDto.DisplayOrder
            };

            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestimonials", new { id = testimonial.Id }, testimonial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonial(int id, Testimonial about)
        {
            if (id != about.Id)
            {
                return BadRequest();
            }

            _context.Entry(about).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutExists(id))
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

        private bool AboutExists(int id)
        {
            return _context.Abouts.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}