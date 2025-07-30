using Core_Layer;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SanadService.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class LessensController : ControllerBase
    {
       
        [HttpGet("GetLessons", Name = "GetLessons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  ActionResult<ClsLessenDOTs> GetLessons()
        {
            var Lessons =  new List<ClsLessenDOTs>();
            Lessons = ClsLessons_CoursesData.GetAllLessons(); 

            if (Lessons.Count > 0)
            {
                 return Ok(Lessons);
            }
               return NotFound("Not Found Lessons !!!");
                

        }

        [HttpGet("GetCourses", Name = "GetCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClsCoruseDTOs> GetCourses()
        {
            var Course = new List<ClsCoruseDTOs>();
            Course = ClsLessons_CoursesData.GetAllCourses();

            if (Course.Count > 0)
            {
                return Ok(Course);
            }
            return NotFound("Not Found Course !!!");


        }
    }

}
