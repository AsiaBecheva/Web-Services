namespace StudentSystem.Services.Controllers
{
    using Data;
    using Models;
    using StudentSystem.Models;
    using System.Linq;
    using System.Web.Http;

    public class CourseController : ApiController
    {
        private IStudentSystemData db;

        public CourseController() : this(new StudentsSystemData())
        {
        }

        public CourseController(IStudentSystemData db)
        {
            this.db = db;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var allCourses = db.Courses.All();

            return this.Ok(allCourses);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = db.Courses
                .SearchFor(c => c.Id == id)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("There is no course with this Id");
            }

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] CourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newCourse = new Course
            {
                Name = model.Name,
                Description = model.Description
            };

            db.Courses.Add(newCourse);
            db.SaveChanges();

            return this.Created(this.Url.ToString(), newCourse);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] CourseModel model)
        {
            var course = db
                .Courses
                .SearchFor(c => c.Id == id)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("There is no course with this Id");
            }
            else if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            else
            {
                course.Name = model.Name;
                course.Description = model.Description;

                this.db.SaveChanges();

                return this.Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var courseForDelete = db
                .Courses
                .SearchFor(c => c.Id == id)
                .FirstOrDefault();

            if (courseForDelete == null)
            {
                return this.BadRequest("There is no course with this Id");
            }

            this.db.Courses.Delete(courseForDelete);
            db.SaveChanges();

            return this.Ok(courseForDelete);
        }
    }
}