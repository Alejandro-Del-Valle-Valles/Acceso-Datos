using DistribuidorADONET.Model;

namespace DistribuidorADONET.Interfaces
{
    internal interface IManufacturerDAO : IGenericDAO<Manufacturer>
    {
        public ManufacturerDTO? GetManufacturerAndArticlesByCode(int code);
    }
}
