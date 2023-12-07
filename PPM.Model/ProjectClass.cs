using System.ComponentModel.DataAnnotations;
namespace PPM.Model
{
    public class ProjectClass
    {
        [Key]
        public long ProjectId { get; set; }     // Id: Project Id.
        public  string Name { get; set; }     // Name: Project Name.
        public DateTime StartDate { get; set; }     // StartDate: Project Begin Date.
        public DateTime EndDate { get; set; }     // EndDate: Project End Date.

        public ProjectClass()
        {
            ProjectId = 0;
            Name = "null";
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
        }
    }
}