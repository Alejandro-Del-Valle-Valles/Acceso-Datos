namespace DistribuidorADONET.Model
{
    internal class ManufacturerDTO : IEquatable<ManufacturerDTO>
    {
        public string Name { get; set; }
        public IList<ArticleDTO> Articles { get; set; }

        public ManufacturerDTO(string name, IList<ArticleDTO> articles)
        {
            Name = name;
            Articles = articles;
        }

        public override string ToString() => $"Fabricante => Nombre: {Name}\nProductos:\n\t{string.Join("\n\t", Articles)}";
        

        public bool Equals(ManufacturerDTO? other)
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
            return Equals((ManufacturerDTO)obj);
        }

        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator ==(ManufacturerDTO? left, ManufacturerDTO? right) => Equals(left, right);

        public static bool operator !=(ManufacturerDTO? left, ManufacturerDTO? right) => !Equals(left, right);
    }
}
