using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Corrigan.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        [Range(1888, 3000)]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        // DB says NOT NULL, stored as INTEGER (0/1)
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        // DB says NOT NULL, stored as INTEGER (0/1)
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }
}