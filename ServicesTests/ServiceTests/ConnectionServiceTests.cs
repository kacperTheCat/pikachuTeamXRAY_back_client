using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using ServicesLibrary.Classes;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;

namespace ServicesTests.Classes
{
    [TestClass]
    public class ConnectionServiceTests
    {
        private IConnectionAcquisition _connectionAcquisition;
        [TestInitialize]
        public void Initialize()
        {
            _connectionAcquisition = new ConnectionAcquisition();
        }

        [TestMethod]
        public async Task GetDetailsTest()
        {
            //Arange
            var connectionService = new ConnectionService(_connectionAcquisition);
            
            //Act
            var result = await connectionService.GetDetails();
            
            //Assert
            result.IpAddress.Should().NotBeNull();
            result.IpAddress.Should().BeOfType<string>();
            result.IpAddress.Should().Match("*.*.*.*");

            result.Version.Should().NotBe(null);
            result.Version.Should().Be(1);

            result.DeviceName.Should().StartWith("X-Ray-/");
            result.DeviceName.Should().BeOfType<string>();
            result.DeviceName.Should().NotBeNull();
        }
    }
}
