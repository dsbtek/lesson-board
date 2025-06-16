public class LessonSession
{
    public int Id { get; set; }
    
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = new Lesson(); // ✅ Ensure it is initialized

    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public List<Student> Participants { get; set; } = new List<Student>();

    // ✅ Constructor to enforce initialization
    public LessonSession()
    {
        Lesson = new Lesson();
        Participants = new List<Student>();
    }
}