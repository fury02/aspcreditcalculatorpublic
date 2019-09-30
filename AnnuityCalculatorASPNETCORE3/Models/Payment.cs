using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnuityCalculatorASPNETCORE3.Models
{
    public class Payments
    {
        public Payments(int NumberPayment, DateTime DateTime, double BodyCredit
            , double InterestCoverage, double CreditAmount, double Overpayment)
        {
            this.NumberPayment = NumberPayment;
            this.Overpayment = Overpayment;
            this.DateTime = DateTime;
            this.BodyCredit = BodyCredit;
            this.InterestCoverage = InterestCoverage;
            this.CreditAmount = CreditAmount;
        }
        public Payments() { }
        public DateTime DateTime { get; set; }
        public int NumberPayment { get; set; }
        public double Overpayment { get; set; }
        public double BodyCredit { get; set; }
        public double InterestCoverage { get; set; }
        public double CreditAmount { get; set; }
    }
}
