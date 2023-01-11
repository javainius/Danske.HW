using Danske.HW.Models;

namespace Danske.HW.BusinessLogic
{
    public interface INumberService
    {
        public NumberModel SaveSortedNumbers(NumberModel numberModel);
        public NumberModel GetNumbers();
    }
}
