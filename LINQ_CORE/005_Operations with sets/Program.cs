using System;
using System.Linq;

namespace Queries_LINQ_to_Entities
{
    class Program
    {
        // Tu v prikldoch je zobrazene jak mozeme vlozit viac prikazov 
        static void Main(string[] args)
        {
            #region Union

            //Union - je moznost vlozenie dalsieho prikazu where ne ze and aleob or dslova nnovy prikaza select sa prida s podminku


            using (Context db = new Context())
            {
                var phones = db.Phones.Where(p => p.Price < 50000)
                    .Union(db.Phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            using (Context db = new Context())
            {
                var result = db.Phones.Select(p => new { Name = p.Name })
                    .Union(db.Companies.Select(c => new { Name = c.Name }));

                foreach (var item in result)
                    Console.WriteLine(item.Name);
            }

            #endregion

            #region Intersect

            //Intersect - Tie dva select + ti najde to ca sa zhoduje 

            using (Context db = new Context())
            {
                var phones = db.Phones.Where(p => p.Price < 50000)
                    .Intersect(db.Phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            #endregion

            #region Except

            //Except - tu je zas opacne najdi rozdiel ktory sa nezhoduje 


            using (Context db = new Context())
            {
                var selector1 = db.Phones.Where(p => p.Price < 50000); // Samsung Galaxy S7, iPhone 6S
                var selector2 = db.Phones.Where(p => p.Name.Contains("Samsung")); // Samsung Galaxy S8, Samsung Galaxy S7
                var phones = selector1.Except(selector2); // результат -  iPhone 6S

                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            #endregion
        }
    }
}
