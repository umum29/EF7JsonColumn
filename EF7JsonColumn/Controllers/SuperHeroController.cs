using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EF7JsonColumn.Data;
using Microsoft.EntityFrameworkCore;

namespace EF7JsonColumn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHeroes(List<SuperHero> heroes)
        {
            _context.Heroes.AddRange(heroes);
            await _context.SaveChangesAsync();
            /*
             When using the Ok method without parameter, it will return an OkResult object.
            If using the Ok method with the parameter (an object), it will return an OkObjectResult object.

            The difference between OkResult and OkObjectResult,
            the OkResult will show an empty 200 response, and
            the OkObjectResult will show the 200 responses with the passed object.

            So, the code return Ok(); equals return new OkResult(); , and
            the code return Ok(object); equals return new OkObjectResult(object);.
            The only difference for me is readability of code and your own or your team preferences.
             */
            /*
             Ok() is a controller method that returns a new OkResult();
Ok(object) is a controller method that returns a new OkObjectResult(object);

the OkResult class implements an ActionResult that produces an empty 200 response
the OkObjectResult class implements an ActionResult that process a 200 response with a body based on the passed object.
             */
            return Ok(await _context.Heroes.ToListAsync());

        }

        [HttpGet("{city}")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes(string city)
        {
            var heroes = await _context.Heroes.Include(h=>h.Details).Where(h => h.Details!.City.Contains(city)).ToListAsync();
            return Ok(heroes);
        }

        
    }
}
