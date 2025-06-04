using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonSession> LessonSessions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Tutor)
            .WithMany(t => t.Lessons)
            .HasForeignKey(l => l.TutorId);

        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.Students)
            .WithMany(s => s.Lessons);

        modelBuilder.Entity<LessonSession>()
        .HasOne(ls => ls.Lesson)  // ✅ Define relation
        .WithMany()  // Allow multiple sessions per lesson
        .HasForeignKey(ls => ls.LessonId);  // 🔗 Set foreign key
    }
}
