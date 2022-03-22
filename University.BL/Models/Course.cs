using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    [Table("Course",Schema = "dbo")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
