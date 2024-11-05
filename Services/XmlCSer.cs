using CocktailApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CocktailApp.Services
{
   public class XmlCSer : ICSer
    {
        public string Serialize(List<Cocktail> cocktails)
        {
            var serializer = new XmlSerializer(typeof(List<Cocktail>));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, cocktails);
                return stringWriter.ToString();
            }
        }
    }
}
