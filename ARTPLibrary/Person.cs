using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTPLibrary
{
    //Marking this class abstract forces the class to be inherited if it is to be used at all
    //You CANNOT create an instance (new object) from an abastract class.
    //In documentation (MSDN) you may see these referred to as "Inheritance Only" classes

    public abstract class Person
    {
        //convention for fields is private _camelCase
        //Convention vs Rule:  Convention is a standard (best practice).  Rule is compiler enforced and MUST be followed

        //fields
        private string _firstName;
        private string _lastName;

        //Containment - use of a complex (non primitive) data type as a field or property in a class.
        //private DateTime _dob;

        //Make dob read only
        private readonly DateTime _dob;

        //properties - Convention is public and PascalCase
        //These properties are very manual in assignment, as opposed to the short hand that you have used in the past.
        //The "shorthand" properties are actually referred to as "Automatic Properties" - that statement is generated when
        //you use the prop [tab][tab] keyboard shortcut.  If you are NOT creating business rules, automatic properties are great!
        public string FirstName
        {
            get { return _firstName; } //retrieve the variable to be assigned
            
            //If we set up biz rules, this is what it would look like
            set
            {
                if (value.Count() > 1)
                {
                    _firstName = value;
                }
                else
                {
                    _firstName = "[-Not Given-]";
                }
            }//assign value to the retrieved variable
        }

        //Autogenerate properties from the fields, by right clicking the field and selecting refactor
        //public string LastName { get => _lastName; set => _lastName = value; }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        //All properties are an example of ENCAPSULATION (hiding the details)
        //End users don't see the fields that exist behind the properties, but that is where the activity
        //is actually taking place.

        public DateTime DOB
        {
            get { return _dob; }
            //set { _dob = value; }
            //Read only variables must be assigned at initialization (the field) or in the ctor (below)
        }

        //ctors - Convention:  Access should be public (99% of what we build will be public).
        //                     Parameters should be camelCase
        //        Rule: Must be the same name (spelling and casing) as the class.
        //Fully Qualified ctors (named parameters) - you can have as many as you need.
        //If you have a FQ ctor and want to use the Default No Arg ctor (from Object) you MUST DECLARE IT.
        //More than one ctor - the ctor is said to be "overloaded".
        public Person(string firstName, string lastName, DateTime dob)
        {
            //assign values
            //property is "assigned the value of" the ctor param
            FirstName = firstName;
            LastName = lastName;
            //DOB = dob;
            _dob = dob;//Assign directly to the Private Field.  The public property is available for output.
        }

        //events - Not typically used in the MVC environment, but they are triggers that action has occcured
        //and use a DELEGATE structure to point to activity that should occur when the event "fires". The responding
        //activity is called an Event Handler (method that responds to an event).
        //Application_Error (in the global.asax of an MVC application) is the event handler for when the Application throws an exception.

        //methods

        //ToString() - Allows for formatting and the output of the object to the console.
        //           - more textbook: Outputs the state of the object (state = sum of all defined/fulfilled properties)
        //By default if we dont write a toString() what is the output?:  Namespace.Class - Object class

        ////1)Basic concatonation - bulky and lots of room for mistakes
        //public override string ToString()
        //{
        //    return "Name: " + FirstName + " " + LastName + "\nDate of Birth: " + DOB;//simple concat, no formatting

        //    //return base.ToString(); -namespace.classname
        //}

        ////2)String Formatting - better, still error prone
        //public override string ToString()
        //{
        //    return string.Format("Name: {0} {1}\nDate of Birth: {2:d}",FirstName, LastName, DOB);

        //    //return base.ToString();
        //}

        //3)String Formatting with Interpolation
        //public override string ToString()
        //{
        //    //return string.Format($"Name {FirstName} {LastName}\nDate of Birth: {DOB:d}");
        //    return $"Name: {FirstName} {LastName}\nDate of Birth: {DOB:d}";

        //    //return base.ToString();
        //}

        //4)String Interpolation with Linq (lambda syntax) - more advanced coding
        //  you will only see this in code from VS2015 (C# 6.0) and higher
        public override string ToString() => $"Name: {FirstName} {LastName}\nDate of Birth: {DOB:d}";

    }
}
