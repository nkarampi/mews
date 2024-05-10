﻿using ExchangeRateUpdater.Core.Exceptions;

namespace ExchangeRateUpdater.Core.Models.CzechNationalBank
{
    public class CzechNationalBankExchangeRate : ExchangeRate
    {
        private const int DECIMAL_PLACES = 2;
        private const string CURRENCY_CODE = "CZK";

        public CzechNationalBankExchangeRate(Currency sourceCurrency, Currency targetCurrency, decimal value) : base(sourceCurrency, targetCurrency, value)
        {
        }

        public CzechNationalBankExchangeRate(int amount, decimal rate, string currencyCode) : base(new Currency(currencyCode), new Currency(CURRENCY_CODE), GetAmount(amount, rate))
        {
        }

        public static decimal GetAmount(int amount, decimal rate)
        {
            if (amount <= 0 || rate <= 0)
            {
                throw new ExchangeRateException("The provided values are invalid");
            }

            return Math.Round(amount / rate, DECIMAL_PLACES);
        }
    }
}
