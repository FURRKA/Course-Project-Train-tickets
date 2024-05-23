using DataLayer.Entity;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class TrainCompositionRepository
    {
        private static Dictionary<int, List<CarEntity>> collection;
        private CarTypesRepository types;
        private SqliteConnection connection;

        public TrainCompositionRepository(string path)
        {
            connection = new SqliteConnection(path);
            collection = new Dictionary<int, List<CarEntity>>();
            types = new CarTypesRepository(path);
            types.Read();
        }
        public Dictionary<int, List<CarEntity>> Data => collection;
        public int Count => collection.Count;

        public void Create(int trainId, CarEntity car)
        {
            connection.Open();
            if (collection.ContainsKey(trainId)) //Удалить копипаст
            {
                collection[trainId].Add(car);
            }
            else
            {
                collection.Add(trainId, new List<CarEntity>());
                collection[trainId].Add(car);
            }
            var command = new SqliteCommand($"INSERT INTO TrainComposition VALUES ({trainId},{car.Id},{car.Number})", connection);
            command.ExecuteNonQuery();
            connection.Close();            
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"Select * from TrainComposition", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int trainId = reader.GetInt32(0);
                        int typeId = reader.GetInt32(1);
                        int carNumber = reader.GetInt32(2);
                        CarEntity car = new CarEntity(typeId, types.GetType(typeId), carNumber);

                        if (collection.ContainsKey(trainId))
                        {
                            collection[trainId].Add(car);
                        }
                        else
                        {
                            collection.Add(trainId, new List<CarEntity>());
                            collection[trainId].Add(car);
                        }
                    }
                }
            }
            connection.Close();
        }

        //public void Update(int trainId, CarEntity car)
        //{
        //    connection.Open();
        //    var command = new SqliteCommand($"UPDATE TrainComposition SET " +
        //        $"id_car = {}, carnumber = {} WHERE id_train == ", connection);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}

        public void Delete(int trainId, int carNumber)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM TrainComposition WHERE (id_train = {trainId}) AND (carnumber = {carNumber})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
