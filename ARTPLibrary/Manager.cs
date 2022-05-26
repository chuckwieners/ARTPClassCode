using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    //sealed marks the end of the inheritance chain - prevents other coders from inheriting from this class

    //Compiler checked code that prevents inheritance (throws a build error)
    //public class CEO : Manager { }

    public sealed class Manager : SalariedEmployee
    {
        //fields
        //properties
        public decimal YearlyBonus { get; set; }
        //ctors
        public Manager(int id, string firstName, string lastName,
            DateTime dob, string jobTitle, DateTime hiredate, bool isDirectDep,
            decimal yearlySalary, decimal bonus)
            : base(id, firstName, lastName, dob, jobTitle, hiredate,
                isDirectDep, yearlySalary)
        {
            YearlyBonus = bonus;
        }

        //methods
        //By default the Manager inherits the functionality of the GetPaycheckAmount() from the SalariedEmployee.
        //However, the Manager should ALSO get a bonus in addition to the salary value.  The ONLY way to ensure the Manager
        //is paid the appropriate amount is to override the functionality of the inherited method (from SalariedEmployee)
        public override decimal GetPaycheckAmount()
        {
            //Bonus can be distributed in multiple ways you need to get this information via
            //REQUIREMENTS GATHERING

            //manager is paid monthly and the bonus is distributed evenly throughout the year
            return (YearlySalary / 12) + (YearlyBonus / 12);

            //default behavior has changed because the parent class defines behavior.  There is no longer a NotImplemented Exception
            //because SalariedEmployee defines behavior.
            //return base.GetPaycheckAmount();
        }

        //ToString()
        public override string ToString() =>
             string.Format($"{base.ToString()}\nBonus: {YearlyBonus:c}");
    }
}
