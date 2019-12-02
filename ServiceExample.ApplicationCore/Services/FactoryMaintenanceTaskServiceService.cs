using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Mappers;
using ServiceExample.Entity.Entities;
using ServiceExample.Entity.Interfaces;

namespace ServiceExample.ApplicationCore.Services
{
    /// <summary>
    /// Factory maintenance task service executes entity level calls to the database.
    /// Used to return data and modify data in database.
    /// </summary>
    public class FactoryMaintenanceTaskServiceService : IFactoryMaintenanceTaskService
    {
        private readonly IDatabase _liteDb;

        public FactoryMaintenanceTaskServiceService(IDatabase liteDb)
        {
            _liteDb = liteDb;
        }

        /// <summary>
        /// Returns all factory maintenance tasks from entity layer to the service layer.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FactoryMaintenanceTaskDto> GetAllFactoryMaintenanceTasks()
            => FactoryMaintenanceTaskMapper.Map(_liteDb.GetAllFactoryMaintenanceTasks());

        /// <summary>
        /// Returns all factory maintenance tasks filtered by given device id from entity layer to the service layer.
        /// </summary>
        /// <param name="factoryDeviceId"></param>
        /// <returns></returns>
        public IEnumerable<FactoryMaintenanceTaskDto> GetFilteredByDeviceFactoryMaintenanceTasks(int factoryDeviceId)
            => FactoryMaintenanceTaskMapper.Map(_liteDb.GetFilteredByDeviceFactoryMaintenanceTasks(factoryDeviceId));

        /// <summary>
        /// Returns single factory maintenance task from entity layer to the service layer.
        /// </summary>
        /// <param name="factoryMaintenanceTaskId"></param>
        /// <returns></returns>
        public FactoryMaintenanceTaskDto GetSingleFactoryMaintenanceTasks(Guid factoryMaintenanceTaskId)
            => FactoryMaintenanceTaskMapper.Map(_liteDb.GetSingleFactoryMaintenanceTasks(factoryMaintenanceTaskId));

        /// <summary>
        /// Create single factory maintenance task to the database.
        /// In this case Upsert is used to insert or update task in database.
        /// </summary>
        /// <param name="factoryMaintenanceTask"></param>
        /// <returns></returns>
        public bool CreateFactoryMaintenanceTask(FactoryMaintenanceTaskDto factoryMaintenanceTask)
            => _liteDb.CreateFactoryMaintenanceTask(FactoryMaintenanceTaskMapper.Map(factoryMaintenanceTask));

        /// <summary>
        /// Update single factory maintenance task to the database.
        /// </summary>
        /// <param name="factoryMaintenanceTask"></param>
        /// <returns></returns>
        public bool UpdateFactoryMaintenanceTask(FactoryMaintenanceTaskDto factoryMaintenanceTask)
            => _liteDb.UpdateFactoryMaintenanceTask(FactoryMaintenanceTaskMapper.Map(factoryMaintenanceTask));

        /// <summary>
        /// Delete single factory maintenance task from the database.
        /// </summary>
        /// <param name="factoryMaintenanceTaskId"></param>
        /// <returns></returns>
        public bool DeleteFactoryMaintenanceTask(Guid factoryMaintenanceTaskId)
            => _liteDb.DeleteFactoryMaintenanceTask(factoryMaintenanceTaskId);
    }
}