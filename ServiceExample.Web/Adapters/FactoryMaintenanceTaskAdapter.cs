using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;

namespace ServiceExample.Web.Adapters
{
    /// <summary>
    /// FactoryMaintenanceTask adapters.
    /// </summary>
    public class FactoryMaintenanceTaskAdapter
    {
        /// <summary>
        /// Convert given FactoryMaintenanceTaskDto to anonymous object.
        /// </summary>
        /// <param name="factoryMaintenanceTasks"></param>
        /// <returns></returns>
        public static object ToAnonymousObject(FactoryMaintenanceTaskDto factoryMaintenanceTasks)
        {
            return new
            {
                factoryMaintenanceTaskId = factoryMaintenanceTasks.FactoryMaintenanceTaskId,
                description = factoryMaintenanceTasks.Description,
                taskIsCompleted = factoryMaintenanceTasks.TaskIsCompleted ? "Maintained" : "Open",
                priority = factoryMaintenanceTasks.PriorityId.ToString("g"),
                taskRegistrationDate = factoryMaintenanceTasks.TaskRegistrationDate,
                factoryDevice = factoryMaintenanceTasks.FactoryDevice,
                factoryDeviceId = factoryMaintenanceTasks.FactoryDeviceId,
            };
        }

        /// <summary>
        /// Convert list of FactoryMaintenanceTaskDto to list of anonymous objects.
        /// </summary>
        /// <param name="factoryMaintenanceTasks"></param>
        /// <returns></returns>
        public static object ToAnonymousObject(IEnumerable<FactoryMaintenanceTaskDto> factoryMaintenanceTasks)
        => factoryMaintenanceTasks.Select(ToAnonymousObject);
        

    }
}
