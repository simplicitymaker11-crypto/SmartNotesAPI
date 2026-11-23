using System.ComponentModel.DataAnnotations;
    
    namespace SmartNotesAPI.Models
{
    public class Note
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Title { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string? Content { get; set; }
        public DateTime? Date { get; set; }

    }
}
