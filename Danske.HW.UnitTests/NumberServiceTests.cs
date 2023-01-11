using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoFixture;
using Danske.HW.Persistence;
using AutoMapper;
using Danske.HW.BusinessLogic;
using Danske.HW.Models;
using Danske.HW.Entities;

namespace Danske.HW.UnitTests
{
    [TestClass]
    public class NumberServiceTests
    {
        private NumberService _numberService;
        private Mock<INumberRepository> _mockNumberRepository;
        private Mock<IMapper> _mockMapper;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockNumberRepository = new Mock<INumberRepository>();
            _mockMapper = new Mock<IMapper>();

            _numberService = new NumberService(_mockNumberRepository.Object, _mockMapper.Object);
            _fixture = new Fixture();
        }

        [TestMethod]
        public void GivenNotSortedNumbers_WhenSaveSortedNumbersIsCalled_ThenSortedNumberModelIsReturned()
        {
            // Given
            var numberModel = _fixture.Create<NumberModel>();
            var numberEntity = _fixture.Create<NumberEntity>();
                
            var expectedSortedNumbers = new List<int>(numberModel.Numbers).OrderBy(x => x).ToList();
            // for some reason _fixture.DeepClone() gives an error

            _mockNumberRepository
                .Setup(x => x.SaveNumbers(numberEntity))
                .Returns(numberEntity);
            _mockMapper
                .Setup(x => x.Map<NumberEntity>(numberModel))
                .Returns(numberEntity);
            _mockMapper
                .Setup(x => x.Map<NumberModel>(numberEntity))
                .Returns(numberModel);

            // When
            var result = _numberService.SaveSortedNumbers(numberModel);

            // Then
            CollectionAssert.AreEqual(expectedSortedNumbers, result.Numbers);

            _mockNumberRepository.Verify(x => x.SaveNumbers(It.IsAny<NumberEntity>()), Times.Once);
        }

        [TestMethod]
        public void WhenReturnNumberModel_ThenNumberModelIsReturned()
        {
            // Given
            var numberEntity = _fixture.Create<NumberEntity>();
            var numberModel = _fixture.Create<NumberModel>();

            _mockNumberRepository
                .Setup(x => x.ReadNumbers())
                .Returns(numberEntity);
            _mockMapper
                .Setup(x => x.Map<NumberModel>(numberEntity))
                .Returns(numberModel);

            // When
            var result = _numberService.GetNumbers();

            // Then
            Assert.AreEqual(numberModel, result);

            _mockNumberRepository.Verify(x => x.ReadNumbers(), Times.Once);
        }
    }
}