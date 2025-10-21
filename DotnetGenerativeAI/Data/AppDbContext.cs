using DotnetGenerativeAI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetGenerativeAI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ChatModel> Chats { get; set; } = null!;

    public DbSet<ChatMessageModel> Messages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Specify the path to the database file
        optionsBuilder.UseSqlite("Data Source=DATA/app.db");
    }
}
