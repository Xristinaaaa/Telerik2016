using FlyweightExample.Contracts;
using FlyweightExample.Enums;
using System;

namespace FlyweightExample.Models
{
    class PaperMoney : IMoney
    {
        public EnMoneyType MoneyType
        {
            get { return EnMoneyType.Paper; }
        }

        public void GetDisplayOfMoneyFalling(int moneyValue) 
        {
            Console.WriteLine(string.Format("Displaying a graphical object of {0} currency of value ${1} falling from sky.", MoneyType.ToString(), moneyValue));
        }
    }
}
