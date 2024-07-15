using MilitaryMonitoring.Models;
using MilitaryMonitoring.Views;
using System.Collections.ObjectModel;

namespace MilitaryMonitoring.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly TrainingContext _context;

        // The first plan was to only enable the button if there is a soldier selected, but I am missing something.
        //  public MVVM.RelayCommand LocateCommand => new MVVM.RelayCommand(execute => LocateSoldier(SelectedSoldier), canExecute => SelectedSoldier != null);
        public MVVM.RelayCommand LocateCommand => new MVVM.RelayCommand(execute => LocateSoldier(SelectedSoldier));
        public MVVM.RelayCommand TrackCommand => new MVVM.RelayCommand(execute => TrackSoldier(SelectedSoldier));
        public ObservableCollection <Soldier> Soldiers { get; set; }

        public MainWindowViewModel()
        {
            _context = new TrainingContext();
            Soldiers = new ObservableCollection<Soldier>(_context.Soldiers.ToList());
        }

        private Soldier selectedSoldier;

        public Soldier SelectedSoldier
        {
            get { return selectedSoldier; }
            set 
            { 
                selectedSoldier = value;
                OnPropertyChanged();
            }
        }

        // Should fix this duplicated code
        private void LocateSoldier(Soldier selectedSoldier)
        {
            LocationMap locationMap = new LocationMap(selectedSoldier);
            locationMap.Show();
        }

        private void TrackSoldier(Soldier selectedSoldier)
        {
            LocationMap locationMap = new LocationMap(selectedSoldier);
            locationMap.Show();
        }

    }
}
