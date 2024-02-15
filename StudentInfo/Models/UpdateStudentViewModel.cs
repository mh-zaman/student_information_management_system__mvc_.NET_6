namespace StudentInfo.Models
{
    public class UpdateStudentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
