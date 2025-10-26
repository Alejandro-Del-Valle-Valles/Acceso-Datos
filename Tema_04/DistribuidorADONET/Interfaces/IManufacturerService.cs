using DistribuidorADONET.Model;

namespace DistribuidorADONET.Interfaces
{
    internal interface IManufacturerService : IGenericService<Manufacturer>
    {
        public ManufacturerDTO? GetManufacturerAndArtcilesInfo(int code);
    }
}
