using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        
        public int CourseID { get; set; }
        [Required(ErrorMessage = "The Field Title is Required")] // Decoradores para validar los modelos
        [StringLength(50)]
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}
