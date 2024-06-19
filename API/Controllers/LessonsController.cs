using Microsoft.AspNetCore.Mvc;
using Services.Services.LessonsService;
using Services.Shared.DTO.Lesson;

namespace API.Controllers;
[Route("v1/lessons")]
[ApiController]
public class LessonsController(LessonsService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetLessonsAsync(
        CancellationToken cancellationToken) =>
        Ok(await service.GetLessonsDtoAsync(cancellationToken));

    [HttpGet("{lessonUid}")]
    public async Task<ActionResult<LessonDto>> GetLessonAsync(
        int lessonUid,
        CancellationToken cancellationToken)
    {
        var lesson = await service.GetLessonDtoAsync(lessonUid, cancellationToken);

        if (lesson is null)
            return NotFound();

        return Ok(lesson);
    }

    [HttpPost]
    public async Task<ActionResult<LessonDto>> CreateLessonAsync(
        CreateLessonDto createDto,
        CancellationToken cancellationToken)
    {
        var lesson = await service.CreateLessonAsync(createDto, cancellationToken);

        return Ok(lesson);
    }

    [HttpPut("{lessonUid}")]
    public async Task<ActionResult<LessonDto>> UpdateLessonAsync(
        int lessonUid,
        LessonDto updateDto,
        CancellationToken cancellationToken)
    {
        var updatedLesson = await service.UpdateLessonAsync(lessonUid, updateDto, cancellationToken);

        if (updatedLesson == null)
        {
            return NotFound();
        }

        return Ok(updatedLesson);
    }

    [HttpDelete("{lessonUid}")]
    public async Task<IActionResult> DeleteLessonAsync(
        int lessonUid,
        CancellationToken cancellationToken)
    {
        var result = await service.DeleteLessonAsync(lessonUid, cancellationToken);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
