using System.ComponentModel.DataAnnotations;

namespace VisitCardDemo.Models
{
    public class PostVisitCard
    {

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public IFormFile? Image { get; set; }
    }
}
