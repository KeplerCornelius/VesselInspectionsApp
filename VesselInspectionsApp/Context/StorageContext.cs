using System.Data.Entity;
using VesselInspectionsApp.Entities;

namespace VesselInspectionsApp.Context
{
    public class StorageContext : DbContext
    {
        public StorageContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();

            Inspectors.Load();
            Inspections.Load();
            InspectionObservations.Load();
        }

        public DbSet<Inspection> Inspections { get; set; }

        public DbSet<InspectionObservation> InspectionObservations { get; set; }

        public DbSet<Inspector> Inspectors { get; set; }
    }
}
