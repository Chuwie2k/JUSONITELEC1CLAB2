using Microsoft.AspNetCore.Mvc;
using JUSONITELEC1CLAB2.Models;
using JUSONITELEC1CLAB2.Data;

namespace JUSONITELEC1CLAB2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public InstructorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            if (!ModelState.IsValid)
            {
                return View(newInstructor);
            }

            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View("EditInstructor", instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor updatedInstructor)
        {
            if (!ModelState.IsValid)
            {
                return View("EditInstructor", updatedInstructor);
            }

            Instructor existingInstructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == updatedInstructor.Id);

            if (existingInstructor != null)
            {
                existingInstructor.FirstName = updatedInstructor.FirstName;
                existingInstructor.LastName = updatedInstructor.LastName;
                existingInstructor.IsTenured = updatedInstructor.IsTenured;
                existingInstructor.Rank = updatedInstructor.Rank;
                existingInstructor.HiringDate = updatedInstructor.HiringDate;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Instructor instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View("Delete", instructor);            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                _dbContext.Instructors.Remove(instructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
