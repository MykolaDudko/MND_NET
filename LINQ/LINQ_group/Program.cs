using System;
using System.Linq;

// // group - je prostriedok na rozdelenie vstupu dotazu.
namespace LINQ
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Rozdelenie cisel na parne a neparne
            var query = from x in numbers
                        group x by x % 3;

            foreach (var group in query)
            {
                Console.WriteLine("mod{0} == {0}", group.Key);

                foreach (var number in group)
                    Console.WriteLine("{0}, ", number);
            }

            
            Console.ReadKey();
        }
    }
}
