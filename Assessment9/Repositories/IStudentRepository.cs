using Assessment9.Models;

namespace Assessment9.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task SaveChangesAsync();
    }
}
