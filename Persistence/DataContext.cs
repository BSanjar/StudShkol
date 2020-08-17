using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // public DbSet<Admin> Admin { get; set; }
        public DbSet<LevelTest> LevelTest { get; set; }
        public DbSet<Promocode> Promocode { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<GroupTest> GroupTest { get; set; }
        public DbSet<ImageTest> ImageTest { get; set; }
        public DbSet<ImageAnswer> ImageAnswer { get; set; }
        //public DbSet<AppUser> Student { get; set; }
        public DbSet<StudentTest> StudentTest { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestResult> TestResult { get; set; }

        public DbSet<Values> Values { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Values>().HasData(
                new Values { Id = 1, Name = "Value 101 " },
                new Values { Id = 2, Name = "Value 102 " },
                new Values { Id = 3, Name = "Value 103 " }
            );
        }

    }
}
