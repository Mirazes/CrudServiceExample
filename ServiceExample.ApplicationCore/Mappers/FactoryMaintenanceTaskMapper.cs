using System.Collections.Generic;
using System.Linq;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.Entity.Entities;

namespace ServiceExample.ApplicationCore.Mappers
{
    /// <summary>
    /// Easy mapper class to transform database models to convenient Dto objects.
    /// </summary>
    public class FactoryMaintenanceTaskMapper
    {

        /// <summary>
        /// Map FactoryMaintenanceTask to FactoryMaintenanceTaskDto object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static FactoryMaintenanceTaskDto Map(FactoryMaintenanceTask source)
        {
            if(source == null) return new FactoryMaintenanceTaskDto();

            var dtoObject = new FactoryMaintenanceTaskDto
            {
                FactoryDeviceId = source.FactoryDeviceId,
                Description = source.Description,
                PriorityId = source.PriorityId,
                TaskRegistrationDate = source.TaskRegistrationDate,
                TaskIsCompleted = source.TaskIsCompleted,
                FactoryDevice = FactoryDeviceMapper.Map(source.FactoryDevice),
                FactoryMaintenanceTaskId = source.FactoryMaintenanceTaskId
            };

            return dtoObject;
        }

        public static FactoryMaintenanceTask Map(FactoryMaintenanceTaskDto source)
        {
            if(source == null) return new FactoryMaintenanceTask();

            var taskObject = new FactoryMaintenanceTask
            {
                FactoryDeviceId = source.FactoryDeviceId,
                Description = source.Description,
                PriorityId = source.PriorityId,
                TaskRegistrationDate = source.TaskRegistrationDate,
                TaskIsCompleted = source.TaskIsCompleted,
                FactoryDevice = FactoryDeviceMapper.Map(source.FactoryDevice),
                FactoryMaintenanceTaskId = source.FactoryMaintenanceTaskId
            };

            return taskObject;
        }

        public static IEnumerable<FactoryMaintenanceTaskDto> Map(IEnumerable<FactoryMaintenanceTask> factoryMaintenanceTasks)
            => factoryMaintenanceTasks.Select(Map);
    
    }
}
