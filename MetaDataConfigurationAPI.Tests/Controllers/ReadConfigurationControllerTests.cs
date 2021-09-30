using MetaDataConfigurationAPI.Controllers;
using MetaDataConfigurationAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Tests.Controllers
{
    [TestFixture]
    class ReadConfigurationControllerTests
    {
        private Mock<IReadRepository> _mockReadRepository;
        private ReadConfigurationController _readConfigurationController;

        [SetUp]
        public void Setup()
        {
            _mockReadRepository = new Mock<IReadRepository>();
            _readConfigurationController = new ReadConfigurationController(_mockReadRepository.Object);
        }

        [Test]
        public void GetConfigurationDataFromAllSources_HasCorrectHttpAttribute()
        {
            //Arrange
            var expectedType = typeof(HttpGetAttribute);
            string methodName = "GetConfigurationDataFromAllSources";

            //Act
            var hasAttribute = _readConfigurationController.GetType().GetMethods()
                .First(x => x.Name == methodName).GetCustomAttributes().Any(y => y.GetType().Equals(expectedType));

            //Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public async Task GetConfigurationDataFromAllSources_CallsReadRepositoryAndReturnsOkayResultAsync()
        {
            //Act
            var result = await _readConfigurationController.GetConfigurationDataFromAllSources();

            //Assert
            _mockReadRepository.Verify(x => x.GetAllConfigurationDataAsync(), Times.Once);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

    }
}
