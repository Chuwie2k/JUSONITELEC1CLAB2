using System.ComponentModel.DataAnnotations;

namespace JUSONITELEC1CLAB2.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor

    }

    public enum IsTenured
    {
        Permanent, Probationary
    }

    public class Instructor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Is Tenured")]
        public IsTenured IsTenured { get; set; }
        [Required(ErrorMessage = "Rank is required")]
        public Rank Rank { get; set; }

        [Required(ErrorMessage = "Hiring Date is required")]
        public DateTime HiringDate { get; set; }


    }
}
