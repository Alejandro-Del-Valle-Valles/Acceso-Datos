namespace PreExamen.Interfaces
{
    internal interface IGenericService<T, ID>
    {
        public bool Crear(T obj);
        public bool Actualizar(T obj);
        public bool Eliminar(ID id);
        public T? GetById(ID id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetEspecial();
    }
}
