using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CoursesModel> Courses { get; set; }
    public DbSet<SkillsModel> Skills { get; set; }

    public DbSet<FrameworksModel> FrameworksModel { get; set; } = default!;
}
