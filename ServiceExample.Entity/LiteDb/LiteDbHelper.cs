using System;
using System.Collections.Generic;
using ServiceExample.Entity.Utils;
using LiteDB;
using ServiceExample.Entity.Entities;

namespace ServiceExample.Entity.LiteDb
{
    public class LiteDbHelper
    {
        private static readonly string _dbContext = @"ServiceManualDatabase.db";

        /// <summary>
        /// Insert single generic entity to the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entity"></param>
        /// <returns>True if success.</returns>
        public static bool Insert<T>(string collectionName, T entity)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                // Get user collection
                var collection = database.GetCollection<T>(collectionName);

                // Insert given entity to collection.
                return collection != null && collection.Upsert(entity);
            }
        }

        /// <summary>
        /// Insert generic entity list to database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="entities"></param>
        public static void InsertBulk<T>(string collectionName, IEnumerable<T> entities)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                // Get user collection
                var collection = database.GetCollection<T>(collectionName);

                // Insert only to empty collection.
                if (collection.Count() == 0)
                {
                    collection.InsertBulk(entities);
                }
            }
        }

        /// <summary>
        /// Query collection and return all documents inside of it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns>LiteCollection<T></returns>
        public static LiteCollection<T> GetCollection<T>(string collectionName)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                // Get user collection
                return database.GetCollection<T>(collectionName);
            }
        }

        /// <summary>
        /// Clear given collection.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns>True if success.</returns>
        public static bool ClearCollection(string collectionName)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                // Get user collection
                return database.DropCollection(collectionName);
            }
        }

        /// <summary>
        /// Update given task to the database.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="factoryMaintenanceTask"></param>
        /// <returns>True if success.</returns>
        public static bool Update(string collectionName, FactoryMaintenanceTask factoryMaintenanceTask)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                var collection = database.GetCollection<FactoryMaintenanceTask>(collectionName);
                var taskToUpdate = collection.FindOne(x =>
                    x.FactoryMaintenanceTaskId == factoryMaintenanceTask.FactoryMaintenanceTaskId);

                if (taskToUpdate == null) return false;

                // Update device if id is not equal.
                if (taskToUpdate.FactoryDevice.DeviceId != factoryMaintenanceTask.FactoryDeviceId)
                {
                    taskToUpdate.FactoryDevice = GetCollection<FactoryDevice>("FactoryDevices")
                        .FindOne(x => x.DeviceId == factoryMaintenanceTask.FactoryDeviceId);
                }

                FactoryMaintetanceTaskMapper.Map(taskToUpdate, factoryMaintenanceTask);

                // Update task and return result of operation.
                return collection.Update(taskToUpdate);
            }
        }

        /// <summary>
        /// Delete given task from the database.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="factoryMaintenanceTaskId"></param>
        /// <returns>True if success.</returns>
        public static bool DeleteFactoryMaintenanceTask(string collectionName, Guid factoryMaintenanceTaskId)
        {
            using (var database = new LiteDatabase(_dbContext))
            {
                var collection = database.GetCollection<FactoryMaintenanceTask>(collectionName);
                var factoryMaintenanceTaskToDelete =
                    collection.FindOne(x => x.FactoryMaintenanceTaskId == factoryMaintenanceTaskId);

                return factoryMaintenanceTaskToDelete != null && collection.Delete(factoryMaintenanceTaskToDelete?._id);
            }
        }
    }
}