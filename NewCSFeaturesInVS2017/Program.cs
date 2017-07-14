//// Based on a youtube video by IAmTimCorey
/* If a variable in one feature is declared in another, comment out the other sections
by selecting lines of code and pressing ctr+K,C. To uncomment, press ctr+K,U */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCSFeaturesInVS2017
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Feature #1: Inline declaration of out variables
            Console.Write("What is your age: ");
            string ageText = Console.ReadLine();

            bool isValidAge = int.TryParse(ageText, out int age);

            Console.WriteLine($"Your age is { age }.");
            Console.ReadKey();

            //// Feature #2: Pattern Matching
            // Pattern Matching is testing a variable to determine its type and taking different actions
            // based on that type.
            string ageFromConsole = "21";
            int ageFromDatabase = 84;

            // Type ageVal = ageFromConsole and ageVal = ageFromDatabase
            object ageVal = ageFromConsole;

            /* If statement: (Is ageVal an int? If true, then assign the new age variable as the value.) OR...
            [(Is ageVal a string? If true, then assign the new ageText variable as the ageVal value) AND...
            (Can ageText be read as an integer? If true, then assign the new age variable as the integer)]
            Concisely: Is ageVal a number or is it a string with a number in it? */
            if (ageVal is int age || (ageVal is string ageText && int.TryParse(ageText, out age)))
            {
                Console.WriteLine($"Your age is { age }.");
            }
            else
            {
                Console.WriteLine("We do not know your age.");
            }
            Console.ReadKey();

            //// Feature #3: Powerful Switch Statements
            /* Switch statements used to be limited to numeric types and the string type. Those restrictions have been
            removed and now we can use pattern matching using a switch statement. Another improvement in switch statements
            is that order is important. In this example, the fourth case catches Customers that do not match the third case.
      
            Try not to use "object" in code as used in this example */
            Employee emp1 = new Employee { FirstName = "Joe", LastName = "Smith", IsManager = false, YearsWorked = 2 };
            Employee emp2 = new Employee { FirstName = "Sandra", LastName = "Jones", IsManager = true, YearsWorked = 28 };
            Customer cust1 = new Customer { FirstName = "Tim", LastName = "Corey", TotalDollarsSpent = 2342.15M }; // M = decimal and not double. Think M for money
            Customer cust2 = new Customer { FirstName = "Delana", LastName = "Greenback", TotalDollarsSpent = 558M };
            List<object> people = new List<object>() { emp1, emp2, cust1, cust2 };

            foreach (var p in people)
            {
                switch (p)
                {
                    case Employee e when (e.IsManager == false):
                        Console.WriteLine($"{e.FirstName} is a good employee.");
                        break;
                    case Employee e when (e.IsManager):
                        Console.WriteLine($"{e.FirstName} runs this company.");
                        break;
                    case Customer c when (c.TotalDollarsSpent > 1000):
                        Console.WriteLine($"{c.FirstName} is a loyal customer.");
                        break;
                    case Customer c:
                        Console.WriteLine($"{c.FirstName} needs to spend more money.");
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();

            //// Feature #4: Throw in expression (in-line)
            // Removes the need for clunky error handles like: 
            // if (ceo == null)
            // {
            //      throw new Exception("There was a problem finding a manager.");
            // }

            Employee emp1 = new Employee { FirstName = "Joe", LastName = "Smith", IsManager = false, YearsWorked = 2 };
            Employee emp2 = new Employee { FirstName = "Sandra", LastName = "Jones", IsManager = false, YearsWorked = 28 };
            List<Employee> people = new List<Employee>() { emp1, emp2 };

            // The ceo is the first person who has IsManager = true. FirstOrDefault assigns null to ceo if IsManager is false for everyone.
            Employee ceo = people.Where(x => x.IsManager).FirstOrDefault() ?? throw new Exception("There was a problem finding a manager.");
            Console.WriteLine($"The ceo is { ceo.FirstName }.");

            //// Feature #5: Tuples
            // Enables methods to return more than one return values without having to create a class object and return an instance
            // of the object.
            // Tip: When returning values from a method, choose meaningful variable names to distinguish the variables

            //var name = SplitName("Tim Corey");
            //Console.WriteLine($"The first name is { name.firstName } and the last name is { name.lastName }.");

            //Console.ReadLine();
        }

        //public static (string firstName, string lastName) SplitName(string fullName)
        //{
        //    string[] vals = fullName.Split(' ');

        //    return (vals[0], vals[1]);
        //}
    }
}
