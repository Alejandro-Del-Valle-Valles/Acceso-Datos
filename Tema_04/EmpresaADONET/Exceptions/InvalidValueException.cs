namespace EmpresaADONET.Exceptions
{
    /// <summary>
    /// Throwed when a value isn't accepted.
    /// </summary>
    internal class InvalidValueException : Exception
    {
        private const string _defaultMessage = "The value isn't valid.";

        public InvalidValueException() : base(_defaultMessage) { }
        public InvalidValueException(string message) : base(message) { }
        public InvalidValueException(Exception ex) : base(_defaultMessage, ex) { }
        public InvalidValueException(string message, Exception ex) : base(message, ex) { }
    }
}
