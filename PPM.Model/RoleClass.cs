using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PPM.Model
{
    public class RoleClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }     // ProjectId: Project Id.

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = "Undefined";   // Name: Project Name.
    }
}