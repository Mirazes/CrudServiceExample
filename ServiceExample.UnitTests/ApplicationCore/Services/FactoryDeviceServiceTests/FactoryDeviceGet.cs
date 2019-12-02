using System;
using System.Linq;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Services;
using ServiceExample.Entity.LiteDb;
using Xunit;

namespace ServiceExample.UnitTests.ApplicationCore.Services.FactoryDeviceServiceTests
{
    public class FactoryDeviceGet
    {

        [Fact]
        public void NonExistingCardWithId()
        {
            IFactoryDeviceService FactoryDeviceService = new FactoryDeviceService(new LiteDb());
            int factoryDeviceId = 4;

            var singleFactoryDevice =  FactoryDeviceService.GetSingleFactoryDevice(factoryDeviceId);

            Assert.Null(singleFactoryDevice);
        }
    }
}

