namespace DistribuidorADONET.Exceptions
{
    internal class InvalidValueException : Exception
    {
        private const string DefaultMessage = "The value is not valid.";
        public InvalidValueException() : base(DefaultMessage) { }
        public InvalidValueException(string? message) : base(message) { }

        public InvalidValueException(Exception? innerException) : base(DefaultMessage, innerException) { }

        public InvalidValueException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
