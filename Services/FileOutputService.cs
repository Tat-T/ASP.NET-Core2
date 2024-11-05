using CocktailApp.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;

namespace CocktailApp.Services
{
    public class FileOutputService : IOutputService
    {
        public void OutputToFile(List<Cocktail> cocktails, string format)
        {
           if (format.ToLower() == "json")
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Отключаем экранирование символов Unicode
            };

            string jsonString = JsonSerializer.Serialize(cocktails, options);
            File.WriteAllText("cocktails.json", jsonString);
        }
            else if (format.ToLower() == "xml")
            {
                SaveAsXml(cocktails);
            }
            else
            {
                throw new ArgumentException("Unsupported format specified.");
            }
        }

        private void SaveAsJson(List<Cocktail> cocktails)
        {
            var json = JsonSerializer.Serialize(cocktails, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("cocktails.json", json);
        }

        private void SaveAsXml(List<Cocktail> cocktails)
        {
            var serializer = new XmlSerializer(typeof(List<Cocktail>));
            using var writer = new StreamWriter("cocktails.xml");
            serializer.Serialize(writer, cocktails);
        }
    }
}
