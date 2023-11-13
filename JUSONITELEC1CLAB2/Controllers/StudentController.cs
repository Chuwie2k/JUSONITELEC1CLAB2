using Microsoft.AspNetCore.Mvc;
using JUSONITELEC1CLAB2.Models;

namespace JUSONITELEC1CLAB2.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
        {
            new Student()
            {
                Id = 1,
                Name = "Vince Albert",
                Course = Course.BSIT,
                DateEnrolled = DateTime.Parse("2021-09-01")
            },
            new Student()
            {
                Id = 2,
                Name = "Vince Albert",
                Course = Course.BSIT,
                DateEnrolled = DateTime.Parse("2021-09-01")
            },
            new Student()
            {
                Id = 3,
                Name = "Vince Albert",
                Course = Course.BSCS,
                DateEnrolled = DateTime.Parse("2021-09-01")
            },
        };
        public IActionResult Index()
        {
            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student student = StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View(student);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            StudentList.Add(newStudent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student student = StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View(student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student updatedStudent)
        {
            Student existingStudent = StudentList.FirstOrDefault(st => st.Id == updatedStudent.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Course = updatedStudent.Course;
                existingStudent.DateEnrolled = updatedStudent.DateEnrolled;

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
