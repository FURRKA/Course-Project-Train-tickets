using DataLayer.Entity;
using DataLayer.Repository;
using System.Runtime.Serialization;

namespace BIL.Services
{
    public class ClientService
    {
        private UserDataRepository users;

        public ClientService(string DBpath)
        {
            users = new UserDataRepository(DBpath);
            users.Read();
        }

        public UserEnity GetUser(int id) => users.Data.Find(user => user.Id == id);
        public void DeleteUser(int id) => users.Delete(id);
    }
}
