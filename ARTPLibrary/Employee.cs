using ABCPayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    //accessing this class from another project, you must add the public access modifier.

    //Verbal Description of code: 
    //creates the definition for the inheritance only public sub class called employee that inherits from the superclass person and implements the IPayable and IDirectDepositable interfaces
    //creates the definition for the inheritance only public child class called employee that inherits from the parent class person and implements the IPayable and IDirectDepositable interfaces
    //creates the definition for the inheritance only public derived class called employee that inherits from the base class person and implements the IPayable and IDirectDepositable interfaces
    //Creates the definition for the inheritance only public class called employee that extends the person class and implements the IPayable and IDirectDepositable interfaces
    //public class Employee //:Object - if no inheritance is specified, Object is used as the base class.
    public abstract class Employee : Person, IPayable, IDirectDepositable
    {
        //fields
        //No biz logic, no fields required

        //properties - the format below is referred to as Automatic Properties (shorthand version) (.net 3.5)
        //ID should be readonly
        public int ID { get; /*set;*/ }//Commenting out the setter makes this readonly (only available in C# 6.0)
        public string JobTitle { get; set; }
        public DateTime DateOfHire { get; set; }
        public bool IsDirectDeposit { get; set; }

        //ctors
        public Employee(int id, string fName, string lName, DateTime dob, string title, DateTime hireDate, bool isDirectDeposit)
            :base(fName,lName, dob)
        {
            //Assignment of the class specific properties (the properties that belong to parent have already been assigned through
            //the base() call.
            ID = id;
            JobTitle = title;
            DateOfHire = hireDate;
            IsDirectDeposit = isDirectDeposit;
        }

        //methods
        //Satisfy the getNameForPaycheck() requirement from IPayable
        public string GetNameForPaycheck()
        {
            return FirstName + " " + LastName;
            //this is an instance method, so the first and last name will belong to the instance of the employee 
            //that is calling this method.
        }
        //Declare the GetPaycheckAmount(), pass down the functionality to inheriting classes.
        //We do not have the required information to calculate the paycheck here.  By declaring the method
        //abstract, we satisfy the requirement by the interface and  FORCE inheriting classes to provide the behavior.
        //ABSTRACT: Forces inheritance.
        public abstract decimal GetPaycheckAmount();

        //Declare the GetBankingInfo() to satisfy IDirectDepositable
        public string GetBankingInfo()
        {

            /*
             * Banking Information can include, but is not limited to:
             * Account/Routing numbers, institution name, and PIN
             * These should all be properties of the Employee class.
             * Our example will HARD CODE this information.  That means
             * that ALL banking information will be the same for EVERY employee.
             * You will see the same banking info for ANY employee that has their
             * IsDirectDeposit flag (boolean value) property set to true.
             * 
             * Other information that should/could be included as properties in this
             * class:
             *  Withholding information (W4), SSN, 401K contributions, donations,
             *  financial splits between institutions, Health Care, Life Insurance,
             *  other benefits, wage garnishment, and direct dispersment payments.
             *  
             *  One consideration to be made is WHEN do these deductions occur. Do 
             *  they happen pre/post tax, etc.  The order of Calculation is VERY 
             *  IMPORTANT: REQUIREMENTS GATHERING.
             */
            return "Bank of `Merica 000123 111222333444";
            //IF this was hard coded in PRODUCTION, ALL direct deposits would go to this account.
            //That is why we need properties to store the ACTUAL values (per employee)
        }


        //ToString()
        //If you do not override (declare) the ToString() here, you will see the PERSON toString() - it is the inherited parent class.
        public override string ToString() =>
            $"ID: {ID}\n{base.ToString()}\nJob Title: {JobTitle}\nDate Of Hire: {DateOfHire:d}" +
            //ternary operator to change the True/False to Yes/No for the bool
            $"\nDirect Deposit: {(IsDirectDeposit ? "Yes" : "No")}";

    }
}
