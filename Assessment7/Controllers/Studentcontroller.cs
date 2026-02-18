using Microsoft.AspNetCore.Mvc;
using Assessment7.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Assessment7.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }
    }
}
