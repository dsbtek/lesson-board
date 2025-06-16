using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// [Authorize(Roles = UserRoles.Tutor)]
[Route("api/tutors")]
[ApiController]
public class TutorController : ControllerBase
{
    private readonly AppDbContext _db;

    public TutorController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTutor([FromBody] Tutor tutor)
    {
        _db.Tutors.Add(tutor);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTutorById), new { id = tutor.Id }, tutor);
    }

    [HttpGet]
    public async Task<IActionResult> GetTutors()
    {
        var tutors = await _db.Tutors.ToListAsync();
        return Ok(tutors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTutorById(int id)
    {
        var tutor = await _db.Tutors.FindAsync(id);
        if (tutor == null) return NotFound();
        return Ok(tutor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTutor(int id, [FromBody] Tutor updatedTutor)
    {
        var tutor = await _db.Tutors.FindAsync(id);
        if (tutor == null) return NotFound();

        tutor.Name = updatedTutor.Name;
        tutor.Email = updatedTutor.Email;
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTutor(int id)
    {
        var tutor = await _db.Tutors.FindAsync(id);
        if (tutor == null) return NotFound();

        _db.Tutors.Remove(tutor);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [Authorize(Roles = UserRoles.Tutor)]
    [HttpGet("{id}/performance")]
    public async Task<IActionResult> GetTutorPerformance(int id)
    {
        var tutorSessions = await _db.LessonSessions.Where(ls => ls.Lesson.Tutor.Id == id).ToListAsync();
        if (!tutorSessions.Any()) return NotFound("No session data found.");

        var totalSessions = tutorSessions.Count;
        var avgSessionDuration = tutorSessions.Average(ls => ls.EndTime.HasValue ? (ls.EndTime.Value - ls.StartTime).TotalMinutes : 0);
        var lessonCompletionRate = (double)tutorSessions.Count(ls => ls.EndTime.HasValue) / totalSessions * 100;
        var attendanceRate = tutorSessions.Average(ls => ls.Participants.Count);
        
        var performanceData = new TutorPerformanceDto
        {
            TotalSessions = totalSessions,
            AttendanceRate = attendanceRate,
            AvgSessionDuration = avgSessionDuration,
            LessonCompletionRate = lessonCompletionRate,
            AvgStudentRating = 4.5 // Placeholder, fetch from student feedback table later
        };

        return Ok(performanceData);
    }

}
