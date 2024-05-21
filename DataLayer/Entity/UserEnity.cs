using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class UserEnity : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
        public string Role { get; set; }

        public UserEnity(int id, string login, string password, string role, string name, string lastName, string surName, string passport, string email)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            LastName = lastName;
            SurName = surName;
            Email = email;
            Passport = passport;
            Role = role;
        }
    }
}
