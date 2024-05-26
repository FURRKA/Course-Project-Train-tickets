using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class CardsRepository : IRepository<CardEntity>, ICRUD<CardEntity>
    {
        private static List<CardEntity> cards;
        private SqliteConnection connection;
        public List<CardEntity> Data => cards;
        public int Count => cards.Count;

        public CardsRepository(string DBPath)
        {
            connection = new SqliteConnection(DBPath);
            cards = new List<CardEntity>();
        }

        public void Create(CardEntity item)
        {
            connection.Open();
            cards.Add(item);
            var command = new SqliteCommand($"INSERT INTO PayCards VALUES ({item.Id},{item.Number},{item.CVC}, @balance)", connection);
            command.Parameters.AddWithValue("@balance", item.Balance);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            cards.RemoveAt(id - 1);
            var command = new SqliteCommand($"DELETE FROM PayCards WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM PayCards", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        Int64 number = reader.GetInt64(1);
                        int cvc = reader.GetInt32(2);
                        double balance = reader.GetDouble(3);
                        cards.Add(new CardEntity(id, number, cvc, balance));
                    }
                }
            }
            connection.Close();
        }

        public void Update(int id)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE PayCards SET balance = @balance WHERE id = {id}", connection);
            command.Parameters.AddWithValue("@balance", cards[id - 1].Balance);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int GetMaxId()
        {
            if (cards.Count > 0)
                return cards.Max(c => c.Id);
            else
                return 0;
        }
    }
}
