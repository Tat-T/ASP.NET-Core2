using CocktailApp.Models;
using System.Collections.Generic;
using System.IO;

namespace CocktailApp.Services
{
    public class FileOutputService : IOutputService
    {
        private readonly ICSer _serializer;

        public FileOutputService(ICSer serializer)
        {
            _serializer = serializer;
        }

        public void OutputToFile(List<Cocktail> cocktails, string format)
        {
            var content = _serializer.Serialize(cocktails);
            var filePath = $"Cocktails.{format.ToLower()}";
            File.WriteAllText(filePath, content);
        }
    }
}
