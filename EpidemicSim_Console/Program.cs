using System;
using PSC2013.ES.Library.Population;

namespace PSC2013.ES.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Human h = new Human();
            var gH = h.GetGender();
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
