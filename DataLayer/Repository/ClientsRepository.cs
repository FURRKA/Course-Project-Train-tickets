using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class ClientsRepository : ICRUD<ClientEntity>, IRepository<ClientEntity>
    {
        private static List<ClientEntity> collection;
        private SqliteConnection connection;

        public ClientsRepository(string DBPath)
        {
            collection = new List<ClientEntity>();
            connection = new SqliteConnection(DBPath);
        }
        public List<ClientEntity> Data => collection;
        public int Count => collection.Count;

        public void Create(ClientEntity item)
        {
            connection.Open();
            collection.Add(item);
            var command = new SqliteCommand($"INSERT INTO Clients (name, passport) VALUES ('{item.Name}', '{item.Passport}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Clients WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Clients", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        collection.Add(new ClientEntity(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }                
                connection.Close();
            }
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Clients SET name='{collection[id - 1]}', passport='{collection[id - 1]}' WHERE id={id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
