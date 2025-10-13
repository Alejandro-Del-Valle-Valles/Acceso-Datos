
using AdivinaElNumero.Interfaces;

namespace AdivinaElNumero.Model
{
    internal class Configuration : IEquatable<Configuration?>
    {
        public int Minimun {  get; set; }
        public int Maximun { get; set; }
        public DateTime MaxDate { get; set; }
        public string RightMessage { get; set; }

        public Configuration(int minimu, int maximu, DateTime maxDate, string rightMessage)
        {
            Minimun = minimu;
            Maximun = maximu;
            MaxDate = maxDate;
            RightMessage = rightMessage;
        }

        public override bool Equals(object? obj) => Equals(obj as Configuration);

        public bool Equals(Configuration? other) => other is not null &&
                   Minimun == other.Minimun &&
                   Maximun == other.Maximun &&
                   MaxDate == other.MaxDate &&
                   RightMessage == other.RightMessage;

        public override int GetHashCode() => HashCode.Combine(Minimun, Maximun, MaxDate, RightMessage);

        public static bool operator ==(Configuration? left, Configuration? right) => EqualityComparer<Configuration>.Default.Equals(left, right);

        public static bool operator !=(Configuration? left, Configuration? right) => !(left == right);
    }
}
