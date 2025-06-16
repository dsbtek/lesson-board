public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Role { get; set; } = UserRoles.Student;
    public List<Lesson> Lessons { get; set; } = new List<Lesson>(); // 🔗 Relationship
    
}
