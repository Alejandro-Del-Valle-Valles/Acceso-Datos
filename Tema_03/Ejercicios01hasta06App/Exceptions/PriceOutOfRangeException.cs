namespace Ejercicios01hasta06App.Exceptions
{
    internal class PriceOutOfRangeException : Exception
    {
        public PriceOutOfRangeException() : base("El precio está fuera del rango permitido") {  }
        public PriceOutOfRangeException(string message) : base(message) { }
        public PriceOutOfRangeException(string message, Exception inner) : base(message, inner) { }
    }
}
