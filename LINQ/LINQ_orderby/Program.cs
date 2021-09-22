using System;
using System.Collections.Generic;
using System.Linq;

// orderby -slúži na zoradenie (poradie) výsledku dotazu.

namespace LINQ
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Nationality { get; set; }
    }

    class Program
    {
        static void Main()
        {

            var employees = new List<Employee>
            {
                new Employee {LastName = "Ivanov", FirstName = "Ivan", Nationality = "Russian"},
                new Employee {LastName = "Andreev", FirstName = "Andrew", Nationality = "Ukrainian"},
                new Employee {LastName = "Petrov", FirstName = "Petr", Nationality = "American"}
            };

            
            var query = from emp in employees
                        orderby emp.Nationality ascending,
                        emp.LastName descending, 
                        emp.FirstName descending // - ascending.
                        select emp;

            foreach (var person in query)
                Console.WriteLine("{0}, \t{1}, \t{2}", person.LastName, person.FirstName, person.Nationality);

            // Delay.
            Console.ReadKey();
        }
    }
}
