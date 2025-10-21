using EmpresaADONET.Exceptions;
using EmpresaADONET.Model;
using EmpresaADONET.Service;

namespace EmpresaADONET.Exercise
{
    internal class EmpresaApp
    {
        private static readonly ClientService Cs = new(new ClientPostgreDAO());

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
            Console.WriteLine();

            UnsubscribeClient(id);
            Console.WriteLine();

            DeleteClient(id);
            Console.WriteLine();

            ShowAllActiveClientsWithSpecificName("Alejandro");
            Console.WriteLine();

            ShowNamesOfClientsForEachDomain();
            Console.WriteLine();

            ShowClientsOrderedByDiscount();
            Console.WriteLine();

            ActiveAllClients();
            Console.WriteLine();
        }

        /// <summary>
        /// Show all clients from the DB.
        /// </summary>
        private static void ShowAllClients()
        {
            Console.WriteLine("CLIENTES DE LA BBDD:");
            Cs.FindAll(false)?.ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Show only the active clients from the DB.
        /// </summary>
        private static void ShowActiveClients()
        {
            Console.WriteLine("CLIENTES ACTIVOS:");
            Cs.FindAll(true)?.ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Show One client by his ID
        /// </summary>
        /// <param name="id"></param>

        private static void ShowClientById(int id)
        {
            Console.WriteLine($"Cliente con el ID: {id}");
            Console.WriteLine(Cs.FindById(id));
        }

        /// <summary>
        /// Increment in 1 the percent of discount of the client with the given ID
        /// or notify if the client doesn't exist.
        /// </summary>
        /// <param name="id">int id of the client.</param>

        private static void AddOnePercentToPreviousClient(int id)
        {
            try
            {
                Console.WriteLine($"Sumamos un 1% al cliente con ID{id}");
                Client? client = Cs.FindById(id);
                if (client != null)
                {
                    client.Discount++;
                    bool isSaved = Cs.Update(client);
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

        /// <summary>
        /// Change the status of a client from Active to Inactive if it wasn't inactive yet.
        /// If is inactive, notify it.
        /// </summary>
        /// <param name="id">int id of the client.</param>
        private static void UnsubscribeClient(int id)
        {
            Console.WriteLine($"Se desuscribe al cliente con Id {id}:");
            Client? client = Cs.FindById(id);
            if (client != null && client.IsActive != false)
            {
                client.IsActive = false;
                Cs.Update(client);
            }
            else Console.WriteLine($"El cliente no existe o ya está desuscrito.");
        }

        /// <summary>
        /// Delete a client form the DB if exist. If not, notify it.
        /// </summary>
        /// <param name="id">int id of the client to delete.</param>
        private static void DeleteClient(int id)
        {
            Console.WriteLine($"Eliminando al cliente con Id: {id}");
            bool isDeleted = Cs.Delete(id);
            if (isDeleted) Console.WriteLine("Cliente eliminado con éxito");
            else Console.WriteLine("No se pudo eliminar al cliente.");
        }

        /// <summary>
        /// Show all active clients with the given name.
        /// </summary>
        /// <param name="name">string name to search.</param>
        /// <param name="caseSensitive">bool, true for default case-sensitive, false if not.</param>
        private static void ShowAllActiveClientsWithSpecificName(string name, bool caseSensitive = true)
        {
            Console.WriteLine($"Buscando a todos los usuarios activos con nombre {name}:");
            Cs.FindByName(name)?
                .Where(client => client.IsActive == true).ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// For each domain of email, show the clients with that domain or "Sin Correo" if they haven't one.
        /// </summary>
        private static void ShowNamesOfClientsForEachDomain()
        {
            Console.WriteLine("Mostrando a todos los clientes por dominio.");
            foreach (var pair in Cs.GetGroupByEmail())
            {
                Console.WriteLine($"{pair.Key}:\n[");
                pair.Value.ToList().ForEach(Console.WriteLine);
                Console.WriteLine("]");
            }
        }

        /// <summary>
        /// Show the clients from the highest discount to the lowest.
        /// </summary>
        private static void ShowClientsOrderedByDiscount()
        {
            Console.WriteLine("Mostrando a todos los clientes por % de descuento:");
            Cs.FindAll(false)?
                .OrderByDescending(c => c.Discount).ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Change to active all clients of the DB.
        /// </summary>
        private static void ActiveAllClients()
        {
            Console.WriteLine("Cambiando a todos los clientes a activo:");
            Cs.FindAll(false)?
                .Where(c => !c.IsActive).ToList()
                .ForEach(c =>
                {
                    c.IsActive = true;
                    Cs.Update(c);
                    // That's no effective, it would be better to Open the connection once, update all, and close
                });
        }
    }
}
