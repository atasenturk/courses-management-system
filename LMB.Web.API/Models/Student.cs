namespace LMS.Web.API.Models
{
    public class Student: BasePersonModel
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }
        public ICollection<Course> Courses { get; set; }
    }
}
