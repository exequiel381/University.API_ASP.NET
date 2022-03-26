using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.API.Controllers
{
    //Link del curso : https://www.youtube.com/watch?v=avxprqW1UGE&list=PLmjxkroO78KwV2O2ADa-V3hSIyvWzeU21
    //Instalar extensiones -- owin , swagger  , entity ,course 

    //[Authorize] //Para que exija autorizacion, debemos pedir un token y luego mandarlo por header a estas consultas
    //Aqui decimos que debe estar autenticado a nivel de controlador , podemos hacerlo a nivel de metodo
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));
        private IMapper mapper;

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Obtiene todos los cursos
        /// </summary>
        /// <remarks>
        /// Descripcion mas larga
        /// </remarks>
        /// <returns>Retorna una coleccion de cursos</returns>

        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
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

        /// <summary>
        /// Obtiene todos los cursos
        /// </summary>
        /// <remarks>
        /// Descripcion mas larga
        /// </remarks>
        /// <param name="id">Descripcion del parametro</param>
        /// <returns>Retorna un curso</returns>
        /// <response code="200">OK. Devuelve el objeto solicitado (describe que hace cuando sale bien)</response>
        /// /// <response code="404">Mal. No se encontro el objeto(describe que hace cuando sale mal)</response>

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
        
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCourse(int id)
        {
            if (!ModelState.IsValid)//Valida con los dataAnotations
            {
                return BadRequest(ModelState);
            }

            var course = await courseService.GetById(id);

            if (course == null) return NotFound();

            try//con ctrl + k + s podemos hacer que envuelva con try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("Foreing Keys");

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            
        }
    }
}
