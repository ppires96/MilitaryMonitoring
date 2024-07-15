namespace MilitaryMonitoring.Models
{
    public class Training
    {
        public int TrainingID { get; set; }
        public Guid SoldierID { get; set; }
        public string TrainingInfo { get; set; }
        public Soldier Soldier { get; set; }
    }
}
