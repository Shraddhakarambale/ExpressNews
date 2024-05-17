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
        [StringLength(500)]
        public string LinkText { get; set; }

        [Required]
        [StringLength(255)]
        public string HeadLine { get; set; }

        [StringLength(500)]
        public string ContentSummary { get; set; }

        [Required]
        public string Content { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        [StringLength(200)]
        public string ImageLink { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public bool IsBreaking { get; set; }

        [Required]
        public bool IsSubsription { get; set; }

        public ICollection<ArticleCategoryLink> ArticleCategoryLinks { get; set; }

        public virtual Status Status { get; set; }



        public int UserId { get; set; }

        [NotMapped]
        public List<IFormFile> FormImages { get; set; } = new List<IFormFile>();

        public virtual ICollection<ImageLink> Images { get; set; } = new List<ImageLink>();

    }
}
