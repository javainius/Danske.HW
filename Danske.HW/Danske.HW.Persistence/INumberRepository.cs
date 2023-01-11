using Danske.HW.Entities;

namespace Danske.HW.Persistence
{
    public interface INumberRepository
    {
        public NumberEntity SaveNumbers(NumberEntity numberEntity);
        public NumberEntity ReadNumbers();
    }
}
