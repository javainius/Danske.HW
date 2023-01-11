using AutoMapper;
using Danske.HW.BusinessLogic;
using Danske.HW.Contracts;
using Danske.HW.Models;
using Microsoft.AspNetCore.Mvc;

namespace SortNumbersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly INumberService _numberService;
        private readonly IMapper _mapper;

        public NumbersController(INumberService numberService, IMapper mapper)
        {
            _numberService = numberService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SaveSortedNumbers(NumberContract numberContract)
        {
            var numberModel = _mapper.Map<NumberModel>(numberContract);
            var savedNumberModel = _numberService.SaveSortedNumbers(numberModel);

            return Ok(_mapper.Map<NumberContract>(savedNumberModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetNumbers()
        {
            var numberModel = _numberService.GetNumbers();
            var numberContract = _mapper.Map<NumberContract>(numberModel);

            return Ok(numberContract);
        }
    }
}