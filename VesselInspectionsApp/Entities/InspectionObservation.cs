using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesselInspectionsApp.Entities
{
    public class InspectionObservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime? ResolveDate { get; set; }

        public string ResolveComment { get; set; }

        [Required]
        public virtual Inspection Inspection { get; set; }
    }
}
