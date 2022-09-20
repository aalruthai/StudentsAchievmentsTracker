using StudentsAchievmentsTracker.Entities;
using StudentsAchievmentsTracker.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace StudentsAchievmentsTracker.Services
{
    public class StudentService : ApplicationService
    {
        private readonly IRepository<Student, int> _studentRepository;

        public StudentService(IRepository<Student, int> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> GetListAsync()
        {
            var items = await _studentRepository.GetListAsync();

            return items.Select(item => new StudentDto
            {
                Id = item.Id,
                StudentId = item.StudentId,
                StudentName = item.StudentName
            }).ToList();
        }

        public async Task<StudentDto> CreateAsync(string studentName, int studentId)
        {
            var student = await _studentRepository.InsertAsync(new Student { StudentId = studentId, StudentName = studentName });

            return new StudentDto { Id = student.Id, StudentName = student.StudentName, StudentId = student.StudentId };
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
