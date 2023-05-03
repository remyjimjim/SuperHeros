using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Superheros.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic> {
            new Comic { Id = 1, Name = "Marvel" },
            new Comic { Id = 2, Name = "DC" }
        };

        public static List<SuperHero> heros = new List<SuperHero> {
            new SuperHero {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                Comic = comics[0]
            },
            new SuperHero {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                Comic = comics[1]
            },
        };

        [HttpGet]
        /* Instead of using IActionResult, use ActionResult if you're using the
         * testing tool 'swagger'.  You'll also need the [HttpGet] declaration
         * above.  Otherwise, you could just do a public async Task here.  But 
         * Swagger testing is recommended by the author.
         */
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(heros); //return 200
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = heros.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero found here. ;/");
            }
            return Ok(hero);
        }
    }

    
}
