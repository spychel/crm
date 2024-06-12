using AutoMapper;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class StudentService(
        LessonsDbContext dbContext, 
        IMapper mapper)
    {
        public async Task<IEnumerable<StudentDto>> GetStudentsDtoAsync(CancellationToken cancellationToken) =>
            await dbContext
                .Set<Student>()
                .Select(student => mapper.Map<StudentDto>(student))
                .ToListAsync(cancellationToken);

        public async Task<StudentDto?> GetStudentDtoAsync(Guid studentUid, CancellationToken cancellationToken)
        {
            var student = await GetStudentByUidAsync(studentUid, cancellationToken);

            return student is null ? null : mapper.Map<StudentDto>(student);
        }

        private async Task<Student?> GetStudentByUidAsync(Guid studentUid, CancellationToken cancellationToken)
        {
            return await dbContext
                .Set<Student>()
                .FirstOrDefaultAsync(s => s.Uid == studentUid, cancellationToken);
        }

        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto createDto, CancellationToken cancellationToken)
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

            var student = mapper.Map<Student>(createDto);
            await dbContext.Set<Student>().AddAsync(student, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            var createdStudent = await dbContext
                .Set<Student>()
                .FirstAsync(s => s.Uid == student.Uid, cancellationToken);

            return mapper.Map<StudentDto>(createdStudent);
        }

        public async Task<StudentDto?> UpdateStudentAsync(Guid studentUid, StudentDto dto, CancellationToken cancellationToken)
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

            var student = await GetStudentByUidAsync(studentUid, cancellationToken);
            if (student == null)
            {
                return null;
            }

            mapper.Map(dto, student);

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return await GetStudentDtoAsync(student.Uid, cancellationToken);
        }

        public async Task<bool> DeleteStudentAsync(
            Guid studentUid,
            CancellationToken cancellationToken)
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

            var student = await GetStudentByUidAsync(studentUid, cancellationToken);
            if (student == null)
            {
                return false;
            }

            dbContext.Set<Student>().Remove(student);
            await dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
            return true;
        }
    }
}
