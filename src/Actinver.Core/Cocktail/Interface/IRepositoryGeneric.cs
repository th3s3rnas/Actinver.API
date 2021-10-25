namespace Actinver.Core.Cocktail.Interface
{
    using Actinver.Core.Cocktail.Entity;
    using System.Threading.Tasks;
    public interface IRepositoryGeneric<T> where T: BaseEntity
    {
        Task<CocktailsEntity> GetByName(string name);
        Task<CocktailsEntity> GetByIngredient(string ingredient);
    }
}
