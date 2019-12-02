using System;
using System.Linq;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Services;
using ServiceExample.Entity.Entities;
using ServiceExample.Web.Adapters;
using Xunit;

namespace ServiceExample.UnitTests.Web.Adapters
{
    public class WebAdapterTests
    {
        [Fact]
        public void MaintenanceTaskAdapterNotNull()
        {

            var testDto = new FactoryMaintenanceTaskDto()
            {
                FactoryDeviceId = 1,
                FactoryDevice = new FactoryDeviceDto() { Id = 1,Name = "testdevice",Type = "type1", Year = 2019},
                FactoryMaintenanceTaskId = Guid.NewGuid(),
                TaskRegistrationDate = new DateTime(2019, 12, 31),
                PriorityId = Priority.Critical,
                Description = "Test description",
                TaskIsCompleted = true
            };

            var testObject = FactoryMaintenanceTaskAdapter.ToAnonymousObject(testDto);

            Assert.NotNull(testObject);
            Assert.Contains("AnonymousType", testObject.GetType().ToString());
     
        }

    }
}