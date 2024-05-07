using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    internal class RepositoryUser : ICRUD<ClientEntity>
    {
        private static List<ClientEntity> collection;
        private SqliteConnection connection;

        public RepositoryUser(string DBPath)
        {
            collection = new List<ClientEntity>();
            connection = new SqliteConnection(DBPath);
        }

        public void Create(ClientEntity item)
        {
            connection.Open();
            collection.Add(item);
            var command = new SqliteCommand($"INSERT INTO clients (name, passport) VALUES ({item.Name}, {item.Passport})");
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM clients WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM clients", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    collection.Add(new ClientEntity((int)reader[0], (string)reader[1], (string)reader[2]));
                }
                connection.Close();
            }
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE clients SET name={collection[id - 1]}, passport={collection[id - 1]} WHERE id={id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
