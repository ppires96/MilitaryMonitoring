namespace MilitaryMonitoring.Models
{
    public class Sensor
    {
        public int SensorID { get; set; }
        public Guid SoldierID { get; set; }
        public string SensorName { get; set; }
        public string SensorType { get; set; }
        public Soldier Soldier { get; set; }
    }
}
