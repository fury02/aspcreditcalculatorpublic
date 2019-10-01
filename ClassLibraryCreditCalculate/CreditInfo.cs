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
        public List<Payments> Calculate(dynamic bankCreditData)
        {
            double creditAmount = bankCreditData.CreditAmount;
            double creditTerm = bankCreditData.CreditTerm;
            double creditRate = bankCreditData.CreditRate;
            double stepPayment = bankCreditData.StepPayment;
            dynamic typeTime = bankCreditData.TypeTime;
            dynamic typeTimeInterest = bankCreditData.TypeTimeInterest;

            //Среднее число дней в месяце
            if(stepPayment == 30)
            {
                stepPayment = ((double)365 / (double)12);
            }

            //Если указана дневная процентная ставка, для простоты ставим ее годовой
            if(typeTimeInterest.ToString() == "Day")
            {
                creditRate = creditRate * 365;
            }

            //Если указаны месяцы в представлении "Период кредита:"
            if (typeTime.ToString() == "Month")
            {            
                creditTerm = (((double)365/(double)12) * creditTerm);
            }

            double countPeriod = 0;
            //Колличество периодов
            if (creditTerm != 0 && stepPayment != 0)
            {
                countPeriod = Math.Round((creditTerm / stepPayment) - (creditTerm / stepPayment) % Math.Pow(10, 0));      
            }

            double periodsInYear = 0;
            //Периуды для аннуитета, если дни то периодов больше чем 12
            if (stepPayment >= 30)
            {
                periodsInYear = 12;
            }
            if(stepPayment == 10 || stepPayment == 15)
            {
                periodsInYear = Math.Round((365 / stepPayment) - (365 / stepPayment) % Math.Pow(10, 0)); 
            }

            double periodInterestRate = creditRate / 100 / periodsInYear;
            double ratioAnnuity = RatioAnnuity(periodInterestRate, countPeriod, periodsInYear); //Коэффициент аннуитета
            double periodPayments = Math.Round(ratioAnnuity * creditAmount, 2); //Месячный платеж или 10 или 15 дней
            double fullAmount = periodPayments * countPeriod; //Полная сумма          
            double overpayment = Math.Round(fullAmount - creditAmount, 2);

            List<Payments> payes = new List<Payments>();
            double bodyCredit = 0;//Тело кредита
            int count = 0;
            DateTime dateTime = DateTime.Now;

            while (creditAmount > 0)
            {
                count++;

                var interestCoverage = Math.Round(creditAmount * periodInterestRate, 2); //Погашение процентов
                creditAmount = Math.Round(creditAmount + interestCoverage - periodPayments, 2); //Остаток
                bodyCredit = Math.Round(periodPayments - interestCoverage, 2);
                
                if(stepPayment == 30)
                {
                    dateTime = dateTime.AddMonths(1);
                }
                if(stepPayment == 15)
                {
                    dateTime = dateTime.AddDays(15);
                }
                if(stepPayment == 10)
                {
                    dateTime = dateTime.AddDays(10);
                }

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
        private double RatioAnnuity(double periodInterestRate, double countPeriod, double periodsInYear) => periodInterestRate + (periodInterestRate /           
            ((System.Math.Pow((1 + periodInterestRate), countPeriod)) - 1));
             
         
    }
}
