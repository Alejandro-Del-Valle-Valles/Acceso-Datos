namespace AdivinarLaPalabra.Model
{
    internal class Configuration : IEquatable<Configuration?>
    {
        public int MaximunAttempts { get; set; }
        public string[] Words { get; set; }
        public Configuration(int maximunAttempts, string[] words)
        {
            MaximunAttempts = maximunAttempts;
            Words = words;
        }

        public override bool Equals(object? obj) => Equals(obj as Configuration);

        public bool Equals(Configuration? other) => other is not null &&
                   EqualityComparer<string[]>.Default.Equals(Words, other.Words);

        public override int GetHashCode() => HashCode.Combine(Words);

        public static bool operator ==(Configuration? left, Configuration? right) => EqualityComparer<Configuration>.Default.Equals(left, right);

        public static bool operator !=(Configuration? left, Configuration? right) => !(left == right);
    }
}
