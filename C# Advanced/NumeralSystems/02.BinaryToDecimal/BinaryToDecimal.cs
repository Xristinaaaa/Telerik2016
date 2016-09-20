using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
class BinaryToDecimal
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();
        Console.WriteLine(BinToDecimal(n));
    }
    //static BigInteger Decimal(string num)
    //{
    //    BigInteger decnum = 0;
    //    int index = 0;
    //    for (int i = num.Length-1; i >= 0; i--)
    //    {
    //        decnum += (BigInteger)(int.Parse(num[i].ToString()) * Math.Pow(2, index));
    //        index++;
    //    }
    //    return decnum;
    //}
    static BigInteger BinToDecimal(string binary)
    {
        BigInteger sum = 0;

        foreach (char bit in binary)
        {
            sum = (bit - '0') + sum * 2;
        }
        return sum;
    }
}

