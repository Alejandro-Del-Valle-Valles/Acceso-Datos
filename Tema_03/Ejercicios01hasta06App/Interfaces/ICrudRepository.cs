namespace Ejercicios01hasta06App.Interfaces
{
    internal interface ICrudRepository<T, ID>
    {
        List<T> FindAll();
        T FindById(ID id);
        bool SaveAll(List<T> entities);
        T Add(T t);
        bool Save(T t);
        bool Remove(T t);
        bool RemoveById(ID id);
    }
}
