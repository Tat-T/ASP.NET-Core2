using CocktailApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CocktailApp.Services
{
    public class JsonCSer: ICSer
    {
        public string Serialize(List<Cocktail> cocktails)
        {
            return JsonConvert.SerializeObject(cocktails, Formatting.Indented);
        }
    }
}
