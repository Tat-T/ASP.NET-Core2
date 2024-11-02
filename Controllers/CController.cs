using Microsoft.AspNetCore.Mvc;
using CocktailApp.Models;
using CocktailApp.Services;
using System.Collections.Generic;

namespace CocktailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CController : ControllerBase
    {
        private readonly IOutputService _outputService;

        public CController(IOutputService outputService)
        {
            _outputService = outputService;
        }

        [HttpGet]
        public ActionResult<List<Cocktail>> GetCocktail()
        {
            var cocktails = new List<Cocktail>
            {
                new Cocktail { Name = "Маргарита", Сomposition = "Текила, Лаймовый сок, Куантро или трипл-сек, соль для ободка бокала" },
                new Cocktail { Name = "Мохито", Сomposition = "Белый ром, сок лайма, сахар, листья мяты, газированная вода" },
                new Cocktail { Name = "Пина Колада", Сomposition = "Светлый ром, кокосовое молоко, ананасовый сок" }
            };
            return Ok(cocktails);
        }

        [HttpPost("output")]
        public IActionResult OutputCocktail([FromBody] List<Cocktail> cocktails, [FromQuery] string format)
        {
            _outputService.OutputToFile(cocktails, format);
            return Ok();
        }
    }
}