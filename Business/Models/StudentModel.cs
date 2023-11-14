#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public int? UniversityExamRank { get; set; }

        public decimal? CumulativeGpa { get; set; }

        [DisplayName("Grade")]
        [Required]
        public int? GradeId { get; set; }

        [DisplayName("Grade")]
        public string GradeOutput { get; set; }
    }
}
