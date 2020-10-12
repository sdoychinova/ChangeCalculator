using ChangeCalculatorCore;
using FluentAssertions;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace ChangeCalculatorCoreTests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestNegtiveAmount()
        {
            Calculator calc = new Calculator(UKMoneyTypes.GetMoneyForUKCurrency());
            Dictionary<MoneyType, decimal> result = calc.CalculateListOfChange(3, 4);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void Test20andFivePoint5()
        {
            List<MoneyType> moneyList = UKMoneyTypes.GetMoneyForUKCurrency();
            Calculator calc = new Calculator(moneyList);
            Dictionary<MoneyType, decimal> result = calc.CalculateListOfChange(20, 5.5m);
            Assert.True(result.Count == 3);

            Assert.True(result.ContainsKey(UKMoneyTypes.TenPounds));
            Assert.True(result[UKMoneyTypes.TenPounds]==1);
            Assert.True(result.ContainsKey(UKMoneyTypes.TwoPounds));
            Assert.True(result[UKMoneyTypes.TwoPounds] == 2);
            Assert.True(result.ContainsKey(UKMoneyTypes.FiftyPennies));
            Assert.True(result[UKMoneyTypes.TenPounds] == 1);
        }

        [Fact]
        public void TestNoChange()
        {
            List<MoneyType> moneyList = UKMoneyTypes.GetMoneyForUKCurrency();
            Calculator calc = new Calculator(moneyList);
            Dictionary<MoneyType, decimal> result = calc.CalculateListOfChange(20, 20);
            Assert.True(result.Count == 0);
        }
    }
}
