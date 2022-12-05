using AlgoTest;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace UnitTesting
{
    public class SortingServiceTests
    {
        private Mock<ILogger<ISortingService>> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<ISortingService>>();
        }

        [Test]
        public void MergeSort_Positive()
        {
            var phoneNumbers = new int[] { 457, 789, 123, 397, 981, 409, 12, 86, 3, 1234 };

            var sortingService = new SortingService(_logger.Object);
            sortingService.Sort(phoneNumbers, 0, phoneNumbers.Length - 1);

            Assert.IsTrue(phoneNumbers[0].Equals(3));
            Assert.IsTrue(phoneNumbers[1].Equals(12));
            Assert.IsTrue(phoneNumbers[2].Equals(86));
            Assert.IsTrue(phoneNumbers[3].Equals(123));
            Assert.IsTrue(phoneNumbers[4].Equals(397));
            Assert.IsTrue(phoneNumbers[5].Equals(409));
            Assert.IsTrue(phoneNumbers[6].Equals(457));
            Assert.IsTrue(phoneNumbers[7].Equals(789));
            Assert.IsTrue(phoneNumbers[8].Equals(981));
            Assert.IsTrue(phoneNumbers[9].Equals(1234));
        }

        [Test]
        public void MergeSort_Negative()
        {
            var phoneNumbers = new int[] { 457, 789, 123, 397, 981, 409, 12, 86, 3, 1234 };

            var sortingService = new SortingService(_logger.Object);
            Assert.Throws<IndexOutOfRangeException>(() => sortingService.Sort(phoneNumbers, -1, phoneNumbers.Length - 1));
        }
    }
}