using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<GroupTest> GroupTest { get; set; }
        public DbSet<ImageTest> ImageTest { get; set; }
        public DbSet<ImageAnswer> ImageAnswer { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentTest> StudentTest { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestResult> TestResult { get; set; }
    }
}
