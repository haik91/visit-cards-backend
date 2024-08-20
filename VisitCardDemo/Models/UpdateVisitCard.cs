using System.ComponentModel.DataAnnotations;

namespace VisitCardDemo.Models
{
    public class UpdateVisitCard
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? LastName { get; set; }

        [MaxLength(10)]
        public string? Phone { get; set; }

        [MaxLength(255)]
        public string? Email { get; set; }

        public IFormFile? Image { get; set; }
    }
}
