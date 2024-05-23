using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class CarTypesRepository
    {
        private static Dictionary<int, string> types;
        private SqliteConnection connection;

        public Dictionary<int, string> Data => types;
        public int Count => types.Count;
        public string GetType(int id) => types[id];

        public CarTypesRepository(string path)
        {
            connection = new SqliteConnection(path);
            types = new Dictionary<int, string>();
        }

        public void Create(int typeId, string type)
        {
            connection.Open();
            if (types.ContainsKey(typeId))
                types[typeId] = type;
            else
                types.Add(typeId, type);
            var command = new SqliteCommand($"INSERT INTO Car VALUES ({typeId}, '{type}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"Select * from Car", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int typeID = reader.GetInt32(0);
                        string type = reader.GetString(1);

                        if (types.ContainsKey(typeID))
                        {
                            types[typeID] = type;
                        }
                        else
                        {
                            types.Add(typeID, type);
                        }
                    }
                }
            }
            connection.Close();
        }

        public void Update(int id, string type)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Car SET type = '{type} WHERE id = {id}'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Car WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
