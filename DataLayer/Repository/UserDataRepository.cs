using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class UserDataRepository : ICRUD<UserEnity>, IRepository<UserEnity>
    {
        private List<UserEnity> users;
        public SqliteConnection connection;

        public List<UserEnity> Data => users;
        public int Count => users.Count;

        public UserDataRepository(string pathDB)
        {
            connection = new SqliteConnection(pathDB);
            users = new List<UserEnity>();
        }

        public void Create(UserEnity item)
        {
            connection.Open();
            users.Add(item);
            var command = new SqliteCommand(
                $"INSERT INTO UsersData VALUES " +
                $"({item.Id}," +
                $"'{item.Login}'," +
                $"'{item.Password}'," +
                $"'{item.Role}'," +
                $"'{item.Name}'," +
                $"'{item.LastName}'," +
                $"'{item.SurName}'," +
                $"'{item.Passport}'," +
                $"'{item.Email}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            users.RemoveAt(id - 1);
            var command = new SqliteCommand($"DELETE FROM UsersData WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM UsersData", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        users.Add(new UserEnity(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8)
                            ));
                    }
                }
            }
            connection.Close();
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE UsersData Set " +
                $"SET login = '{users[id - 1].Login}'," +
                $" password = '{users[id - 1].Password}'," +
                $" role = '{users[id - 1].Role}'," +
                $" name = '{users[id - 1].Name}'," +
                $" lastname = '{users[id - 1].LastName}'," +
                $" surname = '{users[id - 1].SurName}'," +
                $" passport = '{users[id - 1].Passport}'" +
                $" email = '{users[id - 1].Email}'" +
                $"WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
