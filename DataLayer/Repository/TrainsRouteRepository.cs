using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class TrainsRouteRepository
    {
        private static Dictionary<int, List<int>> container;
        private SqliteConnection connection;

        public TrainsRouteRepository(string DBpath)
        {
            connection = new SqliteConnection(DBpath);
            container = new Dictionary<int, List<int>>();
        }

        public Dictionary<int, List<int>> Data => container;

        public int Count => container.Count;

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand("select * from TrainsRoute", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (container.ContainsKey(reader.GetInt32(0)))
                        {
                            container[reader.GetInt32(0)].Add(reader.GetInt32(1));
                        }
                        else
                        {
                            container.Add(reader.GetInt32(0), new List<int>() { reader.GetInt32(1) });
                        }
                    }
                }
            }
        }
    }
}
