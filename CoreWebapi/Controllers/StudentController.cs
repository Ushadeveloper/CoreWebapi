using CoreWebapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebapi.Controllers
{
    [Route("api")]
    public class StudentController : Controller
    {
        private List<Student> listStudent;
        public StudentController()
        {
            listStudent = PopulateStudents();
        }
        private List<Student> PopulateStudents()
        {
            List<Student> students = new List<Student>();
            Student student1 = new Student();
            student1.Id = 1;
            student1.FullName = "Jamal";
            student1.FatherName = "Khan";
            student1.PhoneNo = "45343";
            student1.Age = 4;
            students.Add(student1);
            Student student2 = new Student();
            student2.FullName = "karmran";
            student2.Id = 2;

            student2.FatherName = "yasir";
            student2.PhoneNo = "6654";
            student2.Age = 14;
            students.Add(student2);

            Student student3 = new Student();
            student3.Id = 3;
            student3.FullName = "Rehman";
            student3.FatherName = "Imran";
            student3.PhoneNo = "23232";
            student3.Age = 11;
            students.Add(student3);
            return students;
        }
        [HttpGet("Student")]
        public async Task<IActionResult> GetStudents()
        {
            return this.Ok(listStudent);
        }
        [HttpGet("Student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
           // var student = listStudent.Where(x => x.Id==id).FirstOrDefault();
            var student = listStudent.Where(x => x.Id==id);
            if (student.Any<Student>()==false)
            {
                return this.NotFound("Student not found..");
            }

            return this.Ok(student);
        }
        [HttpPost("Student")]
        public async Task<IActionResult> SaveNewStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return this.BadRequest("Invalid data provided");
                listStudent.Add(student);
                return this.Ok(listStudent);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message) ;
            }
            
        }
        [HttpPut("Student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody] Student student)
        {
            try
            {
                var dbStudent = listStudent.Where(x => x.Id == id).FirstOrDefault();
                if (dbStudent == null)
                {
                    return this.NotFound($"StudentId {id} not found..");
                }
                listStudent.Remove(dbStudent);
                dbStudent.Id = id;
                dbStudent.FullName = student.FullName;
                dbStudent.FatherName=student.FatherName;
                dbStudent.PhoneNo=student.PhoneNo; 
                dbStudent.Age=student.Age;
                listStudent.Add(dbStudent);
                return this.Ok(listStudent);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
        [HttpDelete("Student/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var dbStudent = listStudent.Where(x => x.Id == id).FirstOrDefault();
                if (dbStudent == null)
                {
                    return this.NotFound($"StudentId {id} not found..");
                }
                listStudent.Remove(dbStudent);
                
                return this.Ok(listStudent);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }

    }
}
