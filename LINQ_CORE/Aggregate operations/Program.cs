using System;
using System.Linq;

namespace Queries_LINQ_to_Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            // Any - podmineka ktoa dava true ked aspon jeden nazov zhoduje
            // All - podmineka ked dava true ked sa vsetky nazvy shoduju 
            using (Context db = new Context())
            {
               bool result1 = db.Phones.Any(p => p.Company.Name == "Samsung"); //Any()

               bool result2 = db.Phones.All(p => p.Company.Name == "Huawei"); //All() 
            }
            

            using (Context db = new Context())
            {
                int number1 = db.Phones.Count();

                int number2 = db.Phones.Count(p => p.Name.Contains("Samsung"));

                Console.WriteLine(number1);
                Console.WriteLine(number2);
            }

            using (Context db = new Context())
            {
                // Minimalna cena
                int minPrice = db.Phones.Min(p => p.Price);
                // Maximalna cena
                int maxPrice = db.Phones.Max(p => p.Price);
                // Stredna cena od firmy Samsung
                double avgPrice = db.Phones.Where(p => p.Company.Name == "Samsung")
                    .Average(p => p.Price);

                Console.WriteLine(minPrice);
                Console.WriteLine(maxPrice);
                Console.WriteLine(avgPrice);
            }

            using (Context db = new Context())
            {
                // Celkova cena
                int sum1 = db.Phones.Sum(p => p.Price);
                // Celkova cena Samsung
                int sum2 = db.Phones.Where(p => p.Name.Contains("Samsung"))
                    .Sum(p => p.Price);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
        }
    }
}
