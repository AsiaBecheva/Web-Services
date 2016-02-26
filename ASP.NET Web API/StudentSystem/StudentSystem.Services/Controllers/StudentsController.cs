namespace StudentSystem.Services.Controllers
{
    using StudentSystem.Data;
    using System.Web.Http;
    using System.Linq;
    using Models;
    using StudentSystem.Models;
    using System;
    public class StudentsController : ApiController
    {
        private IStudentSystemData db;

        public StudentsController() : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData db)
        {
            this.db = db;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var allStudents = db.Students.All();

            return this.Ok(allStudents);
        }


        [HttpGet]
        public IHttpActionResult GetById(int? id)
        {
            if (id == null)
            {
                return this.BadRequest("The parameter for ID cannot be null");
            }

            var student = db.Students
                .SearchFor(st => st.StudentIdentification == id)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("There is no student with this ID");
            }

            return this.Ok(student);
        }
        
        public IHttpActionResult Post([FromBody]StudentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newStudent = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Level = model.Level
            };

            db.Students.Add(newStudent);
            db.SaveChanges();

            model.Id = newStudent.StudentIdentification;

            return this.Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int? id, StudentModel model)
        {
            throw new NotImplementedException();
        }

        
        
    }
}