using EmpresaADONET.Model;

namespace EmpresaADONET.Interfaces
{
    /// <summary>
    /// Interface to manage Clients into the DB.
    /// </summary>
    internal interface IClientService
    {
        public bool Register(Client client);
        public Client? FindById(int id);
        public IEnumerable<Client> FindByName(string name);
        public IEnumerable<Client> FindAll(bool onlyCurrentCostumers);
        public bool Update(Client client);
        public bool Delete(int id);
        public bool Unsubscribe(int id);
        public Dictionary<string, IEnumerable<Client>> GetGroupByEmail();
    }
}
