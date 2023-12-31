using CoreWebapi.Models;
using CoreWebapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebapi.Controllers
{
    [Route("api/StudentCrud")]
    public class StudentCrudController : Controller
    {
        private readonly IDataAccessService _dataAccessService;
        public StudentCrudController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetStudents()
        {
            var list = _dataAccessService.GetStudents();
            return this.Ok(list);
        }
        [HttpPost()]
        public async Task<IActionResult> SaveNewStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return this.BadRequest("Invalid data provided");
                int result = _dataAccessService.SaveStudentData(student);

                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpPut("StudentInformation/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                var dbStudent = _dataAccessService.GetStudentById(id);
                if (dbStudent == null)
                {
                    return this.NotFound($"StudentId {id} not found..");
                }
                
                dbStudent.Id = id;
                dbStudent.FullName = student.FullName;
                dbStudent.FatherName = student.FatherName;
                dbStudent.PhoneNo = student.PhoneNo;
                dbStudent.ClassId = student.ClassId;
                dbStudent.Age = student.Age;
              int result = _dataAccessService.UpdateStudentData(dbStudent);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

        [HttpDelete("StudentInformation/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var dbStudent = _dataAccessService.GetStudentById(id);

                if (dbStudent == null)
                {
                    return this.NotFound($"StudentId {id} not found..");
                }

                int result = _dataAccessService.DeleteStudentData(id);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

    }
}
