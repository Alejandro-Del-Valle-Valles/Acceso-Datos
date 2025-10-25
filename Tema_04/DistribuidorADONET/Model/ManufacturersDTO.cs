namespace DistribuidorADONET.Model
{
    internal class ManufacturersDTO : IEquatable<ManufacturersDTO>
    {
        public string Name { get; set; }
        public IList<ArticlesDTO> Articles { get; set; }

        public ManufacturersDTO(string name, IList<ArticlesDTO> articles)
        {
            Name = name;
            Articles = articles;
        }

        public override string ToString()
        {
            return $"Fabricante => Nombre: {Name}\nProductos:\n{string.Join("\n\t", Articles)}";
        }

        public bool Equals(ManufacturersDTO? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ManufacturersDTO)obj);
        }

        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator ==(ManufacturersDTO? left, ManufacturersDTO? right) => Equals(left, right);

        public static bool operator !=(ManufacturersDTO? left, ManufacturersDTO? right) => !Equals(left, right);
    }
}
