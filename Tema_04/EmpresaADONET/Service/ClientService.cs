using EmpresaADONET.Interfaces;
using EmpresaADONET.Model;
using Npgsql;
using System.Xml.Linq;

namespace EmpresaADONET.Service
{
    internal class ClientService : IClientService
    {
        private static readonly ClientPostgreDAO dbManager = new();
        public bool Delete(int id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = dbManager.Delete(id);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"No existe ningún cliente con el ID {id}: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de eliminar el cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return isDeleted;
        }

        /// <summary>
        /// Return a IEnumerable with all clients of the DB.
        /// Can return an empty list if something went worng or the DB doesn't contains clients yet.
        /// </summary>
        /// <param name="onlyCurrenCostumers">bool, True if only want the active clients, false otherwise.</param>
        /// <returns>IEnumerable of all clients.</returns>
        public IEnumerable<Client> FindAll(bool onlyCurrenCostumers)
        {
            IEnumerable<Client> clients = new List<Client>();
            try
            {
                clients = dbManager.GetAll();
                if(onlyCurrenCostumers) clients = clients.Where(client => client.IsActive == true);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"No existen clientes en la BBDD: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de recuperar los clientes: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return clients;
        }

        /// <summary>
        /// Return a client from the DB by the ID.
        /// Can return a null client if not exists or something went wrong.
        /// </summary>
        /// <param name="id">Int id of the searched client.</param>
        /// <returns>Client searched or null.</returns>
        public Client? FindById(int id)
        {
            Client? client = null;
            try
            {
                client = dbManager.GetById(id);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"No existe ningún cliente con el ID {id}: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de extraer el cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return client;
        }

        /// <summary>
        /// Return an IEnumerable with all clients form the DB with the searched name.
        /// Can be empty if ther's no clients with that name or something went worng.
        /// This is Case Sensitive.
        /// </summary>
        /// <param name="name">string searched name.</param>
        /// <returns>IEnumerable with all clients with the searched name.</returns>
        public IEnumerable<Client> FindByName(string name)
        {
            IEnumerable<Client> clients = new List<Client>();
            try
            {
                clients = dbManager.GetAll().Where(client => client.Name == name);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"No existen clientes en la BBDD: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de recuperar los clientes: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return clients;
        }

        /// <summary>
        /// Return a Dictionary with email as key and clients with that email as values.
        /// Can be empty if the DB doesn't contains clients yet or something went worng.
        /// </summary>
        /// <returns>Dictionary Key: string Value: IEnumerable of clients. Can be Empty.</returns>
        public Dictionary<string, IEnumerable<Client>> GetGroupByEmail()
        {
            Dictionary<string, IEnumerable<Client>> clients= new();
            try
            {
                clients = dbManager.GetAll().GroupBy(client => client.Email.Split("@")[1])
                    .ToDictionary(
                    group => group.Key,
                    group => group.AsEnumerable());

            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"No existen clientes en la BBDD: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de recuperar los clientes: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return clients;
        }

        /// <summary>
        /// Register a new client and insert it into the DB
        /// </summary>
        /// <param name="client">Client to register</param>
        /// <returns>bool, True if it was registered, false otherwise</returns>
        public bool Register(Client client)
        {
            bool isRegistered = false;
            try
            {
                isRegistered = dbManager.Insert(client);
            }
            catch(IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine($"Ya existe un cliente con el ID {client.Id}: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de registrar el cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return isRegistered;
        }

        /// <summary>
        /// Change the state of a client form IsActivated = true to false if exists in the DB.
        /// </summary>
        /// <param name="id">Int id of the client to unsuscribe.</param>
        /// <returns>bool, True if it was unsuscribed, false otherwise.</returns>
        public bool Unsuscribe(int id)
        {
            bool isUnsuscribed = false;
            try
            {
                Client? searchedClient = dbManager.GetById(id);
                if (searchedClient != null)
                {
                    searchedClient.IsActive = false;
                    isUnsuscribed = dbManager.Update(searchedClient);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"El cliente con ID {id} no existe o no se encuentra en la BBDD: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de desuscribir el cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return isUnsuscribed;
        }

        /// <summary>
        /// Update the data of a client if exists in the DB.
        /// </summary>
        /// <param name="client">Client to update</param>
        /// <returns>bool, True if it was updated, false otherwise</returns>
        public bool Update(Client client)
        {
            bool isUpadted = false;
            try
            {
                isUpadted = dbManager.Update(client);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo conectar con la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"El cliente con ID {client.Id} no existe o no se encuentra en la BBDD: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de actualizar el cliente: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }
            return isUpadted;
        }
    }
}
