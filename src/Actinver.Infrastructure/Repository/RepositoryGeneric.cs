namespace Actinver.Infrastructure.Repository
{
    using Actinver.Core.Cocktail.Entity;
    using Actinver.Core.Cocktail.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : BaseEntity
    {
        public Task<CocktailsEntity> GetByIngredient(string ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<CocktailsEntity> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
