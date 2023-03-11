namespace LMS.Web.API.Models
{
    public class Course: BaseModel
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Credit { get; set; }
        public ICollection<Student> Students { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}
