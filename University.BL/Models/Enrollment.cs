using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    //Propiedades PascalCase
    public enum Grade
    {
        A,B,C,D,E
    }

    [Table("Enrollment", Schema = "dbo")]
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Grade Grade { get; set; }

        public  Course Course { get; set; }
        public Student Student { get; set; }
    }
}
