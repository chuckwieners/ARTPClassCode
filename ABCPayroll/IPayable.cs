using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCPayroll
{

    #region Interface Notes
    /* - This started as a free class when we created the class library.
    * We overtyped the class declaration with the interface keyword.
    * - Any class that wants to use this set of rules MUST Implement
    * the interface at the class level AND satisfy the requirements
    * in the body of the class.
    * - We can implement as many interfaces as are required as opposed
    * to inheritance where we can only Inherit ONE CLASS directly.
    * - Implementation of the interface at the class level creates a
    * CONTRACT that says if you want to be "a kind of" the interface
    * you MUST satisfy these requirements
    * - Interfaces MUST be public.
    * - IsomethingABLE is the naming convention (.NET)
    * - Drop the I for Java (base functional language for Android apps)
    *
    * **************When and How to implement interfaces****************
    * 1. When you have objects that MUST conform to a set of rules/
    * specifications AND there are no other obvious links between
    * the classes, then an interface should be used. This will give
    * you AND other coders a compiler enforced set of rules.
    *
    * 2. Create the interface structure. It is usually more than one
    * interface and should be contained in its own class library.
    *
    * 3. Implement the interface at the lowest level of commonality
    * between the classes (at the class level) AND only classes
    * that MUST conform to these specifications.
    *
    * 4. Once the interface is implemented at the class level, satisfy
    * ALL of the interface requirements inside the body of the class.
    *
    * 5. TEST!
    *
    * 6. Check for any logic errors (inheritance or calculations)
    *
    */
    #endregion

    public interface IPayable
    {
        //BASIC steps for implementing an interface
        //1)Create the Interface (here)
        //2)Implement the interface at the class level (Employee.cs)
        //3)Implement interface members in the class (Employee.cs body - methods)

        //Our interface is going to require methods.  An interface could require specific properties
        //or fields/ctors as needed.

        //Methods
        //Contract:  - method to get the name for the paycheck and one to get the paycheck amount
        string GetNameForPaycheck();
        decimal GetPaycheckAmount();
        //This return type is decimal because all of our pay values are decimals

        //What's missing from the "Standard" method signature?
        //Access Modifier: The contract states that you must have a method called "this" and returns "this".
        //Because the method will be declared/fulfilled in the target class it is the class that dertermines the level
        //of access.
        //Body of the method: Behavior (functionality) is determined by the class.

    }
}
