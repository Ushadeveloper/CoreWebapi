namespace CoreWebapi.Models
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }
        public string FatherName { get; set; } 
        public string PhoneNo { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public int Age { get; set; } 
    }
}
