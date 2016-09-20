using System;
using System.Linq;
using System.Numerics;

class DeCatCoding
{
    //static void Main()
    //{
    //string[] arrInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    //for (int x = 0; x < arrInput.Length; x++)
    //{
    //    string input = arrInput[x];

    //    //Transfer to decimal
    //    BigInteger decResult = 0;
    //    for (int i = input.Length - 1, j = 0; i >= 0; i--, j++)
    //    {
    //        BigInteger digit = (BigInteger)(input[i] - 'a');
    //        decResult += digit * (BigInteger)BigInteger.Pow(21, j);//Math.Pow(21, j);
    //    }

    //    //Transfer to 26 based system
    //    string result = string.Empty;
    //    while (decResult > 0)
    //    {
    //        BigInteger tmp = decResult % 26;
    //        decResult /= 26;

    //        char digit = (char)(tmp + 'a');
    //        result = digit + result;
    //    }
    //    Console.Write(result + " ");
    //}
    //}

    static ulong CatToDec(string catNumber)
    {
        ulong result = 0;

        foreach (char digit in catNumber)
        {
            result = (ulong)(digit - 'a') + result * 21;
        }
        return result;
    }
    static string DecTo26(ulong dec)
    {
        var result = string.Empty;

        do
        {
            char digitValue = (char)('a'+ dec % 26);
            result = digitValue + result;
            dec /= 26;
        } while (dec!=0);

        return result;
    }
    static void Main()
    {
        //1.read input
        //1.1 extract all cat numbers
        //2. convert all cat numbers to decimal
        //3. convert all decimal numbers to base 26
        //4. join by space and print

        var numbers = Console.ReadLine().Split(' ').Select(CatToDec).Select(DecTo26).ToArray();

        Console.WriteLine(string.Join(" ",numbers));
    }
}