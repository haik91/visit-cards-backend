using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisitCardDemo.DbContexts;
using VisitCardDemo.Entities;
using VisitCardDemo.Models;

namespace VisitCardDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitCardsController : ControllerBase
    {
        private readonly VisitCardContext _context;
        private readonly IMapper _mapper;
        public VisitCardsController(VisitCardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var visitCards = await _context.VisitCards.ToListAsync();

            var getVisitCardsRespons = _mapper.Map<IEnumerable<GetVisitCard>>(visitCards);
            return Ok(visitCards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var visitCard = await _context.VisitCards.FindAsync(id);

            if (visitCard is null)
            {
                return NotFound();
            }

            var getVisitCardRespons = _mapper.Map<GetVisitCard>(visitCard);

            return Ok(getVisitCardRespons);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PostVisitCard visitCard)
        {
            var newCard = _mapper.Map<VisitCard>(visitCard);

            if (visitCard.Image != null)
            {
                using var memoryStream = new MemoryStream();
                await visitCard.Image.CopyToAsync(memoryStream);
                newCard.Image = memoryStream.ToArray();
            }


            _context.VisitCards.Add(newCard);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = newCard.Id }, newCard);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] UpdateVisitCard visitCard)
        {
            if (visitCard is null)
            {
                return BadRequest("VisitCard data is null.");
            }

            if (id != visitCard.Id)
            {
                return BadRequest("the id doesnt match");
            }

            var existingVisitCard = await _context.VisitCards.FindAsync(id);

            if (existingVisitCard is null)
            {
                return NotFound("the visit card in body doesnt exsist");
            }


            _mapper.Map(visitCard, existingVisitCard);


            if (visitCard.Image != null)
            {
                using var memoryStream = new MemoryStream();
                await visitCard.Image.CopyToAsync(memoryStream);
                existingVisitCard.Image = memoryStream.ToArray();
            }

            _context.Entry(existingVisitCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var visitCard = await _context.VisitCards.FindAsync(id);

            if (visitCard is null)
            {
                return NotFound();
            }

            _context.VisitCards.Remove(visitCard);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
