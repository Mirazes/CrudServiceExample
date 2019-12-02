using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServiceExample.Entity.Entities;
using ServiceExample.Entity.Interfaces;

namespace ServiceExample.Entity.LiteDb
{
    public class LiteDb : IDatabase
    {
        public IEnumerable<FactoryDevice> GetAllFactoryDevices()
            => LiteDbHelper.GetCollection<FactoryDevice>("FactoryDevices").FindAll();


        public FactoryDevice GetSingleFactoryDevice(int factoryDeviceId)
            => LiteDbHelper.GetCollection<FactoryDevice>("FactoryDevices")
                .FindOne(x => x.DeviceId == factoryDeviceId);

        public FactoryMaintenanceTask GetSingleFactoryMaintenanceTasks(Guid factoryMaintenanceTaskId)
            => LiteDbHelper.GetCollection<FactoryMaintenanceTask>("FactoryMaintenanceTasks")
                .FindOne(x => x.FactoryMaintenanceTaskId == factoryMaintenanceTaskId);

        /// <summary>
        /// Read .csv file and insert result to database.
        /// </summary>
        /// <returns></returns>
        public bool GenerateFactoryDevices()
        {
            // Read.csv file and split it values to variable, skip first line as it's column header.
            // .csv file must be in format:
            // Name,Year,Type
            // Device 0,2004,Type 19
            // Device 1,2005,Type 23
            // ..

            var idCount = 0;
            var csvFileLines = File.ReadAllLines(@"seeddata.csv").Select(a => a.Split(','));
            var csv = csvFileLines.Select(line => (line.Select(piece => piece))).Skip(1);

            // Store newly created devices to list for bulk insertion call.
            var devices = new List<FactoryDevice>();

            devices.AddRange(csv.Select(x => new FactoryDevice()
            {
                DeviceId = RaiseIdCount(),                  // Get id for each new device.
                Name = x.First(),                           // In .csv first collumn is Name.
                Year = ParseInt(x.ElementAt(1)),    // In .csv second collumn is year.
                Type = x.ElementAt(2)                       // In .csv third collumn is Type.
            }));

            // Insert all devices by once.
            LiteDbHelper.InsertBulk("FactoryDevices", devices);
            return true;

            // Local helper function to raise id by one on each loop.
            int RaiseIdCount()
            {
                idCount++;
                return idCount;
            }

            // Local helper function to safely parse int.
            int ParseInt(string yearString)
            {
                int.TryParse(yearString, out var year);
                return year;
            }
        }

        public bool ClearFactoryDevices()
        {
            // Clear device collection from database.
            return LiteDbHelper.ClearCollection("FactoryDevices");
        }

        public IEnumerable<FactoryMaintenanceTask> GetAllFactoryMaintenanceTasks()
        {
            // Get all tasks and sort result by PriorityId and then by RegistrationDate.
            var maintenanceTasks = LiteDbHelper.GetCollection<FactoryMaintenanceTask>("FactoryMaintenanceTasks")
                .FindAll()
                .OrderByDescending(x => x.PriorityId)
                .ThenByDescending(x => x.TaskRegistrationDate);
            maintenanceTasks
                .ToList()
                .ForEach(x => x.FactoryDevice = GetSingleFactoryDevice(x.FactoryDeviceId));

            return maintenanceTasks;
        }

        public IEnumerable<FactoryMaintenanceTask> GetFilteredByDeviceFactoryMaintenanceTasks(int factoryDeviceId)
        {
            // Get tasks by given device id and sort result by PriorityId and then by RegistrationDate.
            var maintenanceTasks = LiteDbHelper.GetCollection<FactoryMaintenanceTask>("FactoryMaintenanceTasks")
                .FindAll()
                .Where(x => x.FactoryDeviceId == factoryDeviceId)
                .OrderByDescending(x => x.PriorityId)
                .ThenByDescending(x => x.TaskRegistrationDate);

            // Get devices for task.
            maintenanceTasks
                .ToList()
                .ForEach(x => x.FactoryDevice = GetSingleFactoryDevice(x.FactoryDeviceId));

            return maintenanceTasks;
        }

        public bool CreateFactoryMaintenanceTask(FactoryMaintenanceTask factoryMaintenanceTask)
        {
            // Set Guid and creation time for new task.
            factoryMaintenanceTask.FactoryMaintenanceTaskId = Guid.NewGuid();
            factoryMaintenanceTask.TaskRegistrationDate = DateTime.Now;

            // Get device object for entity, in case not found just ignore device addition.
            var deviceForTask = GetSingleFactoryDevice(factoryMaintenanceTask.FactoryDeviceId);
            if (deviceForTask != null) factoryMaintenanceTask.FactoryDevice = deviceForTask;

            return LiteDbHelper.Insert("FactoryMaintenanceTasks", factoryMaintenanceTask);
        }

        public bool UpdateFactoryMaintenanceTask(FactoryMaintenanceTask factoryMaintenanceTask)
            => LiteDbHelper.Update("FactoryMaintenanceTasks", factoryMaintenanceTask);

        public bool DeleteFactoryMaintenanceTask(Guid factoryMaintenanceTaskId)
            => LiteDbHelper.DeleteFactoryMaintenanceTask("FactoryMaintenanceTasks", factoryMaintenanceTaskId);
    }
}