using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AnnuityCalculatorASPNETCORE3.Models;

namespace AnnuityCalculatorASPNETCORE3.Helpers
{
    public class Converter
    {
        private AllPayments _payinfo = null;

        public Converter()
        {
            _payinfo = new AllPayments();
        }
        public AllPayments PaytablesConverter(dynamic Paytables)
        {
            if(Paytables != null)
            {
                if(Paytables.Count > 0)
                {
                    foreach (var item in Paytables)
                    {
                        _payinfo.Add(new Payments(item.NumberPayment, item.DateTime, item.BodyCredit, item.InterestCoverage, item.CreditAmount, item.Overpayment));
                    }
                }               
            }            

            return _payinfo;
        }
    }
}
