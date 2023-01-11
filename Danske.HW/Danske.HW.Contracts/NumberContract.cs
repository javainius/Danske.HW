using System.ComponentModel.DataAnnotations;

namespace Danske.HW.Contracts
{
    public class NumberContract
    {
        [Required]
        public List<int> Numbers { get; set; }
    }
}