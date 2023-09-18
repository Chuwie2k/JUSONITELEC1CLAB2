using Microsoft.AspNetCore.Mvc;
using JUSONITELEC1CLAB2.Models;

namespace JUSONITELEC1CLAB2.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Vince Albert",
                LastName = "Juson",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("04/01/2020")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Cassandra",
                LastName = "Lugtu",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("05/02/2021")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Joaquin",
                LastName = "Valdez",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("06/03/2022")
            },
             new Instructor()
            {
                Id = 4,
                FirstName = "Colbie",
                LastName = "Lugut",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("07/04/2023")


            },
        };
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? Instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)
            {
                return View(Instructor);
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound(); 
        }
        [HttpPost]
       
        public IActionResult EditInstructor(Instructor updatedInstructor)
        {
            Instructor existingInstructor = InstructorList.FirstOrDefault(st => st.Id == updatedInstructor.Id);

                existingInstructor.FirstName = updatedInstructor.FirstName;
                existingInstructor.LastName = updatedInstructor.LastName;
                existingInstructor.IsTenured = updatedInstructor.IsTenured;
                existingInstructor.Rank = updatedInstructor.Rank;
                existingInstructor.HiringDate = updatedInstructor.HiringDate;

                return View("Index", InstructorList);
            }

           
        }

    }


    

