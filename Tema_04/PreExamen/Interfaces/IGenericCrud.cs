namespace PreExamen.Interfaces
{
    internal interface IGenericCrud<T, ID>
    {
        public bool Insert(T obj);
        public bool Update(T obj);
        public bool Delete(ID id);
        public T? GetById(ID id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetEspecial();
    }
}
