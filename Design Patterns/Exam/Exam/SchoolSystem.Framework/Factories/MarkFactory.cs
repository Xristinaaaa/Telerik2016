using SchoolSystem.Framework.Factories.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Factories
{
    public class MarkFactory : IMarkFactory
    {
        public IMark CreateMark(Subject subject, float value)
        {
            return new Mark(subject, value);
        }
    }
}
