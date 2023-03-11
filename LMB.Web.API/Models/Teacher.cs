namespace LMS.Web.API.Models;

public class Teacher:BasePersonModel
{
    public Teacher()
    {
        Courses = new HashSet<Course>();
    }
    public ICollection<Course> Courses { get; set; }
}