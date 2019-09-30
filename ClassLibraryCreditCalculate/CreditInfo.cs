using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibraryCreditCalculate.Models;

namespace ClassLibraryCreditCalculate
{
    public class CreditInfo : ICreditInfo
    {
        //CreditAmount = 10000; //Сумма
        //CreditTerm = 36;      //Срок месяцы
        //CreditRate = 13;      //Проценты
        //StepPayment = 365;    //Годовая процентная ставка
        //TypeTime = BankCreditData.TypeTimeEnum.Month; //Платежы по месяцу
        //TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Year; //Ставка в год 

        public List<Payments> Calculate(dynamic bankCreditData)
        {
            double creditAmount = bankCreditData.CreditAmount;
            double creditTerm = bankCreditData.CreditTerm;
            double creditRate = bankCreditData.CreditRate;
            int stepPayment = bankCreditData.StepPayment;
            dynamic typeTime = bankCreditData.TypeTime;
            dynamic typeTimeInterest = bankCreditData.TypeTimeInterest;

            int month = 12;
            double ratioAnnuity = RatioAnnuity(creditTerm, creditRate); //Коэффициент аннуитета
            double mountsPayments = Math.Round(ratioAnnuity * creditAmount, 2); //Месячный платеж
            double fullAmount = mountsPayments * creditTerm; //Полная сумма
            double i = creditRate / 100 / month;
            double overpayment = Math.Round(fullAmount - creditAmount, 2);

            List<Payments> payes = new List<Payments>();
            double bodyCredit = 0;//Тело кредита
            int count = 0;
            DateTime dateTime = DateTime.Now;

            while (creditAmount > 0)
            {
                count++;

                var interestCoverage = Math.Round(creditAmount * i, 2); //Погашение процентов
                creditAmount = Math.Round(creditAmount + interestCoverage - mountsPayments, 2); //Остаток
                bodyCredit = Math.Round(mountsPayments - interestCoverage, 2);
                dateTime = dateTime.AddMonths(1);

                //Действие, если в остатках погашения остались копейки, то есть сотые от целого.
                if (Math.Round(creditAmount, 0) == 0)
                {
                    bodyCredit += creditAmount; creditAmount = 0;
                }

                payes.Add(new Payments(count, dateTime, bodyCredit, interestCoverage, creditAmount, overpayment));
            }

            return payes;
        }

        /// <summary>
        /// Коэффициент аннуитета
        /// </summary>
        /// <param name="CreditTerm"></param>
        /// <param name="CreditRate"></param>
        /// <returns></returns>
        private double RatioAnnuity(double CreditTerm, double CreditRate)
        {
            int Month = 12; //годовая ставка для простого случая
            var i = CreditRate / 100 / Month; //месячная процентная ставка по кредиту(= годовая ставка / 12 / 100)
            var K = i * (System.Math.Pow((1 + i), CreditTerm)) / ((System.Math.Pow((1 + i), CreditTerm)) - 1); //Коэффициент аннуитета
            return K;
        }
    }
}
