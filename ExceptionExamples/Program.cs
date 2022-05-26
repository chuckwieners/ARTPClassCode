using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExceptionExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            //Error: 3 different kinds
            //  1)Syntax (compiler)
            //  2)Logical (nothing is thrown, it is just WRONG)
            //  3)Runtime (throwing of an Exception)

            //What is an Exception?: Anything that interrupts the normal execution of an assembly.
            //What is an Assembly?: We see Assemblies as VS Projects.  An assembly is a set of routines
            //used to perform a specific function.

            //Exception Handling - internally in code we can use a try/catch/finally
            //Try: Code to test/check for exceptions. "Potentially Dangerous Code" - outcome of its execution is unkonwn.
            //Catch: Handle the exception. Can I have more than one catch?: YES, they should cascade from the MOST specific to least
            //       specific types of exceptions
            //Finally: Always executes and can be used to return resources to the runtime for use.
            //(sql connections, data readers, file stream, stream readers, document,etc.)
            //does not apply to things like an SMTP Server that does not BELONG/OWNED by our application.

            //MSDN Hierarchy of Exceptions https://docs.microsoft.com/en-us/dotnet/standard/exceptions/
            try
            {
                //To view the 4 base properties of the exception class in the console, comment out
                //the insufficient funds exception and uncomment the code in the region below and run!
                #region Original Exception Declaration
                ////create a basic exception and throw it (manually) to see the 4 base properties
                ////of the exception class and the ToString()
                ////Exception e = new Exception();
                //Exception e = new Exception("This is a custom Exception Message using the 2nd overload of the Exception class");
                ////Data property - user (developer) defined information for the exception stored in key value pairs
                //e.Data.Add(111, "This is developer defined custom DATA");
                #endregion
                //InsufficientFundsException e = new InsufficientFundsException();
                InsufficientFundsException e = new InsufficientFundsException("You dont got that monies");
                throw e;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine($"Divide By Zero: {dbze.Message}");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine($"Null Reference: {nre.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Format Exception: {fe.Message}");
            }
            catch (IndexOutOfRangeException ioor)
            {
                Console.WriteLine($"Index Out Of Range: {ioor.Message}");
            }
            catch (InsufficientFundsException ife)
            {
                Console.WriteLine($"Insufficient Funds: {ife.Message}");
            }
            //catch
            //{
            //    //Empty catch.  Generally, these are a bad idea.
            //}
            catch (Exception ex)
            {
                Console.WriteLine("**********Exception Properties*****************");
                //Source - Project/Assembly that threw the exception
                Console.WriteLine($"Source: {ex.Source}\n");
                //Message - is default messaging defining the data type of the exception thrown (can be updated)
                Console.WriteLine($"Message: {ex.Message}\n");
                //StackTrace - Project.ClassName.Method AND the physical file location INCLUDING the line number that threw the exception
                Console.WriteLine($"StackTrace: {ex.StackTrace}\n");
                //Data - is developer (user) defined in a key/value pair (HashTable/instance of IDictionary)
                Console.WriteLine($"Data: {ex.Data[111]}\n");
                //ToString() - combination of the Source, message, and stackTrace properties.
                Console.WriteLine($"ToString(): {ex.ToString()}\n");
            }
            finally
            {
                Console.WriteLine("This code always executes");
                /*
                * This block is used to release any resources that may
                * have been trapped in the catch block (when our operation failed)
                * If we were trying to use connected SQL to connect to a table in a
                * database and a sqlDataReader to read the information, those
                * processes may need to be in a try/catch/finally, so that
                * if it fails, we can close the reader or the connection or any other
                * resource. (in web apps, you only get 10 connections to the database by default).
                *
                * File streaming is another example (writing information to file, reading 
                * information in to the app FROM a file).
                */
            }
        }
    }
    //Create a custom exception class.  Convent is that the classname should end with "Exception".
    //It should also inherit from the most closely related .net exception or custom exception class.

    public class InsufficientFundsException : Exception
    {
        //fields
        private string _message = "Your request for funds exceeds your account balance.";

        //properties - Read only to change the default messaging.
        public override string Message
        {
            get { return _message; }
        }
        //public override string Message { get; } - 6.0 syntax does not work with default value declared as the FIELD value

        //ctors
        //If we want to create an empty instance of this class we must write the public no arg ctor
        //as it will be lost (overridden) when we write our fully qualified ctor.
        public InsufficientFundsException() { }

        //FQ
        public InsufficientFundsException(string message)
        {
            _message = message;
        }

        //methods - no methods.

        //ToString() - inherit from Exception
    }

}
