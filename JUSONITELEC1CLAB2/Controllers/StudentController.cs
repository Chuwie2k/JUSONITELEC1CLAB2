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
                FirstName = "Vince Albert",
                LastName = "Juson",
                Course = Course.ComputerScience,
                EnrollmentDate = DateOnly.Parse("2021-09-01")
            },
            new Student()
            {
                Id = 2,
                FirstName = "Cassandra",
                LastName = "Lugtu",
                Course = Course.InformationTechnology,
                EnrollmentDate = DateOnly.Parse("2022-10-02")
            },
            new Student()
            {
                Id = 3,
                FirstName = "Joaquin",
                LastName = "Valdez",
                Course = Course.InformationSystems,
                EnrollmentDate = DateOnly.Parse("2023-11-03")
            },
            new Student()
            {
                Id = 4,
                FirstName = "Colbie",
                LastName = "Lugtu",
                Course = Course.InformationTechnology,
                EnrollmentDate = DateOnly.Parse("2024-12-04")
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
                existingStudent.FirstName = updatedStudent.FirstName;
                existingStudent.LastName = updatedStudent.LastName;
                existingStudent.Course = updatedStudent.Course;
                existingStudent.EnrollmentDate = updatedStudent.EnrollmentDate;

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
