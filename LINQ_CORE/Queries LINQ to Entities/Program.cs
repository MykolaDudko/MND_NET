using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Queries_LINQ_to_Entities
{

    // V tomto priklade je zaujmavy Include to je v skratke vlozeny join 

    class Program
    {

        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                if (db.Phones.Count() == 0)
                {
                    Company c1 = new Company { Name = "Samsung",  };
                    Company c2 = new Company { Name = "Apple" };
                    db.Companies.AddRange(c1, c2);

                    Phone p1 = new Phone { Name = "Samsung Galaxy S8", Price = 50000, Company = c1 };
                    Phone p2 = new Phone { Name = "Samsung Galaxy S7", Price = 42000, Company = c1 };
                    Phone p3 = new Phone { Name = "iPhone 7", Price = 52000, Company = c2 };
                    Phone p4 = new Phone { Name = "iPhone 6S", Price = 42000, Company = c2 };

                    db.Phones.AddRange(p1, p2, p3, p4);
                    db.SaveChanges();
                }

                var phones = (from phone in db.Phones.Include(p => p.Company)
                              where phone.CompanyId == 1
                              select phone).ToList();

                foreach (var phone in phones)
                    Console.WriteLine($"{phone.Name} ({phone.Price}) - {phone.Company?.Name}");
            }
            Console.Read();

            Console.WriteLine(new string('-', 20));

            using (Context db = new Context())
            {
                var phones = db.Phones.Include(p => p.Company).Where(p => p.CompanyId == 1);
               
                foreach (var phone in phones)
                    Console.WriteLine($"{phone.Name} ({phone.Price}) - {phone.Company?.Name}");
            }
            Console.Read();
        }
    }
}
