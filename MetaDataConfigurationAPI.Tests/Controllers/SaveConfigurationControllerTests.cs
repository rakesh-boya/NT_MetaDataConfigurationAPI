using MetaDataConfigurationAPI.Controllers;
using MetaDataConfigurationAPI.Models;
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
    class SaveConfigurationControllerTests
    {
        private Mock<ISaveRepository> _mockSaveRepository;
        private SaveConfigurationController _saveConfigurationController;

        [SetUp]
        public void SetUp()
        {
            _mockSaveRepository = new Mock<ISaveRepository>();
            _saveConfigurationController = new SaveConfigurationController(_mockSaveRepository.Object);
        }

        [Test]
        public void SaveConfigurationData_HasCorrectHttpAttribute()
        {
            //Arrange
            var expectedType = typeof(HttpPostAttribute);
            string methodName = "SaveConfigurationData";

            //Act
            var hasAttribute = _saveConfigurationController.GetType().GetMethods()
                .First(x => x.Name == methodName).GetCustomAttributes().Any(y => y.GetType().Equals(expectedType));

            //Assert
            Assert.IsTrue(hasAttribute);
        }

        [Test]
        public async Task SaveConfigurationData_InvalidModelReturnsBadRequest()
        {
            //Arrange
            var fakeRequest = GenerateFakeInvalidRequest();

            //Act
            var response = await _saveConfigurationController.SaveConfigurationData(fakeRequest);

            //Assert
            _mockSaveRepository.Verify(x => x.SaveConfigurationDataAsync(fakeRequest), Times.Never);
            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public async Task SaveConfigurationData_ValidModelReturnsOkayResult()
        {
            //Arrange
            var fakeRequest = GenerateFakeValidRequest();

            //Act
            var response = await _saveConfigurationController.SaveConfigurationData(fakeRequest);

            //Assert
            _mockSaveRepository.Verify(x => x.SaveConfigurationDataAsync(fakeRequest), Times.Once);
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        private SaveRequestDto GenerateFakeValidRequest()
        {
            SaveRequestDto saveRequestDto = new SaveRequestDto();
            saveRequestDto.EntityName = "Product";
            return saveRequestDto;
        }

        private SaveRequestDto GenerateFakeInvalidRequest()
        {
            SaveRequestDto saveRequestDto = new SaveRequestDto();
            saveRequestDto.EntityName = null;
            saveRequestDto.Fields = null;
            return saveRequestDto;
        }
    }
}
