using System;
using ServiceExample.Entity.Entities;

namespace ServiceExample.ApplicationCore.Dtos
{
    /// <summary>
    /// Data transfer object of FactoryMaintenanceTask.
    /// </summary>
    public class FactoryMaintenanceTaskDto
    {
        public Guid FactoryMaintenanceTaskId { get; set; }
        public FactoryDeviceDto FactoryDevice { get; set; }
        public int FactoryDeviceId { get; set; }
        public DateTime TaskRegistrationDate { get; set; }
        public string Description { get; set; }
        public bool TaskIsCompleted { get; set; }
        public Priority PriorityId { get; set; }
    }
}