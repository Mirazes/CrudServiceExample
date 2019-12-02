using System.Collections.Generic;
using System.Linq;
using ServiceExample.ApplicationCore.Dtos;

namespace ServiceExample.Web.Adapters
{
    /// <summary>
    /// FactoryDevice adapters.
    /// </summary>
    public class FactoryDeviceAdapter
    {
        /// <summary>
        /// Convert given FactoryDeviceDto to anonymous object.
        /// </summary>
        /// <param name="factoryDevices"></param>
        /// <returns></returns>
        public static object ToAnonymousObject(FactoryDeviceDto factoryDevices)
        {
            return new
            {
                id = factoryDevices.Id,
                name = factoryDevices.Name,
                year = factoryDevices.Year,
                type = factoryDevices.Type
            };
        }

        /// <summary>
        /// Convert list of FactoryMaintenanceTaskDto to list of anonymous objects.
        /// </summary>
        /// <returns></returns>
        public static object ToAnonymousObject(IEnumerable<FactoryDeviceDto> factoryDeviceDtos)
            => factoryDeviceDtos.Select(ToAnonymousObject);
        

    }
}