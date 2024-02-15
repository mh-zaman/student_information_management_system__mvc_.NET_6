using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace StudentInfo.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public Class Class { get; set; }
    }
}
