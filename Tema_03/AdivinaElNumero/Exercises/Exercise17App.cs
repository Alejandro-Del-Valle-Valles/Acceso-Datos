using AdivinaElNumero.Model;
using AdivinaElNumero.Interfaces;
using Newtonsoft.Json;

namespace AdivinaElNumero.Exercises
{
    internal class Exercise17App : IConfiguration
    {
        private static readonly string _path = "../../../Files/NumberConfiguration.json";
        private static readonly JsonSerializerSettings _jsettings = new()
        {
            DateFormatString = "dd-MM-yyyy"
        };
        public Configuration? GetConfiguration() => JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(_path), _jsettings);
    }
}
