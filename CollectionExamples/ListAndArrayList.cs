using ARTPLibrary;//Access to all employee classes
using System;
using System.Collections;//Non-Generic (untyped) collections (.net 1.1)
using System.Collections.Generic;//Typed Collections (2.0+)
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollectionExamples
{
    class ListAndArrayList
    {
        static void Main(string[] args)
        {
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

            #region ArrayList Notes
            /*
            * Not fixed in length, things can be added or removed from
            * this collection, as opposed to the various arrays we
            * have used in the past. (string[],int[],etc.) are fixed in length
            * and are TYPED (strongly typed) collections, whereas the
            * Arraylist is UNTYPED (everything goes in as an object and out
            * as an object). If we want specific properties output as opposed
            * to the entire object, we will have to cast to its STRONG type.
            *
            * All collections can be iterated through.
            * Foreach/for loops can be used to cycle through the items.
            * Each of these collections IMPLEMENTS the interface IEnumerable or
            * IEnumerator, (or both) which sets the rules for iteration.
            * We can add, remove, find the index of items (even in non-indexed collections),
            * we can CLEAR the entire collection as well.
            * Although some of the names may differ, they will provide similar functionality.
            */
            #endregion

            //initialize the ArrayList
            //Collection Initialization syntax
            ArrayList al = new ArrayList() { he1, he2, he3, he4, he5 };

            //All collections have the count property.  If you are using Linq syntax, you cannot use the count property
            //you must call the Count() - belongs to Linq.
            Console.WriteLine($"Count of all employees: {al.Count}");

            //The most efficient way to clear a collection (you would do this after performing all actions on the contained objects)
            //is to call the Clear().
            al.Clear();

            Console.WriteLine($"\nCount after clearing all objects: {al.Count}");
            //clear removes the object from the collection, but the variable and object still exist
            Console.WriteLine($"\nShow Employee 3: {he3.FirstName}");

            //manually add objects to the collection (alternative to the initialization syntax) - Add()
            //this is an indexed collection
            al.Add(he1);//0
            al.Add(he2);//1
            al.Add(he3);//2 - Indexed Value
            al.Add(he4);//3
            al.Add(he5);//4

            //remove an object from the collection by its variable name
            al.Remove(he4);

            //count
            Console.WriteLine($"\nCount after re-adding employees and removing he4: {al.Count}");
            Console.WriteLine($"What is the index value of Employee 5?: {al.IndexOf(he5)}");//3
            //When an object is removed, all objects (below) it move up one spot in the collection

            //remove an object from the collection by index value
            al.RemoveAt(3);//<--Must be a numeric value.  To remove by the variable name, use the Remove()

            Console.WriteLine("Count: " + al.Count + " Index of Employee 5 (removed): " + al.IndexOf(he5));
            //objects not in the collection will result in an index value of -1.

            //Mini Quiz
            //What is the structure of a for loop?
            //for(initializer;condition;update)
            //{
            //  Body/Scope - DoStuff()
            //}

            //Non-terminating loop
            //for (; ; )
            //{
            //    Console.Write("x ");
            //}

            //add the 2 employees back to the collection
            al.Add(he4);
            al.Add(he5);

            #region MiniLab For Loop
            //Remove all objects from the arraylist using a for loop
            //at the end do a count to verify there are 0 objects left in the collection
            //Remove() or RemoveAt() that you can use at your discretion.
            //15 minutes - green check when complete

            //mini-lab: empty the al collection using a for loop, then cw the count
            //most commmon solution
            //for (int i = 0; i < al.Count - 1; i++)
            //{
            //    al.RemoveAt(i);
            //}
            //Console.WriteLine($"Total Number of Employees is NOW: {al.Count}");//3

            ////working solution 1 - CW
            //for (int i = al.Count - 1; i > -1; i--)
            //{
            //    al.RemoveAt(i);
            //}
            //Console.WriteLine($"Total Number of Employees: {al.Count}");//0

            ////working solution 2 - CW
            //for (int i = al.Count; i > 0; i--)
            //{
            //    al.Remove(al[i - 1]);
            //    //al.RemoveAt(i-1);
            //}
            //Console.WriteLine($"\n\nMini Lab End: Number of employees: {al.Count}");

            //Working Solution 3 - CW
            for (int i = al.Count - 1; i >= 0; i--)
            {
                al.RemoveAt(i);
            }
            Console.WriteLine($"Total Number of Employees: {al.Count}");//0

            //Even though the for loop works to clear the collection, it is extremely inefficient.
            //ALL collection have access to the Clear().  Clear() is the easiest and most efficient way
            //to empty a collection.
            //This exercise was presented to get you working with the for loop again.
            #endregion

            #region Example where no objects exist for items in the collection (created on the fly)
            //If you are building a collection for ONE time use AND you do not need to maintain the objects collected,
            //you could use the following code
            List<HourlyEmployee> emps = new List<HourlyEmployee>()
            {
                new HourlyEmployee(777,"Mike","Baxter",new DateTime(1963,06,03), "Marketing Genius",
                    new DateTime(2011,1,1), true, 40,40.25M),

                new HourlyEmployee(888,"Christine","Baxter",new DateTime(1984,08,27), "Restaurant Manager",
                    new DateTime(2011,1,1), true, 40,30.15M)
            };

            Console.WriteLine("\nHourly Employees on the fly - first names");
            foreach (HourlyEmployee e in emps)
            {
                Console.WriteLine(e.FirstName);
            }
            //These objects are ONLY avaialble as part of the List/arraylist
            //there is no "Handle" or variable name that represents these objects
            //If we want to manipulate them individually, we need to them by their indexed value

            //Output the first employee object to the console
            Console.WriteLine("\nFirst Employee:\n" + emps[0]);
            Console.WriteLine("\nFirst Name Only: " + emps[0].FirstName);
            //Because everything in this Typed List is an hourlyEmployee, we have direct access to the properties w/o a cast.

            //Empty the collection
            emps.Clear();
            //no longer have access to ANY of the objects that were created on the fly.
            //Console.WriteLine("\nEmployee at the index of 0: " + emps[0]);
            //Throws Argument out of range - Index out of Range Exception.
            #endregion

            //The minilab emptied all of the objects from the al collection.
            //if you attempt to call on an indexed value in the arraylist that does not exist...what will happen?
            Console.WriteLine("\nArrayList Again - output the indexOf he3");

            Console.WriteLine("What is the index of he3?: " + al.IndexOf(he3));//-1
            //This is different than the last example (in the region above).  This example is attempting
            //to determine the INDEX OF a specific object, where we were trying to RETRIEVE the OBJECT by a specific
            //index previously.

            //Type Safety of Non-Generic Collections - there is none.
            //Another collection initialization where the variables exist (reuse al collection)
            al = new ArrayList() { he1, he2, he3, he4, he5 };
            al.Add(117);
            al.Insert(0, 1);//Allows you to insert an object into a specific index of this collection.

            //New collection to hold invalid cast objects
            //Use an arraylist to collect all of the invalid cast objects as we do not know their type.
            ArrayList invalidCast = new ArrayList();
            Console.WriteLine("\nNew Arraylist with numeric values AND HourlyEmployees");
            foreach (object o in al)
            {
                #region Output the entire object
                //Console.WriteLine(o + "\n----------------------------");
                #endregion

                #region Output Specific Properties - Failure
                //Console.WriteLine(((HourlyEmployee)o).FirstName);
                //This code fails for invalid cast
                //This is the downside of working with Untyped collections, we dont know
                //what data types MIGHT be collected.
                #endregion

                #region If/Else work around for inline cast of objects in an untyped collection
                //if/else logic processes all employee objects but OMITS the invalid objects.
                //With the if/else, we are not aware of other objects in the collection until
                //we either output the ENTIRE non-employee object OR do a count of the collection.
                //If we had not declared the arraylist directly above (and didnt know what was being collected)
                //this would constitute "potentially dangerous code".
                //if (o.GetType() == typeof(HourlyEmployee))
                //{
                //    Console.WriteLine($"First Name: {((HourlyEmployee)o).FirstName}");
                //}
                //else
                //{
                //    Console.WriteLine(o);
                //}
                #endregion

                #region Proper Handling of Unknown values (try/catch)
                //To prepare for this activity create a new collection to hold the invalid cast objects (outside of the foreach)
                try
                {
                    Console.WriteLine(((HourlyEmployee)o).FirstName);
                }
                catch (InvalidCastException ice)
                {
                    //add it to invalidcast collection
                    invalidCast.Add(o);
                    Console.WriteLine(o + " " + ice.Message);
                }
                //there are no resources to return to the runtime, so no Finally Block is needed.
                #endregion
            }
            Console.WriteLine($"\nThere were {invalidCast.Count} objects that could not be cast to an HourlyEmployee");
            Console.WriteLine($"Total Count of objects in the collection: {al.Count}");

            /*********************************List<T>*************************************************/
            /*Same methods/properties are available as the ArrayList
             * Add(), Remove(), RemoveAt(), Clear, Insert(), IndexOf(), etc
             * 
             * When we create a typed list we KNOW what data type is being collected.
             * We can use that data type as the holding variable in the foreach (or we can infer the type with var)
             * Strongly typed collections do NOT require a cast to get to specific properties.
             * 
             * ALL Generic Collections are type safe and compiler checked/enforced.
             */

            //int number = 10;
            List<HourlyEmployee> employees = new List<HourlyEmployee>() { he1, he2, he3, he4, he5/*, number */};
            //The collection is compiler checked for proper values
            //We used initialization, Add() is avaialble as well.

            //Looping/iterating through the list
            //we can safely declare the holding variable of type HourlyEmployee
            //because the compiler has assured us that ONLY objects of that type will be collected.

            Console.WriteLine("\n\n**************List<T> Examples**************");
            //foreach (HourlyEmployee e in employees)
            //var infers the type based on assignment or context
            //Because employees is a Typed List of hourlyEmployee objects,
            //any object in that collection will be inferred to be of type HourlyEmployee
            foreach(var e in employees)
            {
                Console.WriteLine($"{e.DOB:d}");
            }
            

            //Other methods that were seen in ArrayList (IndexOf, Remove, RemoveAt) are valid and opertate the same way.

            //clear collections
            al.Clear();
            employees.Clear();

        }
    }
}
