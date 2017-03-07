using Iterator.Models;

namespace Iterator.Interfaces
{
    interface IAbstractCollection
    {
        Models.Iterator CreateIterator();
    }
}
