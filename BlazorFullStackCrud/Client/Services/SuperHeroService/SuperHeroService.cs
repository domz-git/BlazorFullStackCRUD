using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient httpClient;

        public SuperHeroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task GetComics()
        {
            var result = await httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");

            if (result != null)
            {
                Comics = result;
            }
            
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");

            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task GetSuperHeroes()
        {
            var result = await httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");

            if (result != null)
            {
                SuperHeroes = result;
            }
        }
    }
}
