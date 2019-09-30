using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuityCalculatorASPNETCORE3.Models
{
    public class AllPayments
    {
        private List<Payments> Paytable = new List<Payments>();

        public void Add(Payments payline)
        {
            Paytable.Add(payline);
        }

        public virtual IEnumerable<Payments> Lines => Paytable;
    }
}
