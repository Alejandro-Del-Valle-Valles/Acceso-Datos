using EmpresaADONET.Interfaces;
using EmpresaADONET.Model;
using Npgsql;

namespace EmpresaADONET.Service
{
    internal class ClientService(ICrudDAO<Client, int> dbManager) : IClientService, IEquatable<ClientService>
    {
        public ICrudDAO<Client, int> DbManager = dbManager;

        /// <summary>
        /// Two Client Service Are Equal if they have the same DB Manager
        /// </summary>
        /// <param name="other">Client Service to compare</param>
        /// <returns>bool, True if they're equal, false otherwise</returns>
        public bool Equals(ClientService? other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || DbManager.Equals(other.DbManager);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ClientService)obj);
        }

        public override int GetHashCode() => DbManager.GetHashCode();

        public static bool operator ==(ClientService? left, ClientService? right) => Equals(left, right);

        public static bool operator !=(ClientService? left, ClientService? right) => !Equals(left, right);

        /// <summary>
        /// Delete a Client from the DB or inform if not exist or something went wrong.
        /// </summary>
        /// <param name="id">Int id of the client to delete</param>
        /// <returns>bool, True if it was deleted, false otherwise</returns>
        public bool Delete(int id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = DbManager.Delete(id);
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
        /// Can return an empty list if something went wrong or the DB doesn't contain clients yet.
        /// </summary>
        /// <param name="onlyCurrentCostumers">bool, True if only want the active clients, false otherwise.</param>
        /// <returns>IEnumerable of all clients.</returns>
        public IEnumerable<Client> FindAll(bool onlyCurrentCostumers)
        {
            IEnumerable<Client> clients = new List<Client>();
            try
            {
                clients = DbManager.GetAll();
                if(onlyCurrentCostumers) clients = clients.Where(client => client.IsActive == true);
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
                client = DbManager.GetById(id);
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
                clients = DbManager.GetAll().Where(client => client.Name == name);
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
                clients = DbManager.GetAll().GroupBy(client =>
                    {
                        string domain = client.Email.Split("@").ElementAtOrDefault(1) ?? "Sin correo";
                        return domain;
                    })
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
                isRegistered = DbManager.Insert(client);
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
        public bool Unsubscribe(int id)
        {
            bool isUnsubscribed = false;
            try
            {
                Client? searchedClient = DbManager.GetById(id);
                if (searchedClient != null)
                {
                    searchedClient.IsActive = false;
                    isUnsubscribed = DbManager.Update(searchedClient);
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
            return isUnsubscribed;
        }

        /// <summary>
        /// Update the data of a client if exists in the DB.
        /// </summary>
        /// <param name="client">Client to update</param>
        /// <returns>bool, True if it was updated, false otherwise</returns>
        public bool Update(Client client)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = DbManager.Update(client);
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
            return isUpdated;
        }
    }
}
