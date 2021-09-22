using System;
using System.Collections;
using System.Linq;


// Aplikovanie dotazu na kolekciu ktora podporuje IEnumerable neparametrizované

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(1);
            numbers.Add(2);
         
            // Specifikujuci typ Int premenej (var - NIE JE možné použiť, pretože IEnumerable nie je parametrizované!)

            var query = from int n in numbers
                        select n * 2;

            foreach (var item in query)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
