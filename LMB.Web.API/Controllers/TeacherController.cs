using LMS.Web.API.Data;
using LMS.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly LMSDbContext _context;

        public TeacherController(LMSDbContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<List<Course>> GetCourses(string name)
        {
            var teacher = await _context.Teachers
                .Include(q => q.Courses)
                .FirstOrDefaultAsync(q => q.Name == name);

            foreach (var course in teacher.Courses)
            {
                course.Teacher = null;
                course.Students = null;
            }

            return teacher.Courses.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(Teacher entity)
        {
            await _context.Teachers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> AssignTeacherToCourse(int teacherId, int courseId)
        {
            Teacher? teacher = _context.Teachers.FirstOrDefault(t => t.Id == teacherId);
            Course? course = _context.Courses.FirstOrDefault(c => c.Id == courseId);

            teacher.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
