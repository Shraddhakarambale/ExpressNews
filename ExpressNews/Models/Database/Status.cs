using System.ComponentModel.DataAnnotations;

namespace ExpressNews.Models.Database
{
    public class Status
    {
       public int Id { get; set; }
       
        [Required]
        [StringLength(100)]
        public string StausName { get; set; }
        public virtual Article Article { get; set; }

    }
}
