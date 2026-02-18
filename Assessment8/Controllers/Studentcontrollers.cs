using Microsoft.AspNetCore.Mvc;
using assessment8.Models;
using assessment8.Repository;

namespace assessment8.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // READ
        public IActionResult Index()
        {
            var students = _repository.GetAll();
            return View(students);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(student);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // UPDATE
        public IActionResult Edit(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(student);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
