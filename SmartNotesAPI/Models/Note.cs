using System.ComponentModel.DataAnnotations;
    
    namespace SmartNotesAPI.Models
{
    public class Note
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 2, ErrorMessage = "Content must be between 2 and 5000 characters")]
        public string Content { get; set; }
        public DateTime? Date { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer")]
        public int CategoryId { get; set; }

    }
}
