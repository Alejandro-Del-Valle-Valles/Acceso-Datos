using MyLibray;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Ejercicio08App.services
{
    internal static class VehiclesService
    {
        private static JSchema schema = JSchema.Parse(File.ReadAllText("../../../Files/vehículos.schema.json"));

        public static void ShowValidationOfEachVehicleFile()
        {
            bool isValid;
            string[] files = GetPathOfAllVehichleFiles();
            foreach (var item in files)
            {
                JArray json = JArray.Parse(File.ReadAllText(item));
                isValid = json.IsValid(schema, out IList<string> errors);
                if (!isValid)
                {
                    Console.WriteLine($"Errores en {item}:");
                    foreach (var error in errors) Console.WriteLine($"  - {error}");
                }
                else
                {
                    Console.WriteLine($"Objeto válido en {item}");
                }
            }
        }
        private static string[] GetPathOfAllVehichleFiles()
        {
            string fileName = "vehículos_XX.json";
            string actualNumber;
            List<string> files = new List<string>();

            for (byte i = 0; i < 100; i++)
            {
                actualNumber = i.ToString("D2");
                string fullPath = Path.Combine("../../../Files", fileName.Replace("XX", actualNumber));

                if (File.Exists(fullPath))
                {
                    files.Add(fullPath);
                }
            }

            return files.ToArray();
        }

    }
}
