namespace CSharpClassProject.Ado.Classes.Extensions
{
    internal static class StringExtension
    {
        public static string Format(this string value, int length, char character = ' ')
        {
            while(value.Length < length)
            {
                value += character;
            }

            return value;
        }
    }
}