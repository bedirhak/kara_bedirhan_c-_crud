#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class GradeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Year { get; set; }
    }
}
