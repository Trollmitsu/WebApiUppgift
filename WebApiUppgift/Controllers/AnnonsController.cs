using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUppgift.Data;
using WebApiUppgift.DTO;

namespace WebApiUppgift.Controllers
{
    [Route("ads/[controller]")]
    [ApiController]
    public class AnnonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnonsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id, DeleteDTO DeleteAnnons)
        {
            var annons = _context.Annonser.FirstOrDefault(e => e.Id == id);
            if (annons == null) return NotFound();

            _context.Remove(annons);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateDTO UpdateAnnons)
        {
            var annons = _context.Annonser.FirstOrDefault(e => e.Id == id);
            if (annons == null) return NotFound();

            annons.Title = UpdateAnnons.Title;
            annons.Description = UpdateAnnons.Description;
            
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var annons = _context.Annonser.FirstOrDefault(e => e.Id == id);
            if (annons == null)
                return NotFound();
            var ret = new GetOneDTO
            {
                Id = annons.Id,
                Title = annons.Title,
                Description = annons.Description,


            };
            return Ok(ret);
        }

        [HttpPost]
        public IActionResult Create(CreateDTO Nyannons)
        {
            var annonser = new Annonser
            {
                Title = Nyannons.Title,
                Description = Nyannons.Description
            };
            _context.Annonser.Add(annonser);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetOne), annonser);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           
            return Ok(_context.Annonser.Select(e => new GetOneDTO
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                

            }).ToList());

        }

       
    }
}
