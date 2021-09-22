using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries_LINQ_to_Entities
{
    class Program
    {
        static void Main(string[] args)
        {

            using (Context db = new Context())
            {
                //IEnumerable - da obycajne selecet dotas a potom filtruje v code  podla where
                // - tu dostanes vsekty data

                int id = 1;
                IEnumerable<Phone> phoneIEnum = db.Phones;
                var phones = phoneIEnum.Where(p => p.Id > id).ToList();
            }

            using (Context db = new Context())
            {
                //IQueryable - da dotaz aj s podminku na stranu databaze
                //- tu dostanes len vyfitrovane data 

                int id = 1;
                IQueryable<Phone> phoneIQuer = db.Phones;
                var phones = phoneIQuer.Where(p => p.Id > id).ToList();
            }

            using (Context db = new Context())
            {
                IQueryable<Phone> phoneIQuer = db.Phones;
                phoneIQuer = phoneIQuer.Where(p => p.CompanyId == 1);
                phoneIQuer = phoneIQuer.Where(p => p.Price < 50000);
                var phones = phoneIQuer.ToList();
            }
        }
    }
}
