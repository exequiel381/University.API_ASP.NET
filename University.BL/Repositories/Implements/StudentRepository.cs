using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student> // heredor del generic , para poder usar todos los metodos clasicos , y ademas tendre mas metodos solo para student
    {
        public StudentRepository(UniversityContext universityContext) : base(universityContext) // base le manda el contexto a su clase padre
        {

        }
    }
}
