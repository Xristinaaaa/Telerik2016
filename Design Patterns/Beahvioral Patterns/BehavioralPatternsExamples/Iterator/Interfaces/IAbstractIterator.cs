using Iterator.Models;

namespace Iterator.Interfaces
{
    interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

}
