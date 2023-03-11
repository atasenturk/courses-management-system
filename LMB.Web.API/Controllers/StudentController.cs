using AutoMapper;
using LMS.Web.API.Data;
using LMS.Web.API.Data.Contracts;
using LMS.Web.API.DTO;
using LMS.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly LMSDbContext _context;
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(LMSDbContext context, IStudentRepository repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}/Courses")]
        public async Task<List<CoursesOfStudentDTO>> GetStudentCourses(int id)
        {
            var courses= await _repository.GetCourses(id);
            var coursesDTO = _mapper.Map<List<Course>,List<CoursesOfStudentDTO>>(courses);

            return coursesDTO;
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudent(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return student;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentDTO entity)
        {
            var student = _mapper.Map<Student>(entity);
            student.CreatedDate = DateTime.Now;
            await _repository.AddAsync(student);
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> AddCourseToStudent(int studentId, int courseId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student == null || course == null) return NotFound();

            student.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(q => q.Id == id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
