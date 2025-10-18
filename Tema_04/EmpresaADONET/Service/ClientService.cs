using EmpresaADONET.Interfaces;
using EmpresaADONET.Model;

namespace EmpresaADONET.Service
{
    internal class ClientService : IClientService
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> FindAll(bool onlyCurrenCostumers)
        {
            throw new NotImplementedException();
        }

        public Client FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IEnumerable<Client>> GetGroupByEmail()
        {
            throw new NotImplementedException();
        }

        public Client Register(Client client)
        {
            throw new NotImplementedException();
        }

        public bool Unsuscribe(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
