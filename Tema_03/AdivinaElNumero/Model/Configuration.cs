
using AdivinaElNumero.Interfaces;

namespace AdivinaElNumero.Model
{
    internal class Configuration : IEquatable<Configuration?>
    {
        public int Minimu {  get; set; }
        public int Maximu { get; set; }
        public DateTime MaxDate { get; set; }
        public string RightMessage { get; set; }

        public Configuration(int minimu, int maximu, DateTime maxDate, string rightMessage)
        {
            Minimu = minimu;
            Maximu = maximu;
            MaxDate = maxDate;
            RightMessage = rightMessage;
        }

        public override bool Equals(object? obj) => Equals(obj as Configuration);

        public bool Equals(Configuration? other) => other is not null &&
                   Minimu == other.Minimu &&
                   Maximu == other.Maximu &&
                   MaxDate == other.MaxDate &&
                   RightMessage == other.RightMessage;

        public override int GetHashCode() => HashCode.Combine(Minimu, Maximu, MaxDate, RightMessage);

        public static bool operator ==(Configuration? left, Configuration? right) => EqualityComparer<Configuration>.Default.Equals(left, right);

        public static bool operator !=(Configuration? left, Configuration? right) => !(left == right);
    }
}
