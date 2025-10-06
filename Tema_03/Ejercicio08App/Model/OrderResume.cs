using Ejercicio08App.Enums;

namespace Ejercicio08App.Model
{
    internal class OrderResume
    {
        public Guid Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Client? Cliente { get; set; }
        public EOrderType Tipo { get; set; }
        public string? ProductoMasCaro { get; set; }
        public float? Total { get; set; }
        private bool EsEntregado { get; }

        private string _entregado = "No";
        public string Entregado
        {
            get => _entregado;
            private set
            {
                if (EsEntregado) _entregado = "Sí";
            }
        }

        public OrderResume(Guid codigo, DateTime fechaCreacion, Client cliente, EOrderType tipo, string productoMasCaro, float total)
        {
            Codigo = codigo;
            FechaCreacion = fechaCreacion;
            Cliente = cliente;
            Tipo = tipo;
            ProductoMasCaro = productoMasCaro;
            Total = total;
            EsEntregado = FechaCreacion <= DateTime.Now.AddDays(-7);
            _entregado = EsEntregado ? "Sí" : "No";
        }

        public override string ToString()
        {
            return @$"Resumen(
Código: {Codigo}
Fecha de Creación: {FechaCreacion}
Cliente(
    Nombre: {Cliente.Nombre}
    Correo: {Cliente.Correo}
    )
Tipo: {Tipo}
Producto Más Caro: {ProductoMasCaro}
Total: {Total}
Entregado: {Entregado}
)";
        }
    }
}
