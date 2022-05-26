using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTPLibrary;//access to all employee classes

namespace CollectionExamples
{
    class StackAndQueue
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

            #region Sequential Collection Notes
            /*
            * Stack and Queue are sequential collections
            * Queue is a FIFO (First In First Out)
            * Queue could be used for:
            * -Call Center software
            * -Tickets (as long as severity is not the determining
            * factor in response)
            * -Order fulfillment
            * -All of these should be done in the order they
            * were received, that is the intent of Queue
            * collection.
            *
            * -Enqueue() adds an item
            * -Dequeue() removes the item at the front of the queue (line)
            * -Peek() views the item at the front of the queue (line) WITHOUT
            * removing it.
            *
            * Stack is a LIFO (Last In First Out) collection
            * Stack could be used for:
            * -Undo functionality (ctrl+z)
            * -Back Button (browser)
            *
            * -Push() adds an item
            * -Pop() removes the item at the top of stack
            * -Peek() views the item at the top of the stack WITHOUT removing it.
            *
            * Because the order of entry of each of the items
            * for these collections is important, there is NO
            * initialization syntax.
            */
            #endregion

            /**************STACK*********************/
            //Generic and non generic stack function exactly the same except for typed vs object based.
            Stack<Employee> empStack = new Stack<Employee>();
            //no initialization syntax
            empStack.Push(he4);
            empStack.Push(he1);
            empStack.Push(he2);

            //view the top of the stack
            Console.WriteLine(empStack.Peek());//he2
            Console.WriteLine(empStack.Pop());//he2
            Console.WriteLine(empStack.Peek());//he1

            //still have access to the clear()
            empStack.Clear();

            /*******************QUEUE***************/
            //used whenever processing should occur by the order of entry
            Queue<HourlyEmployee> qEmps = new Queue<HourlyEmployee>();
            qEmps.Enqueue(he3);
            qEmps.Enqueue(he1);
            qEmps.Enqueue(he2);

            Console.WriteLine("\n\nEmployee Queue Results");
            Console.WriteLine(qEmps.Peek());//he3
            Console.WriteLine(qEmps.Dequeue());//he3
            Console.WriteLine(qEmps.Peek()); //he1

            //clear the collection
            qEmps.Clear();

            // The TRICKERY of some exams with Stack and Queue
            int Five = 1;
            int Four = 2;
            int Three = 4;
            int Two = 3;
            int One = 5;

            Queue<int> q = new Queue<int>();
            q.Enqueue(One); //5
            q.Enqueue(Two); //3
            q.Enqueue(Five); //1
            q.Enqueue(Three); //4
            q.Enqueue(Four); //2

            Console.WriteLine("\n\nQueue Results");

            Console.WriteLine(q.Peek()); // Item: One | Value: 5

        }
    }
}
