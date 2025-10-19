using EmpresaADONET.Model;

namespace EmpresaADONET.Interfaces
{
    /// <summary>
    /// Interface to manage Clints into the DB.
    /// </summary>
    internal interface IClientService
    {
        public bool Register(Client client);
        public Client? FindById(int id);
        public IEnumerable<Client> FindByName(string name);
        public IEnumerable<Client> FindAll(bool onlyCurrenCostumers);
        public bool Update(Client client);
        public bool Delete(int id);
        public bool Unsuscribe(int id);
        public Dictionary<string, IEnumerable<Client>> GetGroupByEmail();
    }
}
