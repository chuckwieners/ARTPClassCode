using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    public class SalariedEmployee : Employee
    {
        //fields
        //NOPE

        //properties
        public decimal YearlySalary { get; set; }

        //ctors
        public SalariedEmployee(int id, string firstName, string lastName,
            DateTime dob, string jobTitle, DateTime hiredate,
            bool isDirectDeposit, decimal yearlySalary)
            : base(id, firstName, lastName, dob, jobTitle, hiredate,
                  isDirectDeposit)
        {
            YearlySalary = yearlySalary;
        }

        //methods
        //The GetNameForPaycheck() is satisfied by the base class (Employee) and passed here via inheritance.
        //Employee could not fulfill the GetPaycheckAmount(), so we will implement the functionality here.
        //The method is declared in the base class, so we will override the parent (lack of) functionality
        //just like we did in HourlyEmployee.cs
        public override decimal GetPaycheckAmount()
        {
            //Pay Period/frequency
            //weekly - 52
            //bimonthly/semimonthly (1st and the the 15th) - 24
            //bi-weekly - 26
            //monthly -12

            //REQUIREMENTS GATHERING is extremely important - if you are given the pay period description
            //ALWAYS ask for the NUMBER of pay periods.

            //bi-weekly(26)
            return YearlySalary / 26;


            //Default implementation of the interface method
            //throw new NotImplementedException();
        }


        //ToString()
        public override string ToString() =>
                $"{base.ToString()}\nYearly Salary: {YearlySalary:c}";
    }
}
