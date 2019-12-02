using System;
using ServiceExample.ApplicationCore.Mappers;
using ServiceExample.Entity.Entities;
using ServiceExample.Web.Adapters;
using ServiceExample.ApplicationCore.Dtos;
using Xunit;

namespace ServiceExample.UnitTests.Web.Mapper
{
    public class WebMapperTests
    {
        [Fact]
        public void MaintenanceTaskMapToDto()
        {
            // Actual Dtobject.
            var actualDto = FactoryMaintenanceTaskMapper.Map(new FactoryMaintenanceTask()
            {
                FactoryDeviceId = 1,
                FactoryDevice = new FactoryDevice() {Name = "testdevice", Type = "type1", Year = 2019},
                FactoryMaintenanceTaskId = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
                TaskRegistrationDate = new DateTime(2019, 12, 31),
                PriorityId = Priority.Critical,
                Description = "Test description",
                TaskIsCompleted = true
            });

            // Expected Dtobject.
            var expectedDto = new FactoryMaintenanceTaskDto()
            {
                FactoryDeviceId = 1,
                FactoryDevice = new FactoryDeviceDto() { Name = "testdevice",Type = "type1", Year = 2019},
                FactoryMaintenanceTaskId = Guid.Parse("3F2504E0-4F89-11D3-9A0C-0305E82C3301"),
                TaskRegistrationDate = new DateTime(2019, 12, 31),
                PriorityId = Priority.Critical,
                Description = "Test description",
                TaskIsCompleted = true
            };
            
            Assert.NotNull(actualDto);
            Assert.Equal(actualDto.TaskRegistrationDate, expectedDto.TaskRegistrationDate);
            Assert.Equal(actualDto.FactoryDeviceId, expectedDto.FactoryDeviceId);
            Assert.NotNull(actualDto.FactoryDevice);
            Assert.NotNull(expectedDto.FactoryDevice);
            Assert.Equal(actualDto.FactoryMaintenanceTaskId, expectedDto.FactoryMaintenanceTaskId);
            Assert.Equal(actualDto.PriorityId, expectedDto.PriorityId);
            Assert.Equal(actualDto.Description, expectedDto.Description);
            Assert.Equal(actualDto.TaskIsCompleted, expectedDto.TaskIsCompleted);
        }

    }
}