using System.Text.Json;
using PreExamen.Repositorio;


namespace PreExamen.Ejercicios
{
    internal static class Ejercicio01App
    {
        private static readonly string FilesPath = "../../../Files/";

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static void Start()
        {
            bool personasSerializadas = SerializarPersonas();
            bool mascotasSerializadas = SerializarMascotas();
            if(personasSerializadas) Console.WriteLine("Personas serializadas con éxito.");
            if(mascotasSerializadas) Console.WriteLine("Mascotas serializadas con éxito.");
        }

        private static bool SerializarPersonas()
        {
            bool esSerializado = false;
            try
            {
                Directory.CreateDirectory(FilesPath);
                string json = JsonSerializer.Serialize(RepositorioPersonasMascotas.GetPersonas(), Options);
                File.WriteAllText(FilesPath + "personas.json", json);
                esSerializado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al serializar las personas a Json: {ex.Message}");
            }

            return esSerializado;
        }

        private static bool SerializarMascotas()
        {
            bool esSerializado = false;
            try
            {
                Directory.CreateDirectory(FilesPath);
                string json = JsonSerializer.Serialize(RepositorioPersonasMascotas.GetMascotas(), Options);
                File.WriteAllText(FilesPath + "mascotas.json", json);
                esSerializado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al serializar las mascotas a Json: {ex.Message}");
            }

            return esSerializado;
        }
    }
}
