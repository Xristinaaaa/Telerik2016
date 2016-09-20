namespace RangeException
{
    using System;
  
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                int number = -100;

                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>("Invalid input", 1, 100);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                DateTime date = new DateTime(1970, 03, 16);

                if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>("Invalid input", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
