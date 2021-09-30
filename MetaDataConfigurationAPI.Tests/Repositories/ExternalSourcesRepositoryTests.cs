using MetaDataConfigurationAPI.Client;
using MetaDataConfigurationAPI.Repository.RepoClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.Tests.Repositories
{
    [TestFixture]
    class ExternalSourcesRepositoryTests
    {
        private Mock<IExternalClient> _mockExternalClient;
        private ExternalSourcesRepository _externalSourcesRepository;

        [SetUp]
        public void Setup()
        {
            _mockExternalClient = new Mock<IExternalClient>();
            _externalSourcesRepository = new ExternalSourcesRepository(_mockExternalClient.Object);
        }
        [Test]
        public async Task RetrieveDataFromExternalSourcesAsync_CallsExternalAPIAsync()
        {
            //Arrange
            string input = "fakedata";

            //Act
            string response = await _externalSourcesRepository.RetrieveDataFromExternalSourcesAsync(input);

            //Assert
            _mockExternalClient.Verify(x => x.CallExternalAPIAsync(input), Times.Once);
        }
    }
}
