using DistribuidorADONET.Model;

namespace DistribuidorADONET.Interfaces
{
    /// <summary>
    /// Interface to implement into DB Managers
    /// </summary>
    /// <typeparam name="T">object to act on</typeparam>
    internal interface IGenericDAO<T>
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(int code);
        T? GetByCode(int code);
        IEnumerable<T> GetAll();
    }
}
