namespace EmpresaADONET.Interfaces
{
    /// <summary>
    /// Interface to implement the CRUD actions
    /// </summary>
    internal interface ICrudDAO<T, ID>
    {
        public bool Insert(T entity);
        public T? GetById(ID id);
        public IEnumerable<T> GetAll();
        public bool Update(T entity);
        public bool Delete(ID id);
    }
}
