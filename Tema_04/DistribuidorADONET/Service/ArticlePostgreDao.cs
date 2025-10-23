using DistribuidorADONET.Model;
using DistribuidorADONET.Interfaces;


namespace DistribuidorADONET.Service
{
    internal class ArticlePostgreDao : IGenericDAO<Article>
    {
        private const string Path = "HOST=localhost;Port=54320;Database=empresa;Username=root;Password=1234;";
        public bool Insert(Article obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Article obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int code)
        {
            throw new NotImplementedException();
        }

        public Article? GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
