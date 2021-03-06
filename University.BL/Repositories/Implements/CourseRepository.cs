using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;

namespace University.BL.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        private readonly UniversityContext _universityContext;
        public CourseRepository(UniversityContext universityContext) : base(universityContext)
        {
            _universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await _universityContext.Enrollments.AnyAsync(x => x.CourseID == id);
            return flag;
        }
    }
}
