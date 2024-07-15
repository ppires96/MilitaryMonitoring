using MilitaryMonitoring.Models;
using System.Windows;

namespace MilitaryMonitoring.ViewModels
{
    public class LocationMapViewModel : ViewModelBase
    {
        private readonly TrainingContext _context;
        private Soldier _soldier;
        private Timer _timer;
        private string _commandName;

        public LocationMapViewModel(Soldier soldier, string commandName = null)
        {
            _soldier = soldier;
            _commandName = commandName;
            _context = new TrainingContext();

            SetupCanvasPosition();
            TryInitializeTimer();
        }

        private string position;
        public string Position
        {
			get { return position; }
			set
            { 
                position = value;
                OnPropertyChanged();
            }
		}

        // Initialize and start the timer to fetch the soldier's position every 5 seconds.
        private void TryInitializeTimer()
        {
            if (_commandName != null && _commandName == "TrackSoldier")
                _timer = new Timer(UpdateSoldierPosition, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void SetupCanvasPosition()
        {
            Position soldierPosition = GetSoldiersPosition();
            Position = soldierPosition?.Latitude.ToString() + "," + soldierPosition?.Longitude.ToString();
        }

        private Position GetSoldiersPosition()
        {
            Position position = null;
            try
            {
                using (var context = new TrainingContext())
                {
                    position = context.Positions.FirstOrDefault(p => p.SoldierID == _soldier.SoldierID);
                }
            }
            catch (Exception e){ 
                // Logging and handling (maybe a warning/info message) - could not found position for the selected soldier.
            }

            return position;

        }

        private void UpdateSoldierPosition(object state)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                PaintMapWithCurrentPosition();
                SetupCanvasPosition();
            });
        }

        private void PaintMapWithCurrentPosition()
        {
            // Currently, in this application, the position in the map does update if the position of the soldier changes.
            // But it is not keeping track of previous positions.
            // That's what I would/will do in this method.
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


    }
}
