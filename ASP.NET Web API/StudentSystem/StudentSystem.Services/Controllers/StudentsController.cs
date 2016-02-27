namespace StudentSystem.Services.Controllers
{
    using StudentSystem.Data;
    using System.Web.Http;
    using System.Linq;
    using Models;
    using StudentSystem.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData db;
        
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
        public IHttpActionResult GetById(int id)
        {
            var student = db.Students
                .SearchFor(st => st.StudentIdentification == id)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("There is no student with this Id");
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

            return this.Created(this.Url.ToString(), newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] StudentModel model)
        {
            var studentForUpdate = db
                .Students
                .SearchFor(st => st.StudentIdentification == id)
                .FirstOrDefault();

            if (studentForUpdate == null)
            {
                return this.BadRequest("There is no student with this Id");
            }
            else if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            else
            {
                studentForUpdate.FirstName = model.FirstName;
                studentForUpdate.LastName = model.LastName;
                studentForUpdate.Level = model.Level;

                this.db.SaveChanges();

                return this.Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var studentForDelete = db
                .Students
                .SearchFor(st => st.StudentIdentification == id)
                .FirstOrDefault();

            if (studentForDelete == null)
            {
                return this.BadRequest("There is no student with this Id");
            }

            this.db.Students.Delete(studentForDelete);
            db.SaveChanges();

            return this.Ok(studentForDelete);
        }
    }
}