namespace Actinver.Core.Cocktail.Interface
{
    using Actinver.Core.Cocktail.Entity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICocktailRepository
    {
        Task<CocktailsEntity> GetByName(string name);
        Task<CocktailsEntity> GetByIngredient(string ingredient);
        Task<CocktailsEntity> GetByIds(List<string> ids);
    }
}
