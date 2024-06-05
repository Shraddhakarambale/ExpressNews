using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressNews.Models.Database
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateStamp { get; set; }

        [Required]
        [StringLength(1000)]
        public string LinkText { get; set; }

        [Required]
        [StringLength(255)]
        public string HeadLine { get; set; }

        [StringLength(500)]
        public string ContentSummary { get; set; }

        [Required]
        public string Content { get; set; }

        public int? Views { get; set; }

        public int? Likes { get; set; }

        public int? DisLikes { get; set; }

        [StringLength(200)]
        public string ImageLink { get; set; }
        [Required]
        public string Category1 { get; set; }

        public string? Category2 { get; set; }
        public string? Category3 { get; set; }

        public string? ImageDiscription { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public bool IsBreaking { get; set; }

        [Required]
        public bool IsSubsription { get; set; }


        [StringLength(500)]
        public string UserName { get; set; }
        
        [NotMapped]
        public List<IFormFile> FormImages { get; set; } = new List<IFormFile>();

        
    }
}
