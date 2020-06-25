using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using VesselInspectionsApp.Context;
using VesselInspectionsApp.Entities;

namespace VesselInspectionsApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        StorageContext _context;

        private string _inspectionFilterName = string.Empty;
        private int _inspectorFilterId = -1;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(StorageContext context)
        {
            _context = context;
        }

        public List<KeyValuePair<int, string>> InspectorFilterList => _context.Inspectors.Local
            .Select(i => new KeyValuePair<int, string>(i.Id, i.ToString()))
            .Prepend(new KeyValuePair<int, string>(-1, "Все"))
            .ToList();

        public string InspectionFilterName 
        { 
            get { return _inspectionFilterName; } 
            set 
            { 
                _inspectionFilterName = value; 
                
                OnPropertyChanged("ShownInspections");
            } 
        }

        public int InspectorFilterId 
        { 
            get { return _inspectorFilterId; }
            set
            {
                _inspectorFilterId = value;

                OnPropertyChanged("ShownInspections");
            } 
        }

        public List<Inspection> ShownInspections => _context.Inspections.Local
            .Where(i => 
                (string.IsNullOrEmpty(InspectionFilterName) || i.Name.ToLower().Contains(InspectionFilterName.ToLower())) &&
                (InspectorFilterId < 0 || i.Inspector.Id == InspectorFilterId))
            .ToList();

        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
