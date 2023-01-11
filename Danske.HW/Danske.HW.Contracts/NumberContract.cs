using System.ComponentModel.DataAnnotations;

namespace Danske.HW.Contracts
{
    public class NumberContract
    {
        [Required]
        public int[] Numbers { get; set; }
    }
}