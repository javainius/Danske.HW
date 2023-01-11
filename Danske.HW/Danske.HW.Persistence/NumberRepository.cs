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
            if (File.Exists(_filePath))
            {
                var numbers = File.ReadAllLines(_filePath).Select(x => int.Parse(x));

                return new NumberEntity { Numbers = numbers.ToList() };
            }
            else
            {
                // there should be an exception wrapper created which wraps the service
                // layer and through configuration (in startup class) puts the service under the wrapper
                // but not sure if that's the scope of this task
                throw new FileNotFoundException("Resource file was not found");
            }
        }
    }
}
