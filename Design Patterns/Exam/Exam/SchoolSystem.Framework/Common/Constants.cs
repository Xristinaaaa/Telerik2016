namespace SchoolSystem.Framework.Common
{
    public static class Constants
    {
        //Commands
        public const string NotFoundCommand = "The passed command is not found!";
        public const string NullCommandException = "Command cannot be null or empty.";
        public const string TerminationCommand = "End";
        public const string NullProvidersExceptionMessage = "cannot be null.";

        //Models
        public const int MinFirstNameLenght = 2;
        public const int MaxFirstNameLenght = 31;
        public const float MinValue = 2.00f;
        public const float MaxValue = 6.00f;
        public const int MaxStudentMarksCount = 20;
    }
}
