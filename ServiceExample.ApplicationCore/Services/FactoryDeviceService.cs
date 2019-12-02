using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Mappers;
using ServiceExample.Entity.Entities;
using ServiceExample.Entity.Interfaces;

namespace ServiceExample.ApplicationCore.Services
{
    /// <summary>
    /// Factory device service executes entity level calls to the database.
    /// Used to return data and modify data in database.
    /// </summary>
    public class FactoryDeviceService : IFactoryDeviceService
    {
        private readonly IDatabase _liteDb;

        /// <summary>
        /// Constructor of FactoryDeviceService, injects IDatabase.
        /// </summary>
        /// <param name="liteDb"></param>
        public FactoryDeviceService(IDatabase liteDb) 
            => _liteDb = liteDb;

        /// <summary>
        /// Returns all factory devices from entity layer to the service layer.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FactoryDeviceDto> GetAllFactoryDevices()
            => FactoryDeviceMapper.Map(_liteDb.GetAllFactoryDevices());
        
        /// <summary>
        /// Returns single factory device by id from entity layer to the service layer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryDeviceDto GetSingleFactoryDevice(int id)
            => FactoryDeviceMapper.Map(_liteDb.GetSingleFactoryDevice(id));
        
        /// <summary>
        /// Generates factory devices to the database.
        /// </summary>
        /// <returns></returns>
        public bool GenerateFactoryDevices()
            => _liteDb.GenerateFactoryDevices();
        
        /// <summary>
        /// Clears all factory devices from the database.
        /// </summary>
        /// <returns></returns>
        public bool ClearFactoryDevices()
            => _liteDb.ClearFactoryDevices();

        /// <summary>
        /// Asynchronous returns all factory devices from entity layer to the service layer.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FactoryDeviceDto>> GetAllFactoryDevicesAsync()
            => await Task.FromResult(FactoryDeviceMapper.Map(_liteDb.GetAllFactoryDevices()));

        /// <summary>
        /// Asynchronous returns single factory device by id from entity layer to the service layer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FactoryDeviceDto> GetSingleFactoryDeviceAsync(int factoryDeviceId)
            => await Task.FromResult(FactoryDeviceMapper.Map(_liteDb.GetSingleFactoryDevice(factoryDeviceId)));
        
    }
}