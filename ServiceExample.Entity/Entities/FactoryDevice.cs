using LiteDB;

namespace ServiceExample.Entity.Entities
{
    /// <summary>
    /// POCO model of FactoryDevice.
    /// </summary>
    public class FactoryDevice
    {
        public ObjectId _id { get; set; } = ObjectId.NewObjectId();
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
    }
}
