using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnnuityCalculatorASPNETCORE3.Models
{
    public class BankCreditData
    {
        #region Перечисления типов времяни
        public enum TypeTimeEnum { Month, Day }
        public enum TypeTimeInterestEnum { Year, Day }
        #endregion

        /// <summary>
        /// Сумма кредита
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Ошибка ввода")]
        [RegularExpression(@"^[0-9]{1,}(?:[.,][0-9]{1,2})?\r?$", ErrorMessage = "Ошибка ввода")]
        public double CreditAmount { get; set; }

        /// <summary>
        /// Период кредита в днях или месяцах
        /// </summary>
        [Required]
        [Range(0, 1000000, ErrorMessage = "Ошибка ввода")]
        [RegularExpression(@"^[0-9]{1,}(?:[.,] [0-9]{0,0})?\r?$", ErrorMessage = "Ошибка ввода")]
        public double CreditTerm { get; set; }

        /// <summary>
        /// Процентная ставка по кредиту
        /// </summary>
        [Required]
        [Range(0, 100, ErrorMessage = "Ошибка ввода")]
        [RegularExpression(@"^[0-9]{1,}(?:[.,][0-9]{1,2})?\r?$", ErrorMessage = "Ошибка ввода")]
        public double CreditRate { get; set; }
        
        /// <summary>
        /// Шаг платежа
        /// </summary>
        [Required]
        [Range(0, 366, ErrorMessage = "Ошибка ввода")]
        public int StepPayment { get; set; }

        #region Типы времени, для кредита
        public TypeTimeEnum TypeTime { get; set; }

        public TypeTimeInterestEnum TypeTimeInterest { get; set; }
        #endregion

    }
}
