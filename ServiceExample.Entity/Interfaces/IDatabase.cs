using System;
using System.Collections.Generic;
using ServiceExample.Entity.Entities;

namespace ServiceExample.Entity.Interfaces
{
    /// <summary>
    /// This class contains all database command and queries needed for ServiceManual.
    /// </summary>
    public interface IDatabase
    {
        // Device interfaces.
        IEnumerable<FactoryDevice> GetAllFactoryDevices();
        FactoryDevice GetSingleFactoryDevice(int factoryDeviceId);
        bool GenerateFactoryDevices();
        bool ClearFactoryDevices();

        // MaintenanceTasks interfaces.
        IEnumerable<FactoryMaintenanceTask> GetAllFactoryMaintenanceTasks();
        IEnumerable<FactoryMaintenanceTask> GetFilteredByDeviceFactoryMaintenanceTasks(int factoryDeviceId);
        FactoryMaintenanceTask GetSingleFactoryMaintenanceTasks(Guid factoryMaintenanceTaskId);
        bool CreateFactoryMaintenanceTask(FactoryMaintenanceTask factoryMaintenanceTask);
        bool UpdateFactoryMaintenanceTask(FactoryMaintenanceTask factoryMaintenanceTask);
        bool DeleteFactoryMaintenanceTask(Guid factoryMaintenanceTaskId);
    }
}