using assessment8.Data;
using assessment8.Models;

namespace assessment8.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        // READ ALL
        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                           .OrderBy(s => s.Name) // LINQ
                           .ToList();
        }

        // READ BY ID
        public Student GetById(int id)
        {
            return _context.Students
                           .FirstOrDefault(s => s.Id == id); // LINQ
        }

        // CREATE
        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        // UPDATE
        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        // DELETE
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        // SAVE
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
