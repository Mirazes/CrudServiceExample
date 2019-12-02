using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.Entity.Entities;

namespace ServiceExample.ApplicationCore.Interfaces
{
    /// <summary>
    /// Factory maintenance tasks service layer interface.
    /// </summary>
    public interface IFactoryMaintenanceTaskService
    {
        IEnumerable<FactoryMaintenanceTaskDto> GetAllFactoryMaintenanceTasks();
        IEnumerable<FactoryMaintenanceTaskDto> GetFilteredByDeviceFactoryMaintenanceTasks(int factoryDeviceId);
        FactoryMaintenanceTaskDto GetSingleFactoryMaintenanceTasks(Guid factoryMaintenanceTaskId);
        bool CreateFactoryMaintenanceTask(FactoryMaintenanceTaskDto factoryMaintenanceTask);
        bool UpdateFactoryMaintenanceTask(FactoryMaintenanceTaskDto factoryMaintenanceTask);
        bool DeleteFactoryMaintenanceTask(Guid factoryMaintenanceTaskId);
 

    }
}