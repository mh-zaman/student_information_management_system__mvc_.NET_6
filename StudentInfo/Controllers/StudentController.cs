using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Data;
using StudentInfo.Models;
using StudentInfo.Models.Domain;
using System.Reflection;
using System.Xml.Linq;

namespace StudentInfo.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentInfoDbContext studentInfoDbContext;

        public StudentController(StudentInfoDbContext studentInfoDbContext)
        {
            this.studentInfoDbContext = studentInfoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await studentInfoDbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Gender = addStudentRequest.Gender,
                DateOfBirth = addStudentRequest.DateOfBirth,
                ClassId = addStudentRequest.ClassId,
                CreatedDate = DateTime.Now,
                ModificationDate = DateTime.Now,
            };

            await studentInfoDbContext.Students.AddAsync(student);
            await studentInfoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var student = studentInfoDbContext.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var student = await studentInfoDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student != null)
            {
                var editModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Gender = student.Gender,
                    ClassId = student.ClassId,
                    DateOfBirth = student.DateOfBirth,
                    CreatedDate = student.CreatedDate,
                    ModificationDate = student.ModificationDate
                };
                return View(editModel);
            }
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateStudentViewModel updateStudentRequest)
        {
            var student = await studentInfoDbContext.Students.FindAsync(updateStudentRequest.Id);

            if (student != null)
            {
                student.Name = updateStudentRequest.Name;
                student.Gender = updateStudentRequest.Gender;
                student.ClassId = updateStudentRequest.ClassId;
                student.DateOfBirth = updateStudentRequest.DateOfBirth;
                student.ModificationDate = DateTime.Now;

                await studentInfoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await studentInfoDbContext.Students.FindAsync(id);
            if (student != null)
            {
                studentInfoDbContext.Students.Remove(student);
                await studentInfoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}