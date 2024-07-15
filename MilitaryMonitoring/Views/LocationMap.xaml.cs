using MilitaryMonitoring.Models;
using MilitaryMonitoring.ViewModels;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MilitaryMonitoring.Views
{
    public partial class LocationMap : Window
    {
        private readonly LocationMapViewModel locationMapViewModel;
        public LocationMap(Soldier soldier, [CallerMemberName] string commandName = null)
        {
            locationMapViewModel = new LocationMapViewModel(soldier, commandName);
            DataContext = locationMapViewModel;
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            locationMapViewModel.Dispose();
        }

    }
}
