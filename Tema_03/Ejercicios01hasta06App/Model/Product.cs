
using Ejercicios01hasta06App.Exceptions;

namespace Ejercicios01hasta06App.Model
{
    internal class Product : IEquatable<Product?>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private float _price;
        public float Price {
            get => _price;
            set
            {
                if (value < 10 || value > 99.99) throw new PriceOutOfRangeException();
                else _price = value;
            }
        }
        public int? Stock { get; set; }
        public bool InSale { get; set; }

        public Product(int id, string name, float price, int? stock, bool inSale)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            InSale = inSale;
        }

        public override string ToString() =>
            $"Product(ID: {Id}, Name: {Name}, Price: {Price}, Stock: {Stock}, Is in sale: {InSale})";

        public override bool Equals(object? obj) => Equals(obj as Product);

        public bool Equals(Product? other)
        {
            return other is not null &&
                   Id == other.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Id);
        
        public static bool operator ==(Product? left, Product? right) => EqualityComparer<Product>.Default.Equals(left, right);

        public static bool operator !=(Product? left, Product? right) => !(left == right);
        
    }
}
