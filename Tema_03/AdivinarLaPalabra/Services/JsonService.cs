using AdivinarLaPalabra.Model;
using AdivinarLaPalabra.Interfaces;
using System.Text.Json;

namespace AdivinarLaPalabra.Services
{
    internal class JsonService : IConfiguration
    {
        private static readonly JsonSerializerOptions _settings = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
        };
        private const string _configPath = "../../../Files/configuration.json";
        private const string _winnersPath = "../../../Files/winners.json";

        public Configuration? GetConfiguration() => JsonSerializer.Deserialize<Configuration?>(File.ReadAllText(_configPath), _settings);

        public void SaveWinner(Player player)
        {
            string json;
            player.Duration = new(player.Duration.Hours, player.Duration.Minutes, player.Duration.Seconds);
            List<Player>? currentPlayers = new List<Player>();
            if (File.Exists(_winnersPath))
            {
                currentPlayers = JsonSerializer.Deserialize<List<Player>>(File.ReadAllText(_winnersPath), _settings);
                currentPlayers.Add(player); //If exist the file, exists winners.
                json = JsonSerializer.Serialize(currentPlayers, _settings);
                File.WriteAllText(_winnersPath, json);
            }
            else
            {
                currentPlayers.Add(player);
                json = JsonSerializer.Serialize(currentPlayers, _settings);
                File.WriteAllText(_winnersPath, json);
            }
        }
    }
}
