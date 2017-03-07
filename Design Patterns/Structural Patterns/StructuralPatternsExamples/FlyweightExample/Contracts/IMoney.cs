using FlyweightExample.Enums;

namespace FlyweightExample.Contracts
{
    interface IMoney
    {
        EnMoneyType MoneyType { get; }
        void GetDisplayOfMoneyFalling(int moneyValue); 
    }
}
