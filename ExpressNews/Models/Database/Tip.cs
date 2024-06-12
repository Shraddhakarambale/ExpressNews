using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressNews.Models.Database
{
    public class Tip
    {

        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(20)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        public string ImageName { get; set; }

        public bool IsApproved { get; set;}

        public bool IsDeleted { get; set; }

        [NotMapped]
        public List<IFormFile> FormImages { get; set; } = new List<IFormFile>();

    }
}
