using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
