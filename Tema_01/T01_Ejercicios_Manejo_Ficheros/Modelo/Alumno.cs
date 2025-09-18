using T01_Ejercicios_Manejo_Ficheros.Enums;

namespace T01_Ejercicios_Manejo_Ficheros.Modelo
{
    public class Alumno : IComparable<Alumno>
    {
        private static DateOnly ActualDate = DateOnly.FromDateTime(DateTime.Today);

        private int _nia;
        public int NIA {
            get => _nia;
            private set //Cannot be changed
            {
                if (value < 1) throw new ArgumentOutOfRangeException("El NIA no puede ser menor que 1");
                else _nia = value;
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        private DateOnly _birthDay = ActualDate;
        public DateOnly BirthDay
        {
            get => _birthDay;
            set => _birthDay = value > ActualDate
                ? _birthDay
                : value;
        }

        private float _averageScore = 0f;
        public float AverageScore
        {
            get => _averageScore;
            set => _averageScore = value < 0 ? _averageScore : value;
        }
        public FpType Grade { get; set; }
        public bool IsScholarship { get; set; }
        public int Age {
            get => ActualDate.Year - BirthDay.Year;
        }

        public Alumno(int Nia, string name, string surname, DateOnly birthDay, float averageScore, FpType grade, bool isScholarship)
        {
            NIA = Nia;
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            AverageScore = averageScore;
            Grade = grade;
            IsScholarship = isScholarship; //True if have a Scholarship, else if not
        }

        public override string ToString()
        {
            string formatedDate = BirthDay.ToString("dd/MM/yyyy");
            return $"Alumno(NIA: {NIA}, Name: {Name}, Surname: {Surname}, " +
                $"Birth Day: {formatedDate}, Age: {Age}, Average Score: {AverageScore}, Grade: {Grade}, Has Scholarship: {IsScholarship})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance. Can be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the specified object is an <see cref="Alumno"/> and has the same <see cref="NIA"/>
        /// value as the current instance; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Alumno alumno &&
                   NIA == alumno.NIA;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NIA);
        }

        public int CompareTo(Alumno? other)
        {
            return other == null
                ? 1
                : other.NIA.CompareTo(NIA);
        }
    }
}
