using DataLayer.Entity;
using DataLayer.Repository;

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
    }
}
