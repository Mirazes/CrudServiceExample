using System;
using LiteDB;

namespace ServiceExample.Entity.Entities
{ 
    public enum Priority : byte
    {
        Default = 1,
        Important = 2,
        Critical = 3
    };

    /// <summary>
    /// POCO model of FactoryMaintenanceTask.
    /// </summary>
    public class FactoryMaintenanceTask
    {
        [BsonId(true)]
        public ObjectId _id { get; set; }
        public int FactoryDeviceId { get; set; }
        public FactoryDevice FactoryDevice { get; set; }
        public DateTime TaskRegistrationDate { get; set; }
        public string Description { get; set; }
        public bool TaskIsCompleted { get; set; }
        public Priority PriorityId { get; set; }
        public Guid FactoryMaintenanceTaskId { get; set; }
    }
}