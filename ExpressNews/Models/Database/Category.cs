using System.ComponentModel.DataAnnotations;

namespace ExpressNews.Models.Database
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<ArticleCategoryLink> ArticleCategorys { get; set; }
    }
}
