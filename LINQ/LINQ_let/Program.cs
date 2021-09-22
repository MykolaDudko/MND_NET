using System;
using System.Collections.Generic;
using System.Linq;

// let - Predstavuje nový lokálny identifikátor, na ktorý je možné odkazovať vo zvyšku požiadavky.
// Dá sa to chápať ako lokálna premenná, viditeľná iba vo výrazu požiadavky.

namespace LINQ
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var employees = new List<Employee>
            {
                new Employee {LastName = "Ivanov", FirstName = "Ivan"},
                new Employee {LastName = "Andreev", FirstName = "Andrew"},
                new Employee {LastName = "Petrov", FirstName = "Petr"}
            };

            var query = from emp in employees
                        let fullName = emp.FirstName + " " + emp.LastName // let - Novy lokalny indefikator
                        orderby fullName descending
                        select fullName;

            foreach (var person in query)
                Console.WriteLine(person);

            Console.ReadKey();
        }
    }
}
