using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]//esto es util que coincida con la maxima longitud en la base de datos , para que falle en el DTO y no cuando se llama a la DB
        public string LastName { get; set; }
        [Required]
        public string FirstMinName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {0}", LastName, FirstMinName); }
        }
    }
}
