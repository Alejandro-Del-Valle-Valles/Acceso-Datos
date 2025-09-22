using System.Text.Json;
using Test_JSON.Model;

namespace Test_JSON.Service
{
    internal static class JsonService
    {
        private static JsonSerializerOptions INDENT = new JsonSerializerOptions { WriteIndented = true };
        public static bool SerializePersons(ICollection<Person> persons)
        {
            bool isSerialized = false;
            try
            {
                string json = JsonSerializer.Serialize(persons, INDENT);
                File.WriteAllText(DirectoryService.GetPath("persons.json"), json);
                isSerialized = true;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de serializar a las personas: {ex.Message}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"El directorio no ha sido encontrado: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al escribir los datos en el fichero: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return isSerialized;
        }

        public static List<Person> DeserializePersons()
        {
            return null;
        }
    }
}
