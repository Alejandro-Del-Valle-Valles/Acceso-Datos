using Ejercicio08App.Interfaces;
using Ejercicio08App.Model;
using Newtonsoft.Json;

namespace Ejercicio08App.Repositories
{
    internal class ClientJsonRepository : ICrudRepository<Client, string>
    {
        public bool Add(Client t)
        {
            throw new NotImplementedException();
        }

        public List<Client>? FindAll() => JsonConvert.DeserializeObject<HashSet<Client>>(
                File.ReadAllText(@"../../../Files/clientes.json")
                ).ToList();
        

        public Client? FindById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Client t)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Client t)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll(List<Client> entities)
        {
            throw new NotImplementedException();
        }
    }
}
