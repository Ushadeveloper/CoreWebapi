using CoreWebapi.Models;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebapi.Services
{
    public class DataAccessService : IDataAccessService
    {
        public DataAccessService()
        {
                
        }
        public List<SchoolClass> GetSchoolClasses()
        {
            List<SchoolClass> listClass = new List<SchoolClass>();
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                string oString = $"Select * from SchoolClass ;";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        SchoolClass schoolClass = null;
                        while (oReader.Read())
                        {
                            schoolClass = new SchoolClass();
                            schoolClass.Id = Convert.ToInt32(oReader["Id"]);
                            schoolClass.ClassName = oReader["ClassName"].ToString();
                            schoolClass.Status = oReader["Status"].ToString();

                            listClass.Add(schoolClass);
                        }
                    }


                }
            }
            return listClass;
        }

        public int SaveStudentData(Student student)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                String query = $"insert into Student(FullName, FatherName, PhoneNo, ClassId, StudentAge) " +
                                $"values('{student.FullName}', '{student.FatherName}', '{student.PhoneNo}', '{student.ClassId}', {student.Age})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result;

                }
            }
        }
        public int UpdateStudentData(Student student)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                //String query = $"insert into Student(FullName, FatherName, PhoneNo, ClassId, StudentAge) " +
                //                $"values('{student.FullName}', '{student.FatherName}', '{student.PhoneNo}', '{student.ClassId}', {student.StudentAge})";
                String query = $"update Student set FullName= '{student.FullName}', FatherName= '{student.FatherName}', PhoneNo= '{student.PhoneNo}', studentAge ={student.Age}, ClassId={student.ClassId}  " +
                                   $"where Id ={student.Id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result;

                }
            }
        }
        public List<Student> GetStudents()
        {
            List<Student> listStudent = new List<Student>();
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                string oString = $"select * from viewStudent;";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        Student student = null;
                        while (oReader.Read())
                        {
                            student = new Student();
                            student.Id = Convert.ToInt32(oReader["Id"].ToString());
                            student.FullName = oReader["FullName"].ToString();
                            student.FatherName = oReader["FatherName"].ToString();
                            student.ClassName = oReader["ClassName"].ToString();
                            student.ClassId = Convert.ToInt32(oReader["ClassId"]);
                            student.PhoneNo = oReader["PhoneNo"].ToString();
                            student.Age = Convert.ToInt32(oReader["StudentAge"]);

                            listStudent.Add(student);
                        }
                    }


                }
            }
            return listStudent;
        }
        public Student GetStudentById(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                string oString = $"select * from student where Id={id};";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        
                        while (oReader.Read())
                        {
                            student = new Student();
                            student.Id = Convert.ToInt32(oReader["Id"].ToString());
                            student.FullName = oReader["FullName"].ToString();
                            student.FatherName = oReader["FatherName"].ToString();
                            
                            student.ClassId = Convert.ToInt32(oReader["ClassId"]);
                            student.PhoneNo = oReader["PhoneNo"].ToString();
                            student.Age = Convert.ToInt32(oReader["StudentAge"]);
                            break;
                        }
                    }


                }
            }
            return student;
        }
        public int DeleteStudentData(int Id)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                String query = $"delete from student where id ={Id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result;

                }
            }
        }
    }
}
