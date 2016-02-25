namespace StudentSystem.Services.Controllers
{
    using StudentSystem.Data;
    using System.Web.Http;
    using System.Linq;
    using System;
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

        public IHttpActionResult GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}