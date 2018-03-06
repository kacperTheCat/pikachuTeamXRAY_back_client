
using System.Threading.Tasks;
using ContractLibrary.Interfaces;
using ContractLibrary.Models;
using FluentAssertions;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test
    {
        //private IConnectionAcquisition _connectionAcquisition;

        //[TestInitialize]
        //public void Initalize(IConnectionAcquisition connectionAcquisition)
        //{
        //    _connectionAcquisition = connectionAcquisition;
        //}
        [TestMethod]
        public async Task GetDetailsShouldReturnConnectionDetailsTest()
        {
            //arang

            var connectionDetails = new ConnectionAcquisition();

            //act
            var result = await connectionDetails.GetDetails();
            
            //assert
            result.Version.Should().Be(1);
            result.DeviceName.Should().StartWith("X-Ray-/").And.Should().NotBeNull();
            result.IpAddress.Should().NotBeNull();
        }
    }
}
