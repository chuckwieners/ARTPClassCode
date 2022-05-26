using ABCPayroll;
using ARTPLibrary;//Direct access to the classes in the library (dont have to declare with full namespace location)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//before doing this we added a reference for the library to the references of the Executable (solution explorer)

namespace ARTPExecutable
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Person Class Instances commented out AFTER marking the class Abstract
            //Console.WriteLine("Person with Name Business Logic");
            //Person p1 = new Person("C", "Armitage", new DateTime(1925, 1, 1));
            //Console.WriteLine(p1);

            //Console.WriteLine("\nPerson with Name Business Logic - satisfied");
            //Person p2 = new Person("Cushman", "Armitage", new DateTime(1925, 1, 1));
            //Console.WriteLine(p2);
            #endregion

            #region Read Only Example
            ////End users should not be able to update the dob AFTER the creation of the person object
            ////Commented out after setting dob to be readonly
            //p1.DOB = new DateTime(2000, 1, 1);
            //Console.WriteLine("\n" + p1);

            //.Net version of a read only property
            //string s = "something";
            //s.Length = 15;
            #endregion

            #region Employee class instance commented out AFTER marking the class Abstract
            ////Create and output an employee object
            //Employee e = new Employee(111, "Vanessa", "Baxter", new DateTime(1961, 9, 21), "Geologist",
            //    new DateTime(2011, 1, 1), true);
            //Console.WriteLine("\nCreate and output an Employee Object:\n" + e);
            #endregion

            //Create and output an hourly employee object
            HourlyEmployee he = new HourlyEmployee(222, "Kyle", "Anderson",
                new DateTime(1988, 4, 21), "Gopher", new DateTime(2011, 1, 1),
                false, 40, 11.95m);
            Console.WriteLine("\nCreate and Output an Hourly Employee object.\n" + he);

            //Create and output a salaried employee object
            SalariedEmployee se = new SalariedEmployee(333, "Chuck", "Larabee",
                new DateTime(1967, 7, 16), "Security Expert",
                new DateTime(2011, 1, 1), true, 52000);
            Console.WriteLine("\nCreate and Output an Salaried Employee object.\n" + se);

            //Create and output a manager object
            Manager m = new Manager(444, "Ed", "Alzate",
                new DateTime(1936, 12, 22), "Owner",
                new DateTime(2011, 1, 1), true, 150000, 25000);
            Console.WriteLine("\nCreate and Output a Manager object.\n" + m);

            //Create an instance of the PayrollManager so that the methods can be called
            //PayrollManager pm = new PayrollManager();--Commented out after marking the methods Static in the PM class
            Console.WriteLine("\n*****************HourlyEmployee Paper Check*****************");
            //pm.ProcessPaycheck(he);
            PayrollManager.ProcessPaycheck(he);

            Console.WriteLine("\n****************SalariedEmployee Direct Deposit*****************");
            //pm.DoDirectDeposit(se);
            PayrollManager.DoDirectDeposit(se);

            Console.WriteLine("\n*****************Manager Paper Check*****************");
            //pm.ProcessPaycheck(m);
            PayrollManager.ProcessPaycheck(m);

            //Things to check when testing payroll applications:
            //Test EACH calculation
            //In our scenario 
            //Hourly, Salaried, Manager calculations.  Additionally, other fields
            //(we did not add,but noted in the employee class) need to be tested to ensure
            //that the calculation is correct for EVERY variable that could be subtracted as well
            //as EACH combination of those variables.

            //*******************Polymorphism*****************
            //Allows for the assignment of ANY subclass object to a superclass variable.
            //We may not get all of the functionality based on the container, but we CAN get to
            //the functionlity with a cast if necessary.

            object o = m;
            Console.WriteLine("\nOutput the Manager object as on object of type Object");
            Console.WriteLine(o);
            //what will the console show?: Manager ToString() or Object ToString()
            //Manager Overrides its base class toString, so we do see the Manager toString()

            //write out the first name of the manager stored in the o variable
            //to use the o variable (assume the Manager m variable exists in another file) you must cast it to its "strong" type
            //(unbox it)
            Manager m2 = (Manager)o;
            Console.WriteLine("\nDisplay the Manager's first name from the o variable");
            Console.WriteLine(m2.FirstName);

            //Faster and more elegant code to perform the same operation using an explicit,inline cast
            Console.WriteLine("\nSee the first name from the o variable - Explicit inline cast");
            Console.WriteLine(((Manager)o).FirstName);

            //It would be cumbersome to create lists of employees by their dat atype
            //then try to either add all of those lists together or to pay each list separately.
            //It is much easier and more flexible if we have a single defined type by which we
            //can group all employees
            //this is collection initialization syntax
            List<Employee> employees = new List<Employee>() { he, se, m };

            //Write out the employee list
            Console.WriteLine("\n*****Employees*****");
            foreach (Employee x in employees)
            {
                Console.WriteLine($"{x.FirstName} {x.LastName}");
            }
            //Abstract classes do NOT allow for new instances to be created.
            //In order for a new instance to be created the NEW keyword must be used.
            //Holding variables are allowed with abstract classes.

            //Loop thru the list of employees and pay them DD/PC based on their IDD boolean flag
            Console.WriteLine("\nPay Each employee in the collection");
            foreach (Employee x in employees)
            {
                if (x.IsDirectDeposit)//if(x.IsDirectDeposit == true) - less elegant but functional.
                {
                    PayrollManager.DoDirectDeposit(x);
                }
                else //IDD is false
                {
                    PayrollManager.ProcessPaycheck(x);
                }
                Console.WriteLine("***");
            }
            //How many different implementations do we have for the Manager Object
            //3, 5, ???
            //Manager
            //SalariedEmployee
            //Employee
            //Person
            //Object
            //----IS A ^ --- IS A KIND OF v----/
            //IPayable
            //IDirectDeposit
            //1 object with 7 different implementations

            #region Module 6L Collections Lab - Instructor

            Product p1 = new Product(111, "W1B", "Basic Widget",
            "The simplest widget offered.", 1.11M);

            Product p2 = new Product(222, "W2LM", "Lower Middle Widget",
            "Not the simplest widget offered.", 2.22M);

            Product p3 = new Product(333, "W3M", "Mediocre Widget",
            "The middlest widget offered.", 3.33M);

            Product p4 = new Product(444, "W4UM", "Upper Middle Widget",
            "Better than mediocre, but not the best widget offered.", 4.44M);

            Product p5 = new Product(555, "W5SD", "Super Duper Widget",
            "The BEST widget offered.", 5.55M);

            //------------------------ List ------------------------
            Console.WriteLine("\n\n*******Unordered Widgets*******\n");

            List<Product> products = new List<Product>() { p2, p3, p5, p1, p4 };

            foreach (Product p in products)
            {
                Console.WriteLine(p
                    + "\n*****************************************************");
            }
            #region Other Collections of Widgets
            #region ArrayList
            //------------------------ ArrayList ------------------------
            //Console.WriteLine("*******ArrayList*******\n");

            //ArrayList pal = new ArrayList() { p2, p5, p3, p1, p4 };

            //foreach (object p in pal)
            ////foreach (Product p in pal)
            //{
            //    Console.WriteLine((Product)p);
            //}
            #endregion

            #region Dictionary
            //------------------------ Dictionary ------------------------
            //Console.WriteLine("*******Dictionary<int, Product>*******\n");

            //Dictionary<int, Product> productDictionary =
            //    new Dictionary<int, Product>()
            //{
            //    { p1.ID, p1 },
            //    { p2.ID, p2 },
            //    { p3.ID, p3 },
            //    { p4.ID, p4 },
            //    { p5.ID, p5 }
            //};

            //foreach (KeyValuePair<int, Product> kvp in productDictionary)
            //{
            //    Console.WriteLine(kvp);
            //}
            #endregion

            #region Stack
            //------------------------ Stack ------------------------
            //Console.WriteLine("*******Stack*******\n");

            //Stack<Product> stackOfProducts = new Stack<Product>();
            //stackOfProducts.Push(p1);
            //stackOfProducts.Push(p3);
            //stackOfProducts.Push(p2);
            //stackOfProducts.Push(p4);
            //stackOfProducts.Push(p5);

            //int count = stackOfProducts.Count;
            //for (int i = 0; i < count; i++)
            //{
            //    Console.WriteLine(stackOfProducts.Peek());
            //    stackOfProducts.Pop();
            //}
            #endregion
            #endregion
            #endregion

            #region Intro To Linq - instructor
            //Linq (Language INtegrated Query) - allows for the querying of multiple sources of data and retrieving only
            //records or bojects that we desire.  The most used implementaion of linq in C# is to order the results when 
            //iterating through a collection.  It simplifies the existing c# process of calling the Sort() on the different
            //collection types. Each collection that has a Sort() available requires the implementation of AT LEAST one 
            //interface and interface method.  It is a slow and cumbersome process to code and even slower in execution.

            //output all products highest price first
            //method syntax
            //var [identifier] = [collection].[operation([otf] => [otf].[propertyToPerformEvaluation] [operator] [valueToCompare])]
            //otf
            var expensiveMethod = products.OrderByDescending(p => p.Price);

            Console.WriteLine("\n\nProduct Name and Price - Most Expensive first - Method Syntax");
            foreach (var p in expensiveMethod)
            {
                Console.WriteLine(p.Name + " - " + $"{p.Price:c}");
            }

            //Shorthand for C#
            Console.WriteLine("\n\nProduct Name and Price - Most Expensive first - Method Syntax - Shorthand");
            //with LinqToObject (console app) or LinqToEF (inside the view - out of convention)
            //WHy limit the amount of queries entered directly into the view in an MVC App?
            //The view has ONE job - as the UI it is there to collect/display data.  By entering our query into
            //a view, have violated the Separation of Concerns (SOC) aspect of MVC.
            //SOLID - programming principle - S - Single Responsibility
            foreach (var p in products.OrderByDescending(p => p.Price))
            {
                Console.WriteLine(p.Name + " - " + $"{p.Price:c}");
            }

            //syntax  example
            //var [identifier] = from [otf] in [collection]
            //                   where [condition]
            //                   orderby [otf.property] //descending (if needed, ascending is the default)
            //                   select [desiredValue]
            //ALL keyword queries MUST end with a select.

            //same query using Keyword syntax
            var expensiveKW = from p in products
                              orderby p.Price descending
                              select p;

            Console.WriteLine("\n\nProduct Name and Price - Most Expensive first - Keyword Syntax");
            foreach (var p in expensiveKW)
            {
                Console.WriteLine(p.Name + " - " + $"{p.Price:c}");
            }


            #endregion
        }
    }
}
