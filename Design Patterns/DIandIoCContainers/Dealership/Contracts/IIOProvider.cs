namespace Dealership.Contracts
{
    interface IIOProvider
    {
        string ReadLine();
        void WriteLine(string input);

        void Write(string input);
    }
}
