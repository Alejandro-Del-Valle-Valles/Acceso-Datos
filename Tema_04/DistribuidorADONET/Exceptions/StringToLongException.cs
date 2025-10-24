namespace DistribuidorADONET.Exceptions
{
    /// <summary>
    /// This exception inherits from InvalidException
    /// </summary>
    internal class StringToLongException : InvalidValueException
    {
        private const string DefaultMessage = "Length of the string is too long.";
        public StringToLongException() : base(DefaultMessage) { }
        public StringToLongException(string? message) : base(message) { }
        public StringToLongException(Exception? innerException) : base(DefaultMessage, innerException) { }
        public StringToLongException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
