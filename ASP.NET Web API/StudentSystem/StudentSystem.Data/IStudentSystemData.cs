namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public interface IStudentSystemData
    {
        IGenericRepository<Homework> Homework { get; }

        IGenericRepository<Course> Courses { get; }

        StudentsRepository Students { get; }

        void SaveChanges();
    }
}
