using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculatorCore
{
    class Program
    {
        private static List<MoneyType> GetMoneyForLocalCurrency()
        {
            return new List<MoneyType>()
            {
                new MoneyType() { Value = 50, Name = "£50" },
                new MoneyType() { Value = 20, Name = "£20" },
                new MoneyType() { Value = 10, Name = "£10" },
                new MoneyType() { Value = 5, Name = "£5" },
                new MoneyType() { Value = 2, Name = "£2" },
                new MoneyType() { Value = 1, Name = "£1" },
                new MoneyType() { Value = 0.5m, Name = "50p" },
                new MoneyType() { Value = 0.2m, Name = "20p" },
                new MoneyType() { Value = 0.10m, Name = "10p"},
                new MoneyType() { Value = 0.05m, Name = "5p" },
                new MoneyType() { Value = 0.02m, Name = "2p" },
                new MoneyType() { Value = 0.01m, Name = "1p" }
            };
        }
        private static CultureInfo GetMoneyAmounthDecimalFormatCulture()
        {
            return CultureInfo.CreateSpecificCulture("en-GB");
        }

        static void Main(string[] args)
        {
            string calculateMore = "Y";
            while (calculateMore.ToUpper() == "Y")
            {
                NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                CultureInfo culture = GetMoneyAmounthDecimalFormatCulture();
                decimal moneyResult = 0;
                while (moneyResult == 0)
                {
                    Console.WriteLine("Enter money amount:");
                    string money = Console.ReadLine();

                    if (!decimal.TryParse(money, style, culture, out moneyResult))
                    {
                        Console.WriteLine("Invalid money amount. Money must be a number");
                    }
                    if (moneyResult <= 0)
                    {
                        moneyResult = 0;
                        Console.WriteLine("Money must be greater than 0");
                    }
                }
                decimal priceResult = 0;
                while (priceResult == 0)
                {
                    Console.WriteLine("Enter price amount:");
                    string price = Console.ReadLine();

                    if (!decimal.TryParse(price, style, culture, out priceResult))
                    {
                        Console.WriteLine("Invalid price amount. Price must be a number");
                    }
                    if (priceResult <= 0)
                    {
                        priceResult = 0;
                        Console.WriteLine("Price must be greater than 0");
                    }
                }

                Calculator calculator = new Calculator(UKMoneyTypes.GetMoneyForUKCurrency());
                calculator.PrintListOfChange(moneyResult, priceResult);
                Console.WriteLine("Calculate more ? (Y/N)");
                calculateMore = Console.ReadLine();
            }
            Console.WriteLine("Bye");
        }
        

    }
}
