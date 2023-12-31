using CoreWebapi.Models;

namespace CoreWebapi.Services
{
    public interface IDataAccessService
    {
        List<SchoolClass> GetSchoolClasses();
        int SaveStudentData(Student student);
        int UpdateStudentData(Student student);
        List<Student> GetStudents();
        int DeleteStudentData(int Id);
        Student GetStudentById(int id);
    }
}
