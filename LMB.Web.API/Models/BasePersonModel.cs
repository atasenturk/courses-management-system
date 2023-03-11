namespace LMS.Web.API.Models
{
    public abstract class BasePersonModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
