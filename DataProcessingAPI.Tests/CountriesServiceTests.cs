using DataProcessingAPI.Models;
using DataProcessingAPI.Models.Models;
using DataProcessingAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataProcessingAPI.Tests
{
    [TestClass]
    public class CountriesServiceTests
    {
        [TestMethod]
        public void FilterCountriesByName_NullName_ReturnsAllData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
            };
            string? name = null;

            // Act
            var result = CountriesService.FilterCountriesByName(name, data);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void FilterCountriesByName_NullData_ReturnsEmptyList()
        {
            // Arrange
            List<Country>? data = null;
            string name = "Canada";

            // Act
            var result = CountriesService.FilterCountriesByName(name, data);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FilterCountriesByName_ValidNameAndData_ReturnsFilteredData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
            };
            string name = "Canada";

            // Act
            var result = CountriesService.FilterCountriesByName(name, data);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Canada", result[0]?.Name?.Common);
        }

        [TestMethod]
        public void FilterCountriesByName_EmptyName_ReturnsAllData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
            };
            string name = "";

            // Act
            var result = CountriesService.FilterCountriesByName(name, data);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void FilterCountriesByName_CaseInsensitiveFiltering_ReturnsFilteredData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
            };
            string name = "canada";

            // Act
            var result = CountriesService.FilterCountriesByName(name, data);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Canada", result[0]?.Name?.Common);
        }

        [TestMethod]
        public void FilterCountriesByPopulation_NullPopulation_ReturnsAllData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Population = 331449281 }, // United States
                new Country { Population = 37589262 },  // Canada
            };
            int? population = null;

            // Act
            var result = CountriesService.FilterCountriesByPopulation(population, data);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void FilterCountriesByPopulation_NullData_ReturnsEmptyList()
        {
            // Arrange
            List<Country>? data = null;
            int? population = 40;

            // Act
            var result = CountriesService.FilterCountriesByPopulation(population, data);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FilterCountriesByPopulation_ValidPopulationAndData_ReturnsFilteredData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Population = 351449281 }, // United States
                new Country { Population = 37589262 },  // Canada
            };
            int? population = 350;

            // Act
            var result = CountriesService.FilterCountriesByPopulation(population, data);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(37589262, result[0].Population);
        }

        [TestMethod]
        public void FilterCountriesByPopulation_NoCountriesWithPopulationLessThanInput_ReturnsEmptyList()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Population = 331449281 }, // United States
                new Country { Population = 37589262 },  // Canada
            };
            int? population = 10; // Very low population to check for no countries matching

            // Act
            var result = CountriesService.FilterCountriesByPopulation(population, data);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SortCountriesByName_NullOrder_ReturnsOriginalData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "United States" }},
            };
            string? order = null;

            // Act
            var result = CountriesService.SortCountriesByName(order, data);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Canada", result[0]?.Name?.Common);
            Assert.AreEqual("United States", result[1]?.Name?.Common);
        }

        [TestMethod]
        public void SortCountriesByName_InvalidOrder_ReturnsOriginalData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "United States" }},
            };
            string order = "random";

            // Act
            var result = CountriesService.SortCountriesByName(order, data);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Canada", result[0]?.Name?.Common);
            Assert.AreEqual("United States", result[1]?.Name?.Common);
        }

        [TestMethod]
        public void SortCountriesByName_NullData_ReturnsEmptyList()
        {
            // Arrange
            List<Country>? data = null;
            string order = "ascend";

            // Act
            var result = CountriesService.SortCountriesByName(order, data);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SortCountriesByName_AscendingOrder_ReturnsSortedData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "United States" }},
            };
            string order = "ascend";

            // Act
            var result = CountriesService.SortCountriesByName(order, data);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Canada", result[0]?.Name?.Common);
            Assert.AreEqual("United States", result[1]?.Name?.Common);
        }

        [TestMethod]
        public void SortCountriesByName_DescendingOrder_ReturnsSortedData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "United States" }},
            };
            string order = "descend";

            // Act
            var result = CountriesService.SortCountriesByName(order, data);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("United States", result[0]?.Name?.Common);
            Assert.AreEqual("Canada", result[1]?.Name?.Common);
        }

        [TestMethod]
        public void ApplyPagination_NullTake_ReturnsAllData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "Mexico" }}
            };
            int? take = null;

            // Act
            var result = CountriesService.ApplyPagination(take, data);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void ApplyPagination_NegativeTake_ReturnsAllData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "Mexico" }}
            };
            int? take = -3;

            // Act
            var result = CountriesService.ApplyPagination(take, data);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void ApplyPagination_NullData_ReturnsEmptyList()
        {
            // Arrange
            List<Country>? data = null;
            int? take = 2;

            // Act
            var result = CountriesService.ApplyPagination(take, data);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ApplyPagination_ValidTakeAndData_ReturnsPaginatedData()
        {
            // Arrange
            var data = new List<Country>
            {
                new Country { Name = new Name { Common = "United States" }},
                new Country { Name = new Name { Common = "Canada" }},
                new Country { Name = new Name { Common = "Mexico" }}
            };
            int? take = 2;

            // Act
            var result = CountriesService.ApplyPagination(take, data);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("United States", result[0]?.Name?.Common);
            Assert.AreEqual("Canada", result[1]?.Name?.Common);
        }
    }
}

