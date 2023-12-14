using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PPM.Model
{
    public class ProjectClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProjectId { get; set; }     // Id: Project Id.

        [Required]
        [MaxLength]
        public string Name { get; set; }  = "Undefined";   // Name: Project Name.

        [Required]
        public DateTime StartDate { get; set; }     // StartDate: Project Begin Date.

        [Required]
        public DateTime EndDate { get; set; }     // EndDate: Project End Date.

        public ProjectClass()
        {
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
        }
    }
}