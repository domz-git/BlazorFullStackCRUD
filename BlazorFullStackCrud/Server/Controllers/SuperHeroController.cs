using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic> {

            new Comic{ Id=1, Name="Marvel"},
            new Comic{Id=2, Name="DC"}
        };

        public static List<SuperHero> superHeroes = new List<SuperHero>{

            new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic=comics[0], ComicId = 1 },
            new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = comics[1], ComicId = 2 },

        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroeos()
        {

            if (superHeroes == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(superHeroes);
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {

            if (comics == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(comics);
            }
            catch (Exception)
            {

                throw;
            }


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = superHeroes.FirstOrDefault(x => x.Id == id);

            if (superHeroes == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(hero);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
