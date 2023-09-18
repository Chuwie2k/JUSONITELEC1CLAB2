using Microsoft.AspNetCore.Mvc;

namespace JUSONITELEC1CLAB2.Models
{
    public enum Course
    {
        ComputerScience, InformationTechnology, InformationSystems
    }

    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Course Course { get; set; }

        public DateOnly EnrollmentDate { get; set; }
    }
}
