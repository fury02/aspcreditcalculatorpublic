using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibraryCreditCalculate;
using LightInject;
using ContainerDI;

namespace UnitTestClassLibraryCreditCalculate
{
    [TestClass]
    public class UnitTestClassLibraryCreditCalculate
    {
        private ServiceContainer _serviceContainer;
        private FakeBankCreditData _сreditData;
  
        public UnitTestClassLibraryCreditCalculate()
        {
            _serviceContainer = new Container().GetServiceContainer;
            _сreditData = new FakeBankCreditData();
        }

        [TestMethod]
        public void TestMethodCalculate()
        {
            ICreditInfo _creditInfo = _serviceContainer.GetInstance<ICreditInfo>();
            _creditInfo.Calculate(_сreditData._simplePaymentsInMonth36Sum10000Rate12);
            //Assert.AreEqual(_creditInfo.Calculate(_сreditData._simplePaymentsInMonth36Sum10000Rate12), 1);
        }

        private class FakeBankCreditData
        {
            public BankCreditData _simplePaymentsInMonth36Sum10000Rate12;
            //public BankCreditData _bankCreditDataCreditAmount100000;
            //public BankCreditData _bankCreditDataTypeTimeEnumDay;
            //public BankCreditData _bankCreditDataTypeTimeInterestEnumDay;

            public FakeBankCreditData()
            {
                _simplePaymentsInMonth36Sum10000Rate12 = new BankCreditData();

                _simplePaymentsInMonth36Sum10000Rate12.CreditAmount = 124244223; //Сумма
                _simplePaymentsInMonth36Sum10000Rate12.CreditTerm = 7;      //Срок месяцы
                _simplePaymentsInMonth36Sum10000Rate12.CreditRate = 4;      //Проценты
                _simplePaymentsInMonth36Sum10000Rate12.StepPayment = 365;    //Годовая процентная ставка
                _simplePaymentsInMonth36Sum10000Rate12.TypeTime = BankCreditData.TypeTimeEnum.Month; //Платежы по месяцу
                _simplePaymentsInMonth36Sum10000Rate12.TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Year; //Ставка в год 

                //_simplePaymentsInMonth36Sum10000Rate12 = new BankCreditData();

                //_simplePaymentsInMonth36Sum10000Rate12.CreditAmount = 14000; //Сумма
                //_simplePaymentsInMonth36Sum10000Rate12.CreditTerm = 36;      //Срок месяцы
                //_simplePaymentsInMonth36Sum10000Rate12.CreditRate = 17;      //Проценты
                //_simplePaymentsInMonth36Sum10000Rate12.StepPayment = 365;    //Годовая процентная ставка
                //_simplePaymentsInMonth36Sum10000Rate12.TypeTime = BankCreditData.TypeTimeEnum.Month; //Платежы по месяцу
                //_simplePaymentsInMonth36Sum10000Rate12.TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Year; //Ставка в год 

                //_bankCreditDataCreditAmount100000 = new BankCreditData();

                //_bankCreditDataCreditAmount100000.CreditAmount = 100000;
                //_bankCreditDataCreditAmount100000.CreditTerm = 10;
                //_bankCreditDataCreditAmount100000.CreditRate = 2;
                //_bankCreditDataCreditAmount100000.StepPayment = 365;
                //_bankCreditDataCreditAmount100000.TypeTime = BankCreditData.TypeTimeEnum.Month;
                //_bankCreditDataCreditAmount100000.TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Year;

                //_bankCreditDataTypeTimeEnumDay = new BankCreditData();

                //_bankCreditDataTypeTimeEnumDay.CreditAmount = 100000;
                //_bankCreditDataTypeTimeEnumDay.CreditTerm = 10;
                //_bankCreditDataTypeTimeEnumDay.CreditRate = 2;
                //_bankCreditDataTypeTimeEnumDay.StepPayment = 365;
                //_bankCreditDataTypeTimeEnumDay.TypeTime = BankCreditData.TypeTimeEnum.Day;
                //_bankCreditDataTypeTimeEnumDay.TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Year;

                //_bankCreditDataTypeTimeInterestEnumDay = new BankCreditData();

                //_bankCreditDataTypeTimeInterestEnumDay.CreditAmount = 100000;
                //_bankCreditDataTypeTimeInterestEnumDay.CreditTerm = 10;
                //_bankCreditDataTypeTimeInterestEnumDay.CreditRate = 2;
                //_bankCreditDataTypeTimeInterestEnumDay.StepPayment = 365;
                //_bankCreditDataTypeTimeInterestEnumDay.TypeTime = BankCreditData.TypeTimeEnum.Month;
                //_bankCreditDataTypeTimeInterestEnumDay.TypeTimeInterest = BankCreditData.TypeTimeInterestEnum.Day;
            }
        }
    }
}
