using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculatorCore
{
    public class UKMoneyTypes
    {
        public static readonly MoneyType FiftyPounds = new MoneyType() { Value = 50, Name = "£50" };
        public static readonly MoneyType TwentyPounds = new MoneyType() { Value = 20, Name = "£20" };
        public static readonly MoneyType TenPounds = new MoneyType() { Value = 10, Name = "£10" };
        public static readonly MoneyType FivePounds = new MoneyType() { Value = 5, Name = "£5" };
        public static readonly MoneyType TwoPounds = new MoneyType() { Value = 2, Name = "£2" };
        public static readonly MoneyType OnePound = new MoneyType() { Value = 1, Name = "£1" };
        public static readonly MoneyType FiftyPennies = new MoneyType() { Value = 0.5m, Name = "50p" };
        public static readonly MoneyType TwentyPennies = new MoneyType() { Value = 0.2m, Name = "20p" };
        public static readonly MoneyType TenPennies = new MoneyType() { Value = 0.10m, Name = "10p" };
        public static readonly MoneyType FivePennies = new MoneyType() { Value = 0.05m, Name = "5p" };
        public static readonly MoneyType TwoPennies = new MoneyType() { Value = 0.02m, Name = "2p" };
        public static readonly MoneyType OnePenny = new MoneyType() { Value = 0.01m, Name = "1p" };

        private static readonly List<MoneyType> _moneyList;

        static UKMoneyTypes()
        {
            _moneyList = new List<MoneyType>()
            {
                FiftyPounds,
                TwentyPounds,
                TenPounds,
                FivePounds,
                TwoPounds,
                OnePound,
                FiftyPennies,
                TwentyPennies,
                TenPennies,
                FivePennies,
                TwoPennies,
                OnePenny
            };
        }


        public static List<MoneyType> GetMoneyForUKCurrency()
        {
            return _moneyList;
        }
    }
}
