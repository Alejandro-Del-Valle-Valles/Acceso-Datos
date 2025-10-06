
namespace Ejercicio08App.Model
{
    internal class Product : IEquatable<Product?>
    {
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public bool EnOferta { get; set; }

        public Product(string nombre, float precio, bool enOferta)
        {
            Nombre = nombre;
            Precio = precio;
            EnOferta = enOferta;
        }

        public override string ToString() => $"Producto(Nombre: {Nombre}, Precio: {Precio}, En Oferta: {EnOferta})";

        public override bool Equals(object? obj) => Equals(obj as Product);

        public bool Equals(Product? other) => other is not null &&
                                               Nombre == other.Nombre &&
                                               Precio == other.Precio &&
                                               EnOferta == other.EnOferta;

        public override int GetHashCode() => HashCode.Combine(Nombre, Precio, EnOferta);

        public static bool operator ==(Product? left, Product? right) => EqualityComparer<Product>.Default.Equals(left, right);

        public static bool operator !=(Product? left, Product? right) => !(left == right);
        
    }
}
