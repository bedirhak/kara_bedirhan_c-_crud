#nullable disable

using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Year { get; set; }
        public List<Student> Student { get; set; }
    }
}
