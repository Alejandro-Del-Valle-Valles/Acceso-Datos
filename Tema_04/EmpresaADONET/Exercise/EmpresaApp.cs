using EmpresaADONET.Exceptions;
using EmpresaADONET.Model;
using EmpresaADONET.Service;

namespace EmpresaADONET.Exercise
{
    internal class EmpresaApp
    {
        private static readonly ClientService cs = new();

        public static void Start()
        {
            int id = 2;
            ShowAllClients();
            Console.WriteLine();
            ShowActiveClients();
            Console.WriteLine();
            ShowClientById(id);
            Console.WriteLine();
            AddOnePercentToPreviousClient(id);
            UnsuscribeClient(id);
        }
        private static void ShowAllClients()
        {
            Console.WriteLine("CLIENTES DE LA BBDD:");
            cs.FindAll(false)?.ToList().ForEach(Console.WriteLine);
        }

        private static void ShowActiveClients()
        {
            Console.WriteLine("CLIENTES ACTIVOS:");
            cs.FindAll(true)?.ToList().ForEach(Console.WriteLine);
        }

        private static void ShowClientById(int id)
        {
            Console.WriteLine($"Cliente con el ID: {id}");
            Console.WriteLine(cs.FindById(id));
        }

        private static void AddOnePercentToPreviousClient(int id)
        {
            try
            {
                Console.WriteLine($"Sumamos un 1% al cliente con ID{id}");
                Client? client = cs.FindById(id);
                if (client != null)
                {
                    client.Discount++;
                    bool isSaved = cs.Update(client);
                    if (isSaved) Console.WriteLine("Cliente actualizado con éxito.");
                    else Console.WriteLine("No se pudo actualizar el cliente.");
                }
            }
            catch(InvalidValueException)
            {
                Console.WriteLine("No se puede aumentar más el descuento del cliente.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
        }

        private static void UnsuscribeClient(int id)
        {
            Console.WriteLine($"Se desuscribe al cliente con Id {id}:");
            Client? client = cs.FindById(id);
            if (client != null && client.IsActive != false)
            {
                client.IsActive = false;
                cs.Update(client);
            }
            else Console.WriteLine($"El cliente no existe o ya está desuscrito.");
        }

        private static void DeleteClient(int id)
        {
            Console.WriteLine($"Eliminando al cliente con Id: {id}");
            bool isDeleted = cs.Delete(id);
            if (isDeleted) Console.WriteLine("Cliente eliminado con éxito");
            else Console.WriteLine("No se pudo eliminar al cliente.");
        }

        private static void ShowAllActiveClientsWithSpecificName(string name, bool caseSensitive = true)
        {
            Console.WriteLine($"Buscando a todos los usuarios activos con nombre {name}:");
            cs.FindByName(name)?
                .Where(client => client.IsActive == true).ToList()
                .ForEach(Console.WriteLine);
        }

        private static void ShowNamesOfClientsForEachDomain()
        {

        }
    }
}
