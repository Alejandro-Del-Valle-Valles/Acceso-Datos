using System.Text.Json;
using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using DistribuidorADONET.Service;
using DistribuidorADONET.DAO;

namespace DistribuidorADONET.Exercises
{
    internal class Exercise10App
    {
        private static readonly string JsonPath = "../../../Files";
        private static readonly JsonSerializerOptions JOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        private static readonly IManufacturerService ManufacturersDbManager =
            new ManufacturerService(new ManufacturerPostgreDao());

        public static void Start()
        {
            ManufacturerDTO? data = GetManufacturerAndArticlesInfo(3);
            if (data != null)
            {
                Console.WriteLine(data);
                if(GenerateJson(data)) Console.WriteLine("Se ha creado con éxito el Json con la información solicitada.");
                else Console.WriteLine("No se pudo crear el Json.");
            }
            else Console.WriteLine("No se encontró o no se pudo obtener la información solicitada.");
        }

        /// <summary>
        /// Return the name of the searched manufacturer and their articles if exist in the DB.
        /// </summary>
        /// <param name="code">int code of the searched manufacturer.</param>
        /// <returns>ManufacturerDTO or null if not exists.</returns>
        private static ManufacturerDTO? GetManufacturerAndArticlesInfo(int code) => ManufacturersDbManager.GetManufacturerAndArtcilesInfo(3);

        private static bool GenerateJson(ManufacturerDTO data)
        {
            bool isCreated = false;
            try
            {
                string json = JsonSerializer.Serialize(data, JOptions);
                string fileName = $"{data.Name.Replace(" ", "-")}Info{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss")}";
                Directory.CreateDirectory(JsonPath);
                File.WriteAllText($"{JsonPath}/{fileName}.json", json);
                isCreated = true;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"No se puede acceder al directorio para crear el fichero o la ruta es incorrecta: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo crear o escribir la información en el Json: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error ineseperado al tratar de crear el Json: {ex.Message}");
            }

            return isCreated;
        }
    }
}
