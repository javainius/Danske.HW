using Danske.HW.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Danske.HW.Persistence
{
    public class NumberRepository : INumberRepository
    {
        private readonly string _filePath;
        public NumberRepository(string filePath)
        {
            _filePath = filePath;
        }

        public NumberEntity SaveNumbers(NumberEntity numberEntity)
        {
            File.WriteAllLines(_filePath, numberEntity.Numbers.Select(x => x.ToString()));

            return numberEntity;
        }

        public NumberEntity ReadNumbers()
        {
            var numbers = File.ReadAllLines(_filePath)
                        .Select(x => int.Parse(x))
                        .ToArray();

            return new NumberEntity { Numbers = numbers };
        }
    }
}
