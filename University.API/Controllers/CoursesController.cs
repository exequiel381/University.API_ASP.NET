using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{
    
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));
        private IMapper mapper;

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        [HttpGet]
        [Route("GetAllTemp")]
        public async Task<IHttpActionResult> GetAllTemp()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null) return NotFound();
            var courseDTO = mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
            
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostCourse(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)//Valida con los dataAnotations
            {
                return BadRequest(ModelState);
            }

            try//con ctrl + k + s podemos hacer que envuelva con try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            
        }
        
        [HttpPut]
        //[Route("NewCourse/{id}")] // Tengo que ver la ruta , como tomar algo del body y otro de parametro
        public async Task<IHttpActionResult> PutCourse(CourseDTO courseDTO,int id)
        {
            if (!ModelState.IsValid)//Valida con los dataAnotations
            {
                return BadRequest(ModelState);
            }

            if(courseDTO.CourseID != id)
            {
                return BadRequest();
            }

            var course = await courseService.GetById(id);

            if (course == null) return BadRequest();

            try//con ctrl + k + s podemos hacer que envuelva con try
            {
                course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            
        }
    }
}
