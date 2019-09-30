using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryCreditCalculate.Models;

namespace ClassLibraryCreditCalculate
{
    public interface ICreditInfo
    {
        List<Payments> Calculate(object bankCreditData);
    }
}
