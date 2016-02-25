namespace StudentSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System;

    public class StudentSystemDbContext : IdentityDbContext<User>, IStudentSystemDbContext
    {
        public StudentSystemDbContext() 
            : base("StudentSystemConnection")
        {
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public static StudentSystemDbContext Create()
        {
            return new StudentSystemDbContext();
        }
    }
}
