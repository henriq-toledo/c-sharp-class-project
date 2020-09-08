using System;
using System.Linq;

namespace CSharpClassProject.RefOutSample.Extensions
{
    internal static class StringExtension
    {
        public static string OnlyChars(this string value)
        {
            var ienumerable = value.Where(c => 
            {
                Console.WriteLine(c);

                return char.IsDigit(c) == false;
            });
            var charArray = ienumerable.ToArray();
            var text = new string(charArray);

            //return new string (value.Where(c => char.IsDigit(c) == false).ToArray());

            return text;
        }
    }
}