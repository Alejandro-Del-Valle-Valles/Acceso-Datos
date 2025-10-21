namespace DistribuidorADONET.Interfaces
{
    /// <summary>
    /// Interface for service class
    /// </summary>
    /// <typeparam name="T">object to act on.</typeparam>
    internal interface IGenericService<T>
    {
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(int code);
        T GetByCode(int code);
        IEnumerable<T> GetAll();
    }
}
