using StudentInfo.Models.Domain;

namespace StudentInfo.Models
{
    public class AddStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
    }
}
