using CocktailApp.Models;
using System.Collections.Generic;

namespace CocktailApp.Services
{
    public interface ICSer
    {
        string Serialize(List<Cocktail> cocktails);
    }
}
