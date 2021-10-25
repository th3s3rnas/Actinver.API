

namespace Actinver.API.Controllers.Cocktail
{
    using Actinver.API.Dto;
    using Actinver.Core.Cocktail.Entity;
    using Actinver.Core.Cocktail.Interface;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class CocktailController : ControllerBase
    {
        private readonly ICocktailRepository _ICocktailRepository;
        public CocktailController(ICocktailRepository ICocktailRepository)
        {
            _ICocktailRepository = ICocktailRepository;
        }

        [HttpGet("{type}/{value}")]
        public async Task<ResultApi<CocktailsEntity>> Get(string type, string value)
        {
            var result = new ResultApi<CocktailsEntity>();
            result.Response = new CocktailsEntity();
            try
            {
                if(type is not null)
                {
                    switch (type)
                    {
                        case "byName":
                            result.Response = await _ICocktailRepository.GetByName(value);
                            break;
                        case "byIngredient":
                            result.Response = await _ICocktailRepository.GetByIngredient(value);
                            break;
                        case "byIds":
                            var list = value.Split(",").ToList();
                            result.Response = await _ICocktailRepository.GetByIds(list);
                            break;
                    }
                }
            }
            catch (Exception error)
            {
                result.Error = new ResultApiError() { Code = error.GetHashCode().ToString(), Message = "Error to execute CocktailController.Get()", Detail = error.Message };
            }
            return result;
        }
    }
}
