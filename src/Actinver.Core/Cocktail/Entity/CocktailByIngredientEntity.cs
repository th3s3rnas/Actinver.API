using System.Collections.Generic;

namespace Actinver.Core.Cocktail.Entity
{
    public class CocktailByIngredientsEntity : BaseEntity
    {
        public IEnumerable<CocktailByIngredientEntity> drinks { get; set; }
    }
    public class CocktailByIngredientEntity : BaseEntity
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
    }
}
