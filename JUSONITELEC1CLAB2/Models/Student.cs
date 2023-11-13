using Microsoft.AspNetCore.Mvc;

namespace JUSONITELEC1CLAB2.Models
{
    public enum Course
    {
        BSCS, BSIT, BSIS
    }

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Course Course { get; set; }

        public DateTime DateEnrolled { get; set; }
    }
}
