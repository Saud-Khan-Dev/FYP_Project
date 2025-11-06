using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QEC_Project.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DBContext _dBContext;
        public CourseController(DBContext dBContext)
        {
            this._dBContext = dBContext;
        }

        [HttpGet]
    public  async Task<List<CourseModel>> GgetCourses()
    {
            return await _dBContext.Course.ToListAsync();
    }
  }
}
