using Microsoft.AspNetCore.Mvc;
using CocktailApp.Models;
using CocktailApp.Services;
using System.Collections.Generic;

namespace CocktailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailController : ControllerBase
    {
        private readonly IOutputService _outputService;

        public CocktailController(IOutputService outputService)
        {
            _outputService = outputService;
        }

        [HttpGet]
        public ActionResult<List<Cocktail>> GetCocktails()
        {
            var cocktails = new List<Cocktail>
            {
                new Cocktail { Name = "Маргарита", Composition = "Текила, Лаймовый сок, Куантро или трипл-сек, соль для ободка бокала" },
                new Cocktail { Name = "Мохито", Composition = "Белый ром, сок лайма, сахар, листья мяты, газированная вода" },
                new Cocktail { Name = "Пина Колада", Composition = "Светлый ром, кокосовое молоко, ананасовый сок" }
            };
            return Ok(cocktails);
        }

        [HttpPost("SaveCocktail")]
        public IActionResult SaveCocktail([FromBody] Cocktail cocktail)
        {
            var cocktails = new List<Cocktail> { cocktail };
            _outputService.OutputToFile(cocktails, "json"); // Сохраняем как JSON (можно изменить формат по необходимости)
            return Ok();
        }

        [HttpPost("output")]
        public IActionResult OutputCocktails([FromQuery] string format)
        {
            var cocktails = new List<Cocktail>
            {
                new Cocktail { Name = "Маргарита", Composition = "Текила, Лаймовый сок, Куантро или трипл-сек, соль для ободка бокала" },
                new Cocktail { Name = "Мохито", Composition = "Белый ром, сок лайма, сахар, листья мяты, газированная вода" },
                new Cocktail { Name = "Пина Колада", Composition = "Светлый ром, кокосовое молоко, ананасовый сок" }
            };
            _outputService.OutputToFile(cocktails, format);
            return Ok();
        }
    }
}
