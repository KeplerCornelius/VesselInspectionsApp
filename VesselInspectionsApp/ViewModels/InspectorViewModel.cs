using System.Collections.ObjectModel;
using VesselInspectionsApp.Entities;
using VesselInspectionsApp.Context;

namespace VesselInspectionsApp.ViewModels
{
    public class InspectorViewModel
    {
        private StorageContext _context;

        public InspectorViewModel(StorageContext context)
        {
            _context = context;
        }

        public virtual ObservableCollection<Inspector> Inspectors => _context.Inspectors.Local;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
