using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    //Marking a class as sealed terminates the inheritance chain (this class cannot be inherited from).
    public sealed class HourlyEmployee : Employee
    {
        //fields
        //Nope

        //properties
        public decimal HoursWorked { get; set; }
        public decimal HourlyWage { get; set; }

        //ctors

        public HourlyEmployee(int id, string firstName, string lastName,
            DateTime dateOfBirth, string title, DateTime hireDate,
            bool isDirectDeposit, decimal hoursWorked, decimal hourlyWage)
            : base(id, firstName, lastName, dateOfBirth, title, hireDate,
                isDirectDeposit)
        {
            HoursWorked = hoursWorked;
            HourlyWage = hourlyWage;
        }

        //methods
        //The GetNameForPaycheck() is satisfied by the base class (Employee) and passed here via inheritance.
        //Employee could not fulfill the GetPaycheckAmount(), so we will implement the functionality here.
        //The method is declared in the base class, so we will override the parent (lack of) functionality
        public override decimal GetPaycheckAmount()
        {
            //pay hourly employees: HoursWorked * HourlyWage
            //OT?
            //Pay Period
            //We need to know all of the payment requirements for an hourly employee.
            //REQUREMENTS GATHERING is extremely important so that we can define overtime,
            //thresholds (like shift diff, wages, hazard pay, etc.)
            //How often are they paid (pay frequency)
            //If you work in an enterprise environment, these questions would go to a project manager (PM) or
            //a business analyst (BA), or possibly a product owner.

            //Hourly Employees are paid regular pay for the first 40 hours.
            //Time and half for any hours over 40 in a week.
            //Paid weekly.

            //local variable to manage the paycheck amount
            decimal paycheck;

            if (HoursWorked <= 40)
            {
                //calculate the paycheck
                paycheck = HoursWorked * HourlyWage;
            }
            else
            {
                //get the OT hours ONLY
                decimal overtime = HoursWorked - 40;

                //calculate the paycheck
                paycheck = (40 * HourlyWage) + (overtime * HourlyWage * 1.5M);
            }
            //eliminate redundant code (you could have done the return in each branch)
            return paycheck;

            //This is the default behavior when you declare the method without any behavior in the scope of the body.
            //throw new NotImplementedException();
        }

        //ToString()
        public override string ToString() =>
                $"{base.ToString()}\nHours Worked: {HoursWorked:f2}\n" +
                $"Hourly Wage: {HourlyWage:c}";
    }
}
