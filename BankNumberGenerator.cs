using System.Collections.Generic;

namespace MyBank
{
    public class BankNumberGenerator
    {
        private static BankNumberGenerator _instance;
        private int AccountNumber { get; set; }

        private BankNumberGenerator()
        {
        }

        public static BankNumberGenerator GetInstance()
        {
            return _instance ?? (_instance = new BankNumberGenerator());
        }

        public string GetNextBankNumber()
        {
            AccountNumber += 1;

            var numberStringify = AccountNumber.ToString();

            var prefixLength = 10 - numberStringify.Length;
            var prefix = new List<string>();

            while (prefixLength > 0)
            {
                prefix.Add("0");
                prefixLength--;
            }

            return string.Join("", prefix) + numberStringify;
        }
    }
}