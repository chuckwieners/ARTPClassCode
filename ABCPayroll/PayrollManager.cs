using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCPayroll
{
    public class PayrollManager //:Object
    {
        //fields
        //properties
        //ctors - default no arg ctor
        //methods

        //Process paycheck
        //Target is a strong convention for an interface variable name.  It represents
        //the object that is going to be the recipient (target) of the action being performed.
        public static void ProcessPaycheck(IPayable target)
        {
            //Updated the method to be static so that we do not have to create the PM instance
            //in to call the methods.  It is a slight performance gain, but depending on the length
            //of the routine, it could be an important gain. The only reason we create(d) the PM instance
            //was to call the methods below.  As static methods, they can be called from the class level.

            /*
             *  To process a paycheck, we must ensure that the object passed to the method
             *  implements the appropriate interface methods.  We KNOW that the Employee
             *  class does this, but to get ANY object that implements the interface, we
             *  can create an instance of that interface as a parameter required to execute
             *  the method.  That instance is the recipient of the action, hence the name "target".
             *  
             *  Simulate the issuance of a paycheck by outputting to the console. We would really
             *  need to process the values and send them to a 3rd party that handles payroll
             *  like ADP, Paychex, etc.  You could also send the information to some 3rd party API
             *  that handles printing paychecks locally, like small biz applications such as QuickBooks
             *  (Intuit)
             *  
             *  You would need to code TO that 3rd party API (see their documentation).
             *  API?: Application Programming Interface - is a set of routines, protocols, and tools for 
             *  building software (web) applications.
             *  
             *  What is our API? .NET (C#.NET)
             *  Free "stack"
             *  L - Linux (Linex OS)
             *  A - Apache (local client Server)
             *  M - MySql (MySql Database)
             *  P - PHP (Front end/server scripting language)
             */

            Console.WriteLine(
                $"A paper check has been issued to {target.GetNameForPaycheck()}.\n" +
                $"The amount paid was: {target.GetPaycheckAmount():c}");
        }

        //Do the direct deposit
        public static void DoDirectDeposit(IDirectDepositable target)
        {
            //Simulate an Electronic Funds Transfer (EFT) to the financial institution by writing to the console.
            Console.WriteLine(
                $"{target.GetNameForPaycheck()} was paid " +
                $"{target.GetPaycheckAmount():c}" +
                $"\nThe funds were transferred to {target.GetBankingInfo()}"
                );
        }

        //ToString()

    }
}
