using AutoMapper;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Shared.DTO.Lesson;

namespace Services.Services.LessonsService;

public class LessonsService(
    LessonsDbContext dbContext,
    IMapper mapper)
{
    public async Task<IEnumerable<LessonDto>> GetLessonsDtoAsync(CancellationToken cancellationToken) =>
        await dbContext
            .Set<Lesson>()
            .Include(l => l.Type)
            .Include(l => l.StateType)
            .Select(lesson => mapper.Map<LessonDto>(lesson))
            .ToListAsync(cancellationToken);

    public async Task<LessonDto?> GetLessonDtoAsync(int lessonUid, CancellationToken cancellationToken)
    {
        var lesson = await GetLessonByUidAsync(lessonUid, cancellationToken);

        return lesson is null ? null : mapper.Map<LessonDto>(lesson);
    }

    private async Task<Lesson?> GetLessonByUidAsync(int lessonUid, CancellationToken cancellationToken)
    {
        return await dbContext
            .Set<Lesson>()
            .Include(l => l.Type)
            .Include(l => l.StateType)
            .FirstOrDefaultAsync(s => s.Uid == lessonUid, cancellationToken);
    }

    public async Task<LessonDto> CreateLessonAsync(CreateLessonDto createDto, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        var lesson = mapper.Map<Lesson>(createDto);
        await dbContext.Set<Lesson>().AddAsync(lesson, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        var createdLesson = await dbContext
            .Set<Lesson>()
            .FirstAsync(l => l.Uid == lesson.Uid, cancellationToken);

        return mapper.Map<LessonDto>(createdLesson);
    }

    public async Task<LessonDto?> UpdateLessonAsync(int lessonUid, LessonDto dto, CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        var lesson = await GetLessonByUidAsync(lessonUid, cancellationToken);
        if (lesson == null)
        {
            return null;
        }

        mapper.Map(dto, lesson);

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);

        return await GetLessonDtoAsync(lesson.Uid, cancellationToken);
    }

    public async Task<bool> DeleteLessonAsync(
        int lessonUid,
        CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        var lesson = await GetLessonByUidAsync(lessonUid, cancellationToken);
        if (lesson == null)
        {
            return false;
        }

        dbContext.Set<Lesson>().Remove(lesson);
        await dbContext.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);
        return true;
    }
}
