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
    }
}
