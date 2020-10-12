using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculatorCore
{
    public class Calculator
    {
        private List<MoneyType> _moneyTypes;
        public Calculator (List<MoneyType> moneyTypes)
        {
            _moneyTypes = moneyTypes.OrderByDescending(x => x.Value).ToList(); ;
        }
        public void PrintListOfChange(decimal moneyAmount, decimal productPrice)
        {
            decimal totalChange = CalculateTotalChange(moneyAmount, productPrice);
            if (totalChange < 0)
            {
                Console.WriteLine("The price of the product is greater than the money you have given. You cannot buy your product.");
                Console.WriteLine("Your change is {0}", moneyAmount);
            }
            else
            {
                //This is where we construct our result
                Dictionary<MoneyType, decimal> neededChange = CalculateListOfChange(moneyAmount, productPrice);

                string summaryOfChange = "0";
                if (neededChange.Count() > 0)
                {
                    summaryOfChange = String.Join(
                                                   Environment.NewLine,
                                                   neededChange.Select(x => $"{x.Value} x {x.Key.Name}")
                                               );
                }

                string fullmessage = $"{totalChange} Your change is:{Environment.NewLine}{summaryOfChange}";

                Console.WriteLine(fullmessage);
            }
        }
        public  Dictionary<MoneyType, decimal> CalculateListOfChange(decimal moneyAmount, decimal productPrice)
        {
            decimal totalChange = CalculateTotalChange(moneyAmount, productPrice);
            Dictionary<MoneyType, decimal> neededChange = new Dictionary<MoneyType, decimal>();
            //Placeholder value for calculations
            decimal remainingChange = totalChange;

            foreach (var coinType in _moneyTypes)
            {
                decimal coinAmount = CalculateMaxCoins(coinType, remainingChange);

                //Do nothing if the result was 0
                if (coinAmount > 0)
                {
                    //Add the results
                    neededChange.Add(coinType, coinAmount);

                    //See how much money is left to calculate
                    remainingChange = remainingChange - (coinAmount * coinType.Value);

                    //  Stop processing if there is no money left to calculate.
                    if (remainingChange == 0) break;
                }
            }
            return neededChange;
        }

        private  decimal CalculateTotalChange(decimal moneyAmount, decimal productPrice)
        {
            return moneyAmount - productPrice;
        }

        private  decimal CalculateMaxCoins(MoneyType coin, decimal remainingAmount)
        {
            return Math.Truncate(remainingAmount / coin.Value);
        }
    }
}
