namespace Actinver.Infrastructure.Data
{
    using Actinver.Core.Cocktail.Entity;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class CocktailContext
    {
        public async Task<CocktailsEntity> GetByNameApi(string name)
        {
            return await Get<CocktailsEntity>($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={name}");
        }
        public async Task<CocktailByIngredientsEntity> GetByIngredientApi(string ingredient)
        {
            return await Get<CocktailByIngredientsEntity>($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={ingredient}");
        }
        public async Task<CocktailsEntity> GetByIdApi(string id)
        {
            return await Get<CocktailsEntity>($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");
        }
        private async Task<T> Get<T>(string endpoint)
        {
            var cocktailList = Activator.CreateInstance<T>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(endpoint))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cocktailList = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            return cocktailList;
        }
    }
}
