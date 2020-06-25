using System.Collections.Generic;
using System.Windows;
using VesselInspectionsApp.Context;
using VesselInspectionsApp.ViewModels;

namespace VesselInspectionsApp
{
    public partial class MainWindow : Window
    {
        private StorageContext _databaseContext;

        private MainViewModel _model;

        public MainWindow()
        {
            InitializeComponent();

            _databaseContext = new StorageContext();

            _model = new MainViewModel(_databaseContext);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource mainViewModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mainViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            mainViewModelViewSource.Source = new List<object>() { _model };

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _databaseContext.Dispose();
        }
    }
}
