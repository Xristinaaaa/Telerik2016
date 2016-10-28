namespace MatrixOperations
{
    using System;

    public class Validator
    {
        public static void ValidateNull(object objectToCheck)
        {
            if(objectToCheck == null)
            {
                throw new ArgumentNullException(objectToCheck + "is not defined");
            }
        }
    }
}
