using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course,CourseDTO>();//Metodos Get
                cfg.CreateMap<CourseDTO, Course>();//Metodos post o put

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();

                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();
            });
        }
    }
}
