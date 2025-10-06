
namespace Ejercicio08App.Model
{
    internal class Order : IEquatable<Order?>
    {
        public Order()
        {
        }

        public Guid Codigo { get; set; }
        public Client cliente { get; set; }
        public DateTime fechaHora { get; set; }
        public IList<Product> Detalles { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Order);
        }

        public bool Equals(Order? other)
        {
            return other is not null &&
                   Codigo.Equals(other.Codigo);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo);
        }

        public static bool operator ==(Order? left, Order? right)
        {
            return EqualityComparer<Order>.Default.Equals(left, right);
        }

        public static bool operator !=(Order? left, Order? right)
        {
            return !(left == right);
        }
    }
}
