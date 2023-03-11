using LMS.Web.API.Data;
using LMS.Web.API.DTO;
using LMS.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public CourseController(LMSDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course entity)
        {
            await _context.Courses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
