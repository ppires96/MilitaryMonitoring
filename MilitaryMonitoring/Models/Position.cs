namespace MilitaryMonitoring.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        public Guid SoldierID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
