using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Data {
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}