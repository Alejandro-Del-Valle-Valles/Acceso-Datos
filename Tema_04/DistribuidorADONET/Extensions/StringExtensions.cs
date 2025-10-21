namespace DistribuidorADONET.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsNotNullOrEmptyAndEqualOrLowerThan(this string? text, int length)
        {
            return (!string.IsNullOrEmpty(text) && text?.Length <= length);
        }

        public static bool IsNotNullOrEmptyAndLowerThan(this string? text, int length)
        {
            return (!string.IsNullOrEmpty(text) && text?.Length <= length);
        }
    }
}
