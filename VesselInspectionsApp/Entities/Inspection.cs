using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesselInspectionsApp.Entities
{
    public class Inspection
    {
        public Inspection()
        {
            InspectionObservations = new ObservableCollection<InspectionObservation>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual Inspector Inspector { get; set; }


        public string Comment { get; set; }

        public virtual ObservableCollection<InspectionObservation> InspectionObservations { get; set; }

        [NotMapped]
        public int ObservationCount { get { return InspectionObservations.Count; } }
    }
}
