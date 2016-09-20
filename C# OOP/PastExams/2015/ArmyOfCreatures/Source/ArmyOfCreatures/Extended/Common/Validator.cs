namespace ArmyOfCreatures.Extended.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfOutOfRange(int input, int min, int max, string message = null)
        {
            if (input<min || input>max)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
