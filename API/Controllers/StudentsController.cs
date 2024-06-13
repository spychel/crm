using Microsoft.AspNetCore.Mvc;
using Services.Services.StudentsService;
using Services.Shared.DTO.Student;

namespace API.Controllers;
[Route("v1/students")]
[ApiController]
public class StudentsController(StudentsService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsAsync(
        CancellationToken cancellationToken) =>
        Ok(await service.GetStudentsDtoAsync(cancellationToken));

    [HttpGet("{studentUid}")]
    public async Task<ActionResult<StudentDto>> GetStudentAsync(
        Guid studentUid,
        CancellationToken cancellationToken)
    {
        var student = await service.GetStudentDtoAsync(studentUid, cancellationToken);

        if (student is null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudentAsync(
        CreateStudentDto createDto,
        CancellationToken cancellationToken)
    {
        var student = await service.CreateStudentAsync(createDto, cancellationToken);

        return Ok(student);
    }

    [HttpPut("{studentUid}")]
    public async Task<ActionResult<StudentDto>> UpdateStudentAsync(
        Guid studentUid,
        StudentDto updateDto,
        CancellationToken cancellationToken)
    {
        var updatedStudent = await service.UpdateStudentAsync(studentUid, updateDto, cancellationToken);

        if (updatedStudent == null)
        {
            return NotFound();
        }

        return Ok(updatedStudent);
    }

    [HttpDelete("{studentUid}")]
    public async Task<IActionResult> DeleteStudentAsync(
        Guid studentUid,
        CancellationToken cancellationToken)
    {
        var result = await service.DeleteStudentAsync(studentUid, cancellationToken);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
