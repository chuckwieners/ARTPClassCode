using ARTPLibrary;//access to employee classes
using System;
using System.Collections;//hashtable
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionExamples
{
    class HashtableAndDictionary
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

            #region Hashtable and Dictionary Notes
            /* Hashtable(key,value) (non-generic) and Dictionary<Tkey,Tval> (generic collection)
             * are key value pair (reference) collections.  The collections are best suited for 
             * LARGE collections where the order of entry and/or the indexed value do not matter.
             * 
             * For the KEY in the pair, you should use a property that has a 
             * unique value (much like we think of a PK in a table in SQL).
             * Usually the KEY is the ID of the object and the value is the object itself.
             * 
             * Collection Initialization is available.
             * Looping through the Hashtable the holding type is DictionaryEntry - both the key and the 
             * value go IN of type object.
             * 
             * Looping throughout the Dictionary the holding type KeyValuePair - both the key and the value
             * are strongly typed in this collection.
             */
            #endregion

            //collection initialization
            Hashtable empsHT = new Hashtable()
            {
                //{key(unique),value(entire object)},
                { he1.ID, he1},
                { he2.ID, he2},
                { he3.ID, he3},
                { he4.ID, he4},
            };
            //add() is available for this collection
            empsHT.Add(he5.ID, he5);

            //loop/iterate thru the collection
            foreach (DictionaryEntry entry in empsHT)
            {
                Console.WriteLine(entry.Value);
                Console.WriteLine("****************");
            }
            //with the hashtable and the dictionary, we cannot guarantee the order of output without ordering it manually.
            //With referenced collections we cannot guarantee the order of the output
            //without manual intervention.  Sort() - Implement IComparable in the class
            //being collected (HourlyEmployee) and satisfy the CompareTo() which builds
            //the logic for the sort order. - Cumbersome and time consuming way to sort.
            //The other way to intervene and sort is by using the Linq OrderBy extension 
            //method. (will see later in code)

            //Cannot duplicate ids in the collection (keys)
            //empsHT.Add(he1.ID,he1);
            //fails for Item already added - system.Argument exception
            //Question to ask yourself when you see this exception: Am i trying to add an object that already exists in the collection
            //OR is the ID value in my data incorrect?

            //mini lab
            //Write a foreach loop that iterates through the hashtable and ONLY ouput the first name of the employee
            //Challenge - it CAN be done in 1 line of code inside the foreach.

            Console.WriteLine("\nMini Lab: Employee First Names Only");
            foreach (DictionaryEntry entry in empsHT)
            {
                //Long hand
                //HourlyEmployee e = (HourlyEmployee)entry.Value;
                //Console.WriteLine(e.FirstName);

                //Challenge:
                //Short hand - Explicit inline cast
                Console.WriteLine(((HourlyEmployee)entry.Value).FirstName);
            }

            //Remove()
            empsHT.Remove(he5.ID);//555555

            Console.WriteLine("\nDictionary results after removing employee 5");
            foreach (DictionaryEntry entry in empsHT)
            {
                Console.WriteLine(((HourlyEmployee)entry.Value).FirstName);
            }

            //attempt to access an ID and output the value when the id has been removed
            Console.WriteLine("\nSingle object retrived by id without a check");
            Console.WriteLine(empsHT[he5.ID]);//no compiler error, no exception. blank response, null at that location

            //access a specific property of an object that does not exist in the collection
            //Console.WriteLine(((HourlyEmployee)empsHT[he5.ID]).FirstName);
            //Null Reference Exception: Object reference NOT set to an instance of an object
            //this is triggered because of the cast and attempt to retrieve the specific property

            //Contains() available in other collections evolves to ContainsKey() or ContainsValue(). The ContainsKey()
            //is more commonly used.  It should be used before manipulating any object in the hashtable.
            Console.WriteLine("\nRetrieve a value after checking that it is in the collection");
            if (empsHT.ContainsKey(he1.ID))
            {
                Console.WriteLine(((HourlyEmployee)empsHT[he1.ID]).FirstName);
            }
            else
            {
                Console.WriteLine("The requested Employee ID is invalid.");
            }
            //clear
            empsHT.Clear();
            /***************************************Dictionary<Tkey,Tval>**************************************/
            //initialization syntax
            Dictionary<int, HourlyEmployee> emps = new Dictionary<int, HourlyEmployee>()
            {
                { he1.ID, he1 },
                { he2.ID, he2 },
                { he3.ID, he3 },
                { he4.ID, he4 }
            };
            //emps.Add(he1.ID, he1); argument exception for duplicate key
            //emps.Add("House", 111); - compiler err for type safety.
            Console.WriteLine("\nIterate through the Dictionary<Tkey,Tval>");
            //foreach (KeyValuePair<int, HourlyEmployee> kvp in emps)
            //This is a good use of var as it saves some coding time AND the collection
            //is declared in the same scope (this class).
            //when you hover over the variable, you can see the inferred type is correct.
            foreach(var kvp in emps)
            {
                Console.WriteLine(kvp.Value.FirstName);
            }
            //other methods discussed previously apply to dictionary

            //clear the dictionary
            emps.Clear();

        }
    }
}
