namespace CoreWebapi.Models
{
    public class Employee :BaseEntity
    {
        public string EmployeeName { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
    }
}
