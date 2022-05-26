using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTPLibrary;//access to Employee classes

namespace LinqReviewConsole
{
    class Student
    {
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public DateTime StartDate { get; set; }
    }
    class Program
    {
        //This is a review of the MVC2 IntroToLinq Controller and View Set in MVC2EFSecured
        static void Main(string[] args)
        {
            #region LinqNotes
            /*****************LINQ Information************************
            * Linq is the Language INtegrated Query
            * Linq is a Namespace in C# that provides extension methods for 
            * querying all sorts of data structures.
            * You need to add the appropriate structure to your data layer/application 
            * to be able to use linq with that source of data. Each one of these
            * types is referred to by LinqTo[DataStoreType] (LinqToObject,LinqToEF,etc)
            * 
            * Linq was part of a LARGE enhancement to .NET and C# in version 3.5
            * Other portions of that enhancement include (but are not limited to):
            * -Inferred Data types: use of the var keyword and the compiler can figure
            * out what data type the variable should be based on its context.
            * 
            * -Object Initializers: Easier shorthand way of setting the state of 
            * a new object. (Assigning values to each of the properties and creating
            * the object) - work and look like Collection Initialization syntax
            * 
            * -Prop[tab][tab] - Automatic Properties: Allow us to easily create 
            * properties in our classes without having to declare a private field
            * and refactor to a public property (as long as there are no biz rules)
            * 
            * -Anonymous Types: Creating new types of objects on the fly without needing
            * to create a class for them. When you see "new { //code here }" that is the
            * creation of an anonymous object. 
            * 
            * -Extension Methods: Adding new behavior to existing classes without having
            * to put that method in the original class file.
            * 
            * -Lambda Expressions: Allow us to pass parameters and an expression for
            * that parameter into the extension methods in .NET (or our own)
            * 
            * -ORD: Object Relational Designer 
            */
            #endregion

            #region Hourly Employee Objects
            //Create 5 hourly employees
            //once done output all 5 employees to the console (1 at time)
            //Once you have tested the employees, you can comment out the console writelines
            //my variable names are going to be he1-he5
            //2 employees with the same LAST Name
            //Add unique data for EACH employee (especially, ID, DOB, Wage information)
            //Green check when complete.
            HourlyEmployee he1 = new HourlyEmployee(111111, "Mike",
                "Baxter", new DateTime(1963, 06, 03), "Marketing Genius",
                new DateTime(2011, 1, 1), true, 40, 40.25M);

            HourlyEmployee he2 = new HourlyEmployee(222222, "Kristin",
                "Baxter", new DateTime(1984, 8, 27), "Restaurant Manager",
                new DateTime(2011, 1, 1), false, 40, 30.15M);

            HourlyEmployee he3 = new HourlyEmployee(333333, "Ed",
                "Alzate", new DateTime(1936, 12, 22), "Business Owner",
                new DateTime(2011, 1, 1), true, 40, 60.25M);

            HourlyEmployee he4 = new HourlyEmployee(444444, "Kyle",
                "Anderson", new DateTime(1988, 4, 21), "Gopher",
                new DateTime(2011, 1, 1), false, 60, 10.50M);

            HourlyEmployee he5 = new HourlyEmployee(555555, "Chuck",
                "Larabee", new DateTime(1967, 7, 16), "Security Manager",
                new DateTime(2011, 1, 1), true, 40, 27.75M);

            //Console.WriteLine("*****Hourly Employees*****");
            //Console.WriteLine(he1 + "\n------------------------------");
            //Console.WriteLine(he2 + "\n------------------------------");
            //Console.WriteLine(he3 + "\n------------------------------");
            //Console.WriteLine(he4 + "\n------------------------------");
            //Console.WriteLine(he5 + "\n------------------------------");
            #endregion

            #region Object Initialization Syntax
            //***********to view the output of the code in this region, comment OUT the Console clear at the
            //Bottom of the region.


            //in order for this syntax to work, you must have a public no arg ctor
            Student s = new Student()
            {
                Name = "Bob Smith",
                GradeLevel = "Sophomore",
                StartDate = new DateTime(2019,1,1)
            };
            //namespace.classname
            Console.WriteLine(s);

            //manually formatted output
            Console.WriteLine("manually formatted output");
            Console.WriteLine($"Name: {s.Name}\tGrade: {s.GradeLevel}\tStart Date: {s.StartDate:d}");

            //inferred typing and Object Initialization 
            var s1 = new Student() { /*Property assignment*/ };

            //practical application
            //when you need a temporary collection of objects to manipulate then discard, you can use
            //the following logic.  These objects will only exist in the collection
            List<Student> students = new List<Student>()
            {
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ },
                new Student(){ /*Property Assignment*/ }
            };
            //this is a combo of collection and object initialization syntax
            //perform the operation on the collection (foreach loop with some activity)
            //clear collection
            students.Clear();
            //empties all references to the collected student objects - student objects are no longer available.

            //create a variable and infer an anonymous type
            var pet = new { Age = 10, Name = "Fluffy" };
            Console.WriteLine(pet);
            Console.WriteLine($"\nFormatted Pet\n{pet.Name} - {pet.Age}");

            //empty the console of all previous output
            Console.Clear();
            #endregion

            //create a typed list of employees
            List<HourlyEmployee> hourlyEmployees = new List<HourlyEmployee>()
            {
                he3,he5,he1,he2,he4
            };

            //minilab
            //NO LINQ Methods or syntax to complete this minilab
            //Show employees that meet the following conditions (show minimum of 2 employees or a max of 3)
            //You will have to check your employee values for this lab
            //2 conditions are HourlyWage and Date of Birth
            //Return employees born BEFORE 1980 wo earn more than $10
            //Foreach loop with If statement branching to output employees that meet your conditions.

            Console.WriteLine("If with multiple conditions");
            foreach (HourlyEmployee e in hourlyEmployees)
            {
                //if statement with multiple conditions
                if (e.HourlyWage > 10 && e.DOB.Year < 1980)
                {
                    Console.WriteLine(
                        $"{e.FirstName} {e.LastName}\tWage: {e.HourlyWage:c}\t" +
                        $"DOB: {e.DOB:d}");
                }
            }
            Console.WriteLine("\nNested IF");
            foreach (HourlyEmployee e in hourlyEmployees)
            {
                //Nested IF
                if (e.HourlyWage > 10)
                {
                    if (e.DOB.Year < 1980)
                    {
                        Console.WriteLine($"{e.FirstName} {e.LastName}\tWage: {e.HourlyWage:c}\t" +
                        $"DOB: {e.DOB:d}");
                    }
                }
            }

            //same results using linq method/lambda
            Console.WriteLine("\nSame Query using Linq - Method");
            var emps = hourlyEmployees.Where(x => x.HourlyWage > 10 && x.DOB.Year < 1980);
            foreach (var e in emps)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName}\tWage: {e.HourlyWage:c}\t" +
                $"DOB: {e.DOB:d}");
            }

            //same results using linq keyword/Query syntax
            Console.WriteLine("\nSame Query using Linq - Keyword");
            var sameKW = from h in hourlyEmployees
                         where h.HourlyWage > 10 &&
                         h.DOB.Year < 1980
                         //select h;
                         select new
                         {
                             //[Aliased Value] = [otf].[Property] [operator] [property/calculation]
                             FullName = h.FirstName + " "  + h.LastName,
                             h.HourlyWage,
                             h.DOB //formatting is NOT allowed here.
                         };


            foreach (var e in sameKW)
            {
                //new writeline for the `a Anonymous object
                Console.WriteLine($"{e.FullName}\tWage: {e.HourlyWage:c}\t" +
                $"DOB: {e.DOB:d}");

                //Previous version returning the ENTIRE object (h)
                //Console.WriteLine($"{e.FirstName} {e.LastName}\tWage: {e.HourlyWage:c}\t" +
                //$"DOB: {e.DOB:d}");
            }

            #region Inferred Typing
            /*
             * Uses the var keyword
             * C# is strongly typed, so unlike the var keyword in javascript
             * the inferred type sticks with the variable throughout its life.
             * You cannot change the data type later as the right side of the equation.
             * You should only var when data type is very apparent
             */

            //This is a good example of when to us var to estavlish a variable.  I dont have 
            //to add a using statement to gain access to the class that i want to create
            //AND I dont have to repeat code to instantiate the variable.  At declaration, we
            //will know EXACTLY what the data type is.
            var binary = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            //some not so good uses
            //var hi = "hello";//string, char[]
            //var z = 1234;//int, short, long, decimal, float
            //var zz = 123.11;//float, double, decimal

            //Because the values can be confusing, these data types should be declared as their strong type,
            //as opposed to being inferred based on their context.  If for some reason we needed to collect these objects
            //in a generic or non generic collection, their type will be important.
            #endregion

            //mini lab
            //Return the employees whose last names are the same.  You can either use method
            //syntax or Keyword syntax - (or mixture of the two). Only output the first and
            //last names.  When you complet the first version, attempt the other syntax to output
            //the same results
            //Think of this like a search for a last name.  you will use it as a condition in
            //a where clause to return the employees that you (already) know have the same last name

            Console.WriteLine("\nLast Names are the Same - Method - MiniLab");
            foreach (var x in hourlyEmployees
            .Where(h => h.LastName.ToLower() == "baxter"))
            //.Where(h => h.LastName.ToLower().StartsWith("baxter")) - Could get other results
            //.Where(h => h.LastName.ToLower().Contains("baxter")) - Could get other results
            {
                Console.WriteLine(x.FirstName + " " + x.LastName);
            }

            Console.WriteLine("\nLast Names are the Same - Keyword WHOLE OBJECT - MiniLab");
            var lastNameSame = from h in hourlyEmployees
                               where h.LastName.ToLower() == "baxter"
                               select h;
            foreach (var x in lastNameSame)
            {
                Console.WriteLine(x.FirstName + " " + x.LastName);
            }

            Console.WriteLine("\nLast Names are the Same - Keyword LIMITED FIELDS - MiniLab");
            var lastNameSameLimited = from h in hourlyEmployees
                                      where h.LastName.ToLower() == "baxter"
                                      select new
                                      {
                                          FullName = h.FirstName + " " + h.LastName
                                      };
            foreach (var x in lastNameSameLimited)
            {
                Console.WriteLine(x.FullName);
            }

            //write a query that returns a single object from the collection
            //2ways you can hold the value
            //1) var like usual
            //2) Hold the results in the strong type.
            //downside of using var is that it is still stored as a collection - meaning you have loop through to get
            //to your one object.

            //whenever we expect a single result, it is best to hold the results of the query in the strong type
            //.single() - signifies the return of 1 object
            HourlyEmployee single = hourlyEmployees.Where(e => e.ID == 111111).Single();
            Console.WriteLine("\nReturn Single Employee");
            Console.WriteLine(single);

            //if it is possible that your query will result in a null value then you want to use
            //FirstOrDefault() - works like single AND allows for a null return
            HourlyEmployee badRequest = hourlyEmployees.Where(e => e.ID == 0).FirstOrDefault();
            Console.WriteLine(badRequest);
            //FirstOrDefault() allows for null results when outputting the entire Object, however
            //if you attempt to access a property (of an object that is null) you will always get a runtime
            //exception.

            //if you know null is possible, code for it
            if (badRequest != null)
            {
                Console.WriteLine(badRequest);
            }
            else
            {
                Console.WriteLine("[-Your request yielded no results-]");
            }


        }
    }
}
