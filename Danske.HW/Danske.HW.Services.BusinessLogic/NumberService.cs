using AutoMapper;
using Danske.HW.Entities;
using Danske.HW.Models;
using Danske.HW.Persistence;

namespace Danske.HW.BusinessLogic
{
    public class NumberService : INumberService
    {
        private readonly INumberRepository _numberRepository;
        private readonly IMapper _mapper;

        public NumberService(INumberRepository numberRepository, IMapper mapper)
        {
            _numberRepository = numberRepository;
            _mapper = mapper;
        }

        public NumberModel SaveSortedNumbers(NumberModel numberModel)
        {
            numberModel.Numbers = SortNumbers(numberModel.Numbers);

            var numberEntity = _mapper.Map<NumberEntity>(numberModel);
            var savedNumbers = _numberRepository.SaveNumbers(numberEntity);

            return _mapper.Map<NumberModel>(savedNumbers);
        }

        public NumberModel GetNumbers()
        {
            var numbers = _numberRepository.ReadNumbers();
            return _mapper.Map<NumberModel>(numbers);
        }

        private static int[] SortNumbers(int[] numbers)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                numbers = BubbleSortIteration(numbers, ref isSorted);
            }

            return numbers;
        }

        private static int[] BubbleSortIteration(int[] numbers, ref bool isSorted)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    int temporaryValue = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temporaryValue;

                    isSorted = false;
                }
            }

            return numbers;
        }
    }
}