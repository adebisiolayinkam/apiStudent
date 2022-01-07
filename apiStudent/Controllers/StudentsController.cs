using apiStudent.IService;
using apiStudent.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        private StudentDbContext _dbContext;
        public StudentsController(IStudent student, StudentDbContext dbContext)
        {
            _student = student;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Students")]
        public ActionResult<IEnumerable<Student>> AllStudent()
        {
            var students = _student.GetallStudent();
            if (students == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _student.GetStudent(id);
            if(student == null)
            {
                return BadRequest("Empty List");
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<Student> AddStudent(Student student)
        {
            var std = _student.addStudent(student);

            if(std == null)
            {
                return BadRequest("Student already exist");
            }
            return Ok(std);
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Student> Edit(int id, Student std)
        {
            var found = _dbContext.StudendTable.SingleOrDefault(x => x.Id == id);
            if(found != null)
            {
                var edit = _student.editStudent(id, std);
                return Ok(edit);
            }
            return BadRequest("Not Found");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {           
            var stud = _dbContext.StudendTable.SingleOrDefault(x => x.Id == id);
            if (stud == null)
            {
                return BadRequest("Not Found");
            }

            _student.DeleteStudent(stud);
            return Ok("Deleted ");
        }


    }
}
