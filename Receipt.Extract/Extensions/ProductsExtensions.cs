using System.Text.RegularExpressions;

namespace Receipt.Extract.Extensions
{
    public static class ProductsExtensions
    {
        public static string CleanCode(this string source)
        {
            return Regex.Replace(source, @"[a-z]|[A-Z]|[\\.:]|[ó]|[()]", string.Empty).Trim();
        }

        public static string CleanQuantity(this string source)
        {
            return Regex.Replace(source, @"[a-z]|[A-Z]|[\\.:]", string.Empty).Trim();
        }

        public static string CleanUnity(this string source)
        {
            return source.CleanInput().Substring(2, 2);
        }

        public static string CleanValue(this string source)
        {
            return Regex.Replace(source, @"[a-z]|[A-Z]|[\\.:]", string.Empty).Trim();
        }

        public static string CleanInput(this string source)
        {
            try
            {
                return Regex.Replace(source, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return string.Empty;
            }
        }
    }
}
