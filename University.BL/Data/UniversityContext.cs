using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext universityContext = null;
        public UniversityContext() : base("cadena")//or we passed the connection string , or we get the name in Web.Config which we can modify without do other deploy
        {

        }

        public DbSet<Course> Courses {get;set;}
        public DbSet<Enrollment> Enrollments {get;set;}
        public DbSet<Student> Students {get;set;}

        public static UniversityContext Create()//is for use singleton, for every instance do one conection to DB,in this case we need only one connectio to dB , but we need more conection to diferent Dbs, we cant use this pattern
        {
            if (universityContext == null)
                universityContext = new UniversityContext();

            return universityContext;     
        }
    }
}
