namespace PqkLesson06.Models.DataModels
{
    public class Member
    {
        public Member()
        {
        }

        public Member(string memberID, string username, string fullname, string password, string email)
        {
            MemberID = memberID;
            Username = username;
            Fullname = fullname;
            Password = password;
            Email = email;
        }

        public string MemberID { get; set;  }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
