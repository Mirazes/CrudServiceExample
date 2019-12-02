using ServiceExample.Entity.Entities;

namespace ServiceExample.Entity.Utils
{
    /// <summary>
    /// ClassBuilder is used to easily update similar objects. 
    /// </summary>
    public class FactoryMaintetanceTaskMapper
    {
        /// <summary>
        /// Build FactoryMaintenanceTask by given updateTask.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="updateTask"></param>
        /// <returns>Updated FactoryMaintenanceTask</returns>
        public static FactoryMaintenanceTask Map(FactoryMaintenanceTask source, FactoryMaintenanceTask updateTask)
        {
            if (source == null || updateTask == null) return new FactoryMaintenanceTask();
            source.FactoryDeviceId = updateTask.FactoryDeviceId;
            source.Description = updateTask.Description;
            source.PriorityId = updateTask.PriorityId;
            source.TaskIsCompleted = updateTask.TaskIsCompleted;

            return source;
        }

    }
}
