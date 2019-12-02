namespace ServiceExample.ApplicationCore.Dtos
{
    /// <summary>
    /// Data transfer object of FactoryDevice.
    /// </summary>
    public class FactoryDeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
    }
}