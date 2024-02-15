namespace StudentInfo.Models.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
