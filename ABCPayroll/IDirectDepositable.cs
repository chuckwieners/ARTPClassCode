using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCPayroll
{
    //Terminology:
    //class : Interface - implementation of an interface
    //class : class - inheritance of a class
    //interface : interface - inheritance of an interface

    public interface IDirectDepositable : IPayable
    {
        //From INHERITANCE we get:
        //GetNameForPaycheck()
        //GetPaycheckAmount()

        //Methods
        string GetBankingInfo();
    }
}
