using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceExample.ApplicationCore.Dtos;
using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Mappers;
using ServiceExample.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServiceExample.Web.Controllers
{
    /// <summary>
    /// FactoryMaintenanceTasks Http actions are handled in this controller. 
    /// </summary>
    public class FactoryMaintenanceTasksController : Controller
    {
        // Service layer variable.
        private readonly IFactoryMaintenanceTaskService _factoryMaintenanceTaskService;

        /// <summary>
        /// Constructor for FactoryMaintenanceService layer.
        /// </summary>
        /// <param name="factoryMaintenanceTaskService"></param>
        public FactoryMaintenanceTasksController(IFactoryMaintenanceTaskService factoryMaintenanceTaskService)
        {
            _factoryMaintenanceTaskService = factoryMaintenanceTaskService;
        }

        /// <summary>
        /// Call service layer to obtain all maintenance tasks and convert them with adapter before returning objects from controller.
        /// </summary>
        /// <returns>Anonymous object containing results from service layer call.</returns>
        [Route("api/v1/MaintenanceTasks")]
        [HttpGet]
        public object GetAllFactoryMaintenanceTasks()
            => Adapters.FactoryMaintenanceTaskAdapter
                .ToAnonymousObject(_factoryMaintenanceTaskService.GetAllFactoryMaintenanceTasks());

        /// <summary>
        /// Call service layer to obtain single maintenance task by given taskGuid parameter
        /// and convert them with adapter before returning object from controller.
        /// </summary>
        /// <param name="taskGuid"></param>
        /// <returns>Anonymous object containing single maintenance task.</returns>
        [Route("api/v1/MaintenanceTasks/{taskGuid}")]
        [HttpGet]
        public object GetSingleFactoryMaintenanceTask(Guid taskGuid)
        {
            var singleFactoryMaintenanceTask = _factoryMaintenanceTaskService.GetSingleFactoryMaintenanceTasks(taskGuid);
            if (singleFactoryMaintenanceTask.FactoryMaintenanceTaskId != taskGuid)
            {
                return NotFound();
            }

            return Ok(Adapters.FactoryMaintenanceTaskAdapter.ToAnonymousObject(singleFactoryMaintenanceTask));
        }

        /// <summary>
        /// Call service layer to obtain all maintenance tasks filtered by given FactoryDevice id
        /// and convert them with adapter before returning objects from controller.
        /// </summary>
        /// <param name="factoryDeviceId"></param>
        /// <returns>Anonymous object containing factory maintenance tasks.</returns>
        [Route("api/v1/MaintenanceTasks/Devices/{factoryDeviceId}")]
        [HttpGet]
        public object GetFilteredByDeviceFactoryMaintenanceTasks(int factoryDeviceId)
        => Adapters.FactoryMaintenanceTaskAdapter.ToAnonymousObject(_factoryMaintenanceTaskService.GetFilteredByDeviceFactoryMaintenanceTasks(factoryDeviceId));

        /// <summary>
        /// Call service layer to create new maintenance task along with json in body.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>ActionResult containing result of operation.</returns>
        [Route("api/v1/MaintenanceTasks")]
        [HttpPost]
        public IActionResult CreateFactoryMaintenanceTask([FromBody] JObject json)
        {
            // Convert json from body to FactoryMaintenanceTask object.
            var created = false;
            var factoryMaintenanceTaskJsonObject = json.ToObject<FactoryMaintenanceTaskDto>();
            if (factoryMaintenanceTaskJsonObject != null)
                created = _factoryMaintenanceTaskService.CreateFactoryMaintenanceTask(factoryMaintenanceTaskJsonObject);

            if (created) return new CreatedAtActionResult("CreateFactoryMaintenanceTask", "FactoryMaintenanceTasks", null, null);
            return new ConflictResult();
        }

        /// <summary>
        /// Call service layer to update existing maintenance by given taskGuid and with details of json in body.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="taskGuid"></param>
        /// <returns>ActionResult containing result of operation.</returns>
        [Route("api/v1/MaintenanceTasks/{taskGuid}")]
        [HttpPut]
        public IActionResult UpdateFactoryMaintenanceTask([FromBody]JObject json, Guid taskGuid)
        {
            // Convert json from body to FactoryMaintenanceTask object.
            var updated = false;
            if(json == null) return new ConflictResult();
            var factoryMaintenanceTaskJsonObject = json.ToObject<FactoryMaintenanceTaskDto>();
            if (factoryMaintenanceTaskJsonObject != null)
            {
                factoryMaintenanceTaskJsonObject.FactoryMaintenanceTaskId = taskGuid;
                updated = _factoryMaintenanceTaskService.UpdateFactoryMaintenanceTask(factoryMaintenanceTaskJsonObject);
            }

            if (updated) return new OkResult();
            return new ConflictResult();
        }

        /// <summary>
        /// Call service layer to delete existing maintenance by given taskGuid.
        /// </summary>
        /// <param name="taskGuid"></param>
        /// <returns>ActionResult containing result of operation.</returns>
        [Route("api/v1/MaintenanceTasks/{taskGuid}")]
        [HttpDelete]
        public IActionResult DeleteFactoryMaintenanceTask(Guid taskGuid)
        {
            var deleted = _factoryMaintenanceTaskService.DeleteFactoryMaintenanceTask(taskGuid);

            if (deleted) return new OkResult();
            return new ConflictResult();
        }
    }
}