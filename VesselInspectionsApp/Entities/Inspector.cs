using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VesselInspectionsApp.Entities
{
    public class Inspector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Uid { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Uid})";
        }
    }
}
