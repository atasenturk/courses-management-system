using LMS.Web.API.Data.Contracts;
using LMS.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Web.API.Data.Repositories
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        private readonly LMSDbContext _context;

        public StudentRepository(LMSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCourses(int id)
        {
            var student = await _context.Students
                .Include(q => q.Courses)
                .FirstOrDefaultAsync(q => q.Id == id);

            return student.Courses.ToList();

        }

        public async Task<bool> AddCourseToStudent(int studentId, int courseId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var course = await _context.Courses.FindAsync(courseId);

            if (student == null || course == null) return false;

            student.Courses.Add(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
