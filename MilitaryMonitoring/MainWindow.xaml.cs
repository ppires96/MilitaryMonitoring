using MilitaryMonitoring.ViewModels;
using System.Windows;

namespace MilitaryMonitoring
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}