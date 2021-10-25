namespace Actinver.Infrastructure.Repository.Cocktail
{
    using Actinver.Core.Cocktail.Entity;
    using Actinver.Core.Cocktail.Interface;
    using Actinver.Infrastructure.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class CockTailRepository : CocktailContext, ICocktailRepository
    {
        public async Task<CocktailsEntity> GetByIds(List<string> ids)
        {
            var listTasks = new List<Task>();
            var listCocktail = new CocktailsEntity();
            listTasks.Add(Task.Run(() =>
            {
                Parallel.ForEach(ids.ToList(), (cocktailId) =>
                {
                    var cocktail = GetByIdApi(cocktailId.ToString());
                    if (cocktail is not null)
                        listCocktail.drinks.AddRange(cocktail.Result.drinks.ToList());
                });
            }));

            Task.WhenAll(listTasks.ToList()).Wait();
            return listCocktail;
        }

        public async Task<CocktailsEntity> GetByIngredient(string ingredient)
        {
            var listTasks = new List<Task>();
            var listCocktail = new CocktailsEntity();
            var listByIngredient = await GetByIngredientApi(ingredient);
            if (listByIngredient is not null)
            {
                listTasks.Add(Task.Run(() =>
                {
                    Parallel.ForEach(listByIngredient.drinks.ToList(), (cocktailingredient) =>
                    {
                        var cocktail = GetByIdApi(cocktailingredient.idDrink);
                        if (cocktail is not null)
                            listCocktail.drinks.AddRange(cocktail.Result.drinks.ToList());
                    });
                }));

                Task.WhenAll(listTasks.ToList()).Wait();
            }
            return listCocktail;
        }

        public async Task<CocktailsEntity> GetByName(string name)
        {
            return await GetByNameApi(name);
        }
    }
}
