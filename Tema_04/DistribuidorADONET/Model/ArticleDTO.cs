namespace DistribuidorADONET.Model
{
    internal class ArticleDTO : IEquatable<ArticleDTO>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public ArticleDTO(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString() => $"Artículo => Nombre: {Name}, Precio: {Price}€.";

        public bool Equals(ArticleDTO? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Price.Equals(other.Price);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ArticleDTO)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Name, Price);

        public static bool operator ==(ArticleDTO? left, ArticleDTO? right) => Equals(left, right);

        public static bool operator !=(ArticleDTO? left, ArticleDTO? right) => !Equals(left, right);
    }
}
