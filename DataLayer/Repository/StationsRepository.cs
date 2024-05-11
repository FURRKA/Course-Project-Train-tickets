using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer.Repository
{
    public class StationsRepository : ICRUD<StationEntity>, IRepository<StationEntity>
    {
        private static List<StationEntity> collection;
        private SqliteConnection connection;

        public StationsRepository(string DBPath)
        {
            collection = new List<StationEntity>();
            connection = new SqliteConnection(DBPath);
        }
        public List<StationEntity> Data => collection;
        public int Count => collection.Count;

        public void Create(StationEntity item)
        {
            connection.Open();
            collection.Add(item);
            var command = new SqliteCommand($"INSERT INTO Stations (name) values ('{item.Name}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Stations WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Stations", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        collection.Add(new StationEntity(reader.GetInt32(0), reader.GetString(1)));
                    }
                }                
                connection.Close();
            }
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Stations SET name='{collection[id - 1].Name}' WHERE id={id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
