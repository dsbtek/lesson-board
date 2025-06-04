using System.ComponentModel.DataAnnotations;

public class Tutor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = UserRoles.Tutor;
    public List<Lesson> Lessons { get; set; } = new List<Lesson>(); // 🔗 Relationship
    public Tutor() {}
}
