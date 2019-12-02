using System.Collections.Generic;
using System.Linq;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.Entity.Entities;

namespace ServiceExample.ApplicationCore.Mappers
{
    /// <summary>
    /// Easy mapper class to transform database models to convenient Dto objects.
    /// </summary>
    public class FactoryDeviceMapper
    {

        /// <summary>
        /// Map FactoryDevice to FactoryDeviceDto object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static FactoryDeviceDto Map(FactoryDevice source)
        {
            if(source == null) return new FactoryDeviceDto();
            var dtoObject = new FactoryDeviceDto()
            {
                Id = source.DeviceId,
                Name = source.Name,
                Year = source.Year,
                Type = source.Type
            };

            return dtoObject;
        }        
        
        /// <summary>
        /// Map FactoryDeviceDto to FactoryDevice object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static FactoryDevice Map(FactoryDeviceDto source)
        {
            if (source == null) return new FactoryDevice();
            var factoryObject = new FactoryDevice()
            {
                DeviceId = source.Id,
                Name = source.Name,
                Type = source.Type,
                Year = source.Year
            };

            return factoryObject;
        }

        public static IEnumerable<FactoryDeviceDto> Map(IEnumerable<FactoryDevice> factoryDevices)
            => factoryDevices.Select(Map);
    }
}