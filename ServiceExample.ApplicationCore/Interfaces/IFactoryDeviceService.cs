using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.Entity.Entities;

namespace ServiceExample.ApplicationCore.Interfaces
{
    /// <summary>
    /// Factory Device service layer interface.
    /// </summary>
    public interface IFactoryDeviceService
    {
        IEnumerable<FactoryDeviceDto> GetAllFactoryDevices();
        Task<IEnumerable<FactoryDeviceDto>> GetAllFactoryDevicesAsync();
        FactoryDeviceDto GetSingleFactoryDevice(int factoryDeviceId);
        Task<FactoryDeviceDto> GetSingleFactoryDeviceAsync(int factoryDeviceId);
        bool GenerateFactoryDevices();
        bool ClearFactoryDevices();

    }
}