using CocktailApp.Models;
using System.Collections.Generic;

namespace CocktailApp.Services
{
    public interface IOutputService
    {
        void OutputToFile(List<Cocktail> cocktails, string format);
    }
}
