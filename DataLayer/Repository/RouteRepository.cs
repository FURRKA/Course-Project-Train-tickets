using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class RouteRepository : ICRUD<RoutEntity>, IRepository<RoutEntity>
    {
        private static List<RoutEntity> collection;
        private SqliteConnection connection;

        public RouteRepository(string DBPath)
        {
            collection = new List<RoutEntity>();
            connection = new SqliteConnection(DBPath);
        }
        public List<RoutEntity> Data => collection;
        public int Count => collection.Count;

        public void Create(RoutEntity item)
        {
            connection.Open();
            collection.Add(item);
            var command = new SqliteCommand($"INSERT INTO Routes (name) values ('{item.RouteName}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Routes WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Routes", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        collection.Add(new RoutEntity(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
                connection.Close();
            }
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Routes SET name='{collection[id - 1].RouteName}' WHERE id={id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
