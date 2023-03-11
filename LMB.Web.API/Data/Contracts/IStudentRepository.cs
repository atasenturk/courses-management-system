using LMS.Web.API.Models;

namespace LMS.Web.API.Data.Contracts
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        Task<List<Course>> GetCourses(int id);
        Task<bool> AddCourseToStudent(int studentId, int courseId);
    }
}
