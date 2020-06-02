
using System;

namespace MyNameSpace
{
    public class Helper
    {
        public Helper() { }
        /// <summary>
        /// Reading value from console.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int ReadConsoleValue(string name)
        {
            Console.Write($"Write sizes of double array:\n\t{name}:");
            var str = Console.ReadLine();
            int result;
            while (!(Int32.TryParse(str, out result) && result > 0))
            {
                Console.Write("\tInvalid value, write again: ");
                Console.Write("\n\t");
                str = Console.ReadLine();
            }
            return result;
        }
    }
}
