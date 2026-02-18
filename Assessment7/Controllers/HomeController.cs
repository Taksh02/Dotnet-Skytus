using Microsoft.AspNetCore.Mvc;
using Assessment7.Models;

namespace Assessment7.Controllers;

public class HomeController : Controller
{
    private static List<Student> students = new List<Student>();
    private static int nextId = 1;

    public IActionResult Index()
    {
        var filteredStudents = students.Where(s => s.Marks >= 50).ToList();
        return View(filteredStudents);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        student.Id = nextId++;
        students.Add(student);
        return RedirectToAction("Index");
    }

    // 🔹 EDIT GET
    public IActionResult Edit(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        return View(student);
    }

    // 🔹 EDIT POST
    [HttpPost]
    public IActionResult Edit(Student updatedStudent)
    {
        var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);

        if (student != null)
        {
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Age = updatedStudent.Age;
            student.Marks = updatedStudent.Marks;
        }

        return RedirectToAction("Index");
    }

    // 🔹 DELETE
    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            students.Remove(student);
        }

        return RedirectToAction("Index");
    }
}
