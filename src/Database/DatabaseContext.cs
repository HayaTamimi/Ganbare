using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ganbare.src.Entity;
using Microsoft.EntityFrameworkCore;
using static ganbare.src.Entity.Question;

namespace ganbare.src.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Level>();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}