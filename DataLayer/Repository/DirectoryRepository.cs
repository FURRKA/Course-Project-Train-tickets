using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class DirectoryRepository : IRepository<DirectoryEntity>
    {
        private static List<DirectoryEntity> collection;
        private SqliteConnection connection;

        public DirectoryRepository(string DBPath)
        {
            collection = new List<DirectoryEntity>();
            connection = new SqliteConnection(DBPath);
        }
        public List<DirectoryEntity> Data => collection;
        public int Count => collection.Count;

        public void Create(DirectoryEntity item)
        {
            connection.Open();
            collection.Add(item);
            var command = new SqliteCommand($"INSERT INTO Directories values ({item.StationId},{item.TrainId},{item.RouteId},'{item.Time}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Directories WHERE id_station = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Directories", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        collection.Add(new DirectoryEntity(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                }
                connection.Close();
            }
        }
        //Доделать
        public void Update(int id)
        {
            connection.Open();
            //var command = new SqliteCommand($"UPDATE Directories id_station={collection[]}, id_train={}, id_route={}, time='{}' WHERE id={id}", connection);
            //command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
