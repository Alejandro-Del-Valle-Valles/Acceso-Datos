using Test_JSON.Data;
using Test_JSON.Model;
using Test_JSON.Service;

namespace Test_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = PersonsRepository.GetPersons();
            bool isSerialized = JsonService.SerializePersons(persons);
            if (isSerialized) Console.WriteLine("Ha sido serializado con éxito.");
            else Console.WriteLine("No se ha podido serializar. :(");
        }
    }
}
