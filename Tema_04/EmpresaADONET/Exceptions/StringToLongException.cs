namespace EmpresaADONET.Exceptions
{
    /// <summary>
    /// Throwed when a String iis to long.
    /// </summary>
    internal class StringToLongException : Exception
    {
        private const string _defaultMessage = "The string is too long.";
        public StringToLongException() : base(_defaultMessage) { }
        public StringToLongException(string message) : base(message) { }
        public StringToLongException(Exception ex) : base(_defaultMessage, ex) { }
        public StringToLongException(string message, Exception ex) : base(message, ex) { }
    }
}
