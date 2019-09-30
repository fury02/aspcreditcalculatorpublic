using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnitTestClassLibraryCreditCalculate
{
    public class BankCreditData
    {
        public enum TypeTimeEnum { Month, Day }
        public enum TypeTimeInterestEnum { Year, Day }
        public double CreditAmount { get; set; }
        public double CreditTerm { get; set; }
        public double CreditRate { get; set; }
        public int StepPayment { get; set; }
        public TypeTimeEnum TypeTime { get; set; }
        public TypeTimeInterestEnum TypeTimeInterest { get; set; }
    }
}
