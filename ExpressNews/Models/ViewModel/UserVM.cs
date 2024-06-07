namespace ExpressNews.Models.ViewModel
{
    public class UserVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }

        public bool? IsEmployee { get; set; }

        public bool? IsDeleted { get; set; }

    }

    public class UserVMListModel
    {
        public List<UserVM> Users { get; set; }
    }
}
