using Xunit;
using DecideWise.Services;
using DecideWise.Models;


namespace DecideWise.Tests
{
    public class DecisionServiceTests
    {
        private readonly DecisionService _service;

        public DecisionServiceTests()
        {
            var repo = new FakeRepository();
            _service = new DecisionService(repo);
        }

        [Fact]
        public void Search_ExistingItem_ReturnsResult()
        {
            var result = _service.SearchByName("Laptop");

            Assert.NotEmpty(result);
            Assert.Equal("Laptop", result[0].Name);
        }

        [Fact]
        public void Search_NonExisting_ReturnsEmpty()
        {
            var result = _service.SearchByName("NukEkziston");

            Assert.Empty(result);
        }

        [Fact]
        public void Add_ValidOption_AddsSuccessfully()
        {
            var option = new Option
            {
                Name = "Tablet",
                Category = "Tech",
                Price = 300
            };

            _service.AddOption(option);

            var all = _service.GetAll();
            Assert.Contains(all, x => x.Name == "Tablet");
        }

        [Fact]
        public void Add_InvalidOption_ReturnsError()
        {
            var option = new Option
            {
                Name = "",
                Category = "Tech",
                Price = 0
            };

            _service.AddOption(option);

            var all = _service.GetAll();
            Assert.DoesNotContain(all, x => x.Name == "");
        }
    }
}