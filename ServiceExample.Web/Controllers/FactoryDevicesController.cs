using System;
using Microsoft.AspNetCore.Mvc;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.Web.Adapters;
using ServiceExample.Web.Utils;

namespace ServiceExample.Web.Controllers
{
    /// <summary>
    ///     FactoryDevices Http actions are handled in this controller.
    /// </summary>
    public class FactoryDevicesController : Controller
    {
        // Service layer is defined here.
        private readonly IFactoryDeviceService _factoryDeviceService;

        /// <summary>
        ///     Constructor for FactoryDeviceService layer.
        /// </summary>
        /// <param name="factoryDeviceService"></param>
        public FactoryDevicesController(IFactoryDeviceService factoryDeviceService)
        {
            _factoryDeviceService = factoryDeviceService;
        }


        /// <summary>
        ///     Generate all devices and add them to database.
        ///     Devices are defined in seeddata.csv.
        /// </summary>
        /// <returns>Http result of generation process.</returns>
        [HttpPost]
        [Route("api/[controller]/generate")]
        public IActionResult GenerateFactoryDevices()
        {
            try
            {
                var generated = _factoryDeviceService.GenerateFactoryDevices();

                if (generated) return new OkResult();
                return new ConflictResult();
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e.Message);
                return new ConflictResult();
            }
        }

        /// <summary>
        ///     Clear all devices from database.
        /// </summary>
        /// <returns>Return Http result after process is completed.</returns>
        [HttpPost]
        [Route("api/[controller]/clear")]
        public IActionResult ClearFactoryDevices()
        {
            try
            {
                var cleared = _factoryDeviceService.ClearFactoryDevices();

                if (cleared) return new OkResult();
                return new ConflictResult();
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e.Message);
                return new ConflictResult();
            }
        }

        /// <summary>
        ///     Return all factory devices.
        /// </summary>
        [HttpGet]
        [Route("api/[controller]")]
        public object GetAllFactoryDevices()
        {
            try
            {
                return FactoryDeviceAdapter.ToAnonymousObject(_factoryDeviceService.GetAllFactoryDevices());
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e.Message);
                return new ConflictResult();
            }
        }


        /// <summary>
        ///     Return single factory device by id.
        /// </summary>
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var singleFactoryDevice = _factoryDeviceService.GetSingleFactoryDevice(id);
                if (singleFactoryDevice.Name == null && singleFactoryDevice.Id != id) return NotFound();

                return Ok(FactoryDeviceAdapter.ToAnonymousObject(singleFactoryDevice));
            }
            catch (Exception e)
            {
                ErrorHandler.LogError(e.Message);
                return new ConflictResult();
            }


        }
    }
}