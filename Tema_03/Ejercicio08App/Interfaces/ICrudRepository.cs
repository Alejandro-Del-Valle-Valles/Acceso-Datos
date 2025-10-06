namespace Ejercicio08App.Interfaces
{
    internal interface ICrudRepository<T, ID>
    {
        List<T>? FindAll();
        T? FindById(ID id);
        bool SaveAll(List<T> entities);
        bool Add(T t);
        bool Save(T t);
        bool Remove(T t);
        bool RemoveById(ID id);
    }
}
