// public class Lesson
// {
//     public int Id { get; set; }
//     public required string Title { get; set; }
//     public required string Content { get; set; }
//     public DateTime CreatedAt { get; set; }

//     public int TutorId { get; set; } // 🔗 Foreign key
//     public required Tutor Tutor { get; set; }

//     public List<Student> Students { get; set; } = new List<Student>(); // 🔗 Many-to-Many
// }

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; // ✅ Initialize as empty string
    public string Content { get; set; } = string.Empty; // ✅ Ensure it's not null
    public Tutor Tutor { get; set; } = new Tutor(); // ✅ Create a default Tutor object

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Lesson() { } // ✅ Add a default constructor
    public int TutorId { get; set; }  // 🔗 Foreign key
    public List<Student> Students { get; set; } = new List<Student>(); // 🔗 Many-to-Many
}
