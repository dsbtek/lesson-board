using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

[Route("api/lessons")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IHubContext<LessonHub> _hubContext;
    public LessonController(AppDbContext db, IHubContext<LessonHub> hubContext)
    {
        _db = db;
        _hubContext = hubContext;
    }

    [Authorize(Roles = UserRoles.Tutor)]
    [HttpPost]
    public async Task<IActionResult> CreateLesson([FromBody] Lesson lesson)
    {
        if (lesson.Tutor == null)
        {
            return BadRequest("Tutor must be assigned when creating a lesson.");
        }

        _db.Lessons.Add(lesson);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLessonById), new { id = lesson.Id }, lesson);
    }

    [Authorize(Roles = UserRoles.Tutor)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLesson(int id, [FromBody] Lesson updatedLesson)
    {
        var lesson = await _db.Lessons.FindAsync(id);
        if (lesson == null) return NotFound();

        lesson.Title = updatedLesson.Title;
        lesson.Content = updatedLesson.Content;
        await _db.SaveChangesAsync();

        // 🔗 Notify students & tutors about lesson update
        var hubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<LessonHub>>();
        await _hubContext.Clients.All.SendAsync("ReceiveLessonUpdate", lesson.Id, $"Lesson '{lesson.Title}' updated!");
        return NoContent();
    }


    [Authorize(Roles = UserRoles.Tutor)] // ✅ Only tutors can delete lessons
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLesson(int id)
    {
        var lesson = await _db.Lessons.FindAsync(id);
        if (lesson == null) return NotFound();

        _db.Lessons.Remove(lesson);
        await _db.SaveChangesAsync();
        return NoContent();
    }


    // 🔹 Retrieve All Lessons
    [HttpGet]
    public async Task<IActionResult> GetLessons()
    {
        var lessons = await _db.Lessons.ToListAsync();
        return Ok(lessons);
    }

    // 🔹 Retrieve a Specific Lesson
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(int id)
    {
        var lesson = await _db.Lessons.FindAsync(id);
        if (lesson == null) return NotFound();
        return Ok(lesson);
    }


    [Authorize(Roles = UserRoles.Student)]
    [HttpPost("{lessonId}/join")]
    public async Task<IActionResult> JoinLesson(int lessonId)
    {
        var lesson = await _db.Lessons.FindAsync(lessonId);
        if (lesson == null) return NotFound();

        var studentId = User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(studentId)) return Unauthorized();
        var student = await _db.Students.FindAsync(int.Parse(studentId));
        if (student == null) return Unauthorized();

        lesson.Students.Add(student);
        await _db.SaveChangesAsync();

        return Ok("Joined lesson successfully!");
    }

    [Authorize(Roles = UserRoles.Tutor)]
    [HttpPost("{lessonId}/startSession")]
    public async Task<IActionResult> StartLessonSession(int lessonId)
    {
        var lesson = await _db.Lessons.FindAsync(lessonId);
        if (lesson == null) return NotFound();

        var session = new LessonSession
        {
            LessonId = lessonId,
            StartTime = DateTime.UtcNow
        };

        _db.LessonSessions.Add(session);
        await _db.SaveChangesAsync();

        return Ok(new { SessionId = session.Id, Message = "Lesson session started!" });
    }


    [Authorize(Roles = UserRoles.Student)]
    [HttpPost("{lessonId}/joinSession")]
    public async Task<IActionResult> JoinLessonSession(int lessonId)
    {
        var session = await _db.LessonSessions.FirstOrDefaultAsync(s => s.LessonId == lessonId && s.EndTime == null);
        if (session == null) return NotFound("Lesson session not active.");

        var studentId = User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(studentId)) return Unauthorized();

        var student = await _db.Students.FindAsync(int.Parse(studentId));
        if (student == null) return Unauthorized();

        session.Participants.Add(student);
        await _db.SaveChangesAsync();

        return Ok("Joined lesson session successfully!");
    }

    [Authorize(Roles = UserRoles.Tutor)]
    [HttpPost("{lessonId}/endSession")]
    public async Task<IActionResult> EndLessonSession(int lessonId)
    {
        var session = await _db.LessonSessions.FirstOrDefaultAsync(s => s.LessonId == lessonId && s.EndTime == null);
        if (session == null) return NotFound("No active session found.");

        session.EndTime = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        return Ok("Lesson session ended successfully!");
}




}
