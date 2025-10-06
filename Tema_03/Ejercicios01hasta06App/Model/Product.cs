
using Ejercicios01hasta06App.Exceptions;

namespace Ejercicios01hasta06App.Model
{
    internal class Product : IEquatable<Product?>
    {
        private const float MIN_PRICE = 10f;
        private const float MAX_PRICE = 99.99f;

        private int _id;
        public int Id
        {
            get => _id;
            private set
            {
                if (value > 0) _id = value;
                else throw new ArgumentException("El ID no puede ser inferior a 1");
            }
        }
        public string Name { get; set; }

        private float _price;
        public float Price {
            get => _price;
            set
            {
                if (value < MIN_PRICE || value > MAX_PRICE) throw new PriceOutOfRangeException();
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
