using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    //This repository is not right :c
    //Routes not contains ID
    public class DistanceRepository : IRepository<DistanceEntity>
    {
        private static List<DistanceEntity> collection;
        private SqliteConnection connection;

        public DistanceRepository(string DBPath)
        {
            collection = new List<DistanceEntity>();
            connection = new SqliteConnection(DBPath);
        }
        public List<DistanceEntity> Data => collection;
        public int Count => collection.Count;

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Km", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        collection.Add(new DistanceEntity(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                connection.Close();
            }
        }
    }
}
