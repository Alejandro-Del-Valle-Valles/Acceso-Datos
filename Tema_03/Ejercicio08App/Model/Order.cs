
namespace Ejercicio08App.Model
{
    internal class Order : IEquatable<Order?>
    {
        public Guid Codigo { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaHora { get; set; }
        public IList<Product> Detalle { get; set; }

        public Order(Guid codigo, string cliente, DateTime fechaHora, IList<Product> detalle)
        {
            Codigo = codigo;
            Cliente = cliente;
            FechaHora = fechaHora;
            Detalle = detalle;
        }

        public override string ToString() => 
            $"Pedido(\nCódigo: {Codigo},\nCliente: {Cliente}\nFecha y Hora: {FechaHora}\nDetalles[\n\t{string.Join("\n\t", Detalle.Select(p => p.ToString()))}\n\t]\n)";

        public override bool Equals(object? obj) => Equals(obj as Order);

        public bool Equals(Order? other) => other is not null && Codigo.Equals(other.Codigo);
        

        public override int GetHashCode() => HashCode.Combine(Codigo);

        public static bool operator ==(Order? left, Order? right) => EqualityComparer<Order>.Default.Equals(left, right);

        public static bool operator !=(Order? left, Order? right) => !(left == right);
    }
}
