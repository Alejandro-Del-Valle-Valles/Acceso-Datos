using DistribuidorADONET.Model;

namespace DistribuidorADONET.Interfaces
{
    internal interface IManufacturerDAO : IGenericDAO<ManufacturersDTO>
    {
        public ManufacturersDTO GetManufacturerAndArticlesByCode();
    }
}
