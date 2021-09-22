using System;
using System.Collections.Generic;
using System.Linq;
using DataContext;

namespace _000_IEnumerableAndIQueryable
{
    class Program
    {
        // Metody rozšíření LINQ mohou vrátit dva objekty: IEnumerable a IQueryable.
        // Interface IEnumerable se nachází v prostoru jmen System.Collections.
        // Interface IQueryable se nachází v prostoru jmen System.Linq.
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                IEnumerable<Phone> phone = db.Phones.ToList();//Neodlozena ToList vraca IEnumerable // V tomto pripade cekam co sa na vratia vsetky data
                Console.ReadKey();
                phone = phone.Where(p => p.Id > 3);
                Console.ReadKey();

                Console.WriteLine(phone);
                Console.ReadKey();

                foreach (var item in phone)
                {
                    Console.WriteLine("{0}.{1}", item.Id, item.Name);
                }

                Console.WriteLine("---------------------------------");
                Console.ReadKey();

                //IQueryable priamy prikaz do dabataze 
                IQueryable<Phone> phone1 = db.Phones;//ODLOZENA  VRACA IQueryable // V tomto pripade necekame ked sa nam vratia data. Cekam az pri jejich zobrazeni viz dole 
                Console.ReadKey();

                phone1 = phone1.Where(p => p.Id > 3);
                Console.ReadKey();

                Console.WriteLine(phone1);
                Console.ReadKey();

                foreach (var item in phone1)
                {
                    Console.WriteLine("{0}.{1}", item.Id, item.Name); // TU cekame
                }
                
            }
        }
    }
}
