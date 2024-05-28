using DataLayer.Entity;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class StatisticRepository
    {
        private static Dictionary<int, List<StatisticEntity>> statistic;
        private SqliteConnection connection;

        public Dictionary<int, List<StatisticEntity>> Data => statistic;
        public int Count => statistic.Count;

        public StatisticRepository(string DBpath)
        {
            connection = new SqliteConnection(DBpath);
            statistic = new Dictionary<int, List<StatisticEntity>>();
        }

        public bool RecordExist(StatisticEntity item)
        {
            if (statistic.ContainsKey(item.Year))
                if (statistic[item.Year].Where(s => s.Month == item.Month && s.Year == item.Year).Count() > 0)
                    return true;

            return false;
        }

        public void Create(StatisticEntity item)
        {
            connection.Open();
            if (statistic.ContainsKey(item.Year))
            {
                statistic[item.Year].Add(new StatisticEntity(item.Month, item.Year, item.Revenue));
            }
            else
            {
                statistic.Add(item.Year, new List<StatisticEntity>());
                statistic[item.Year].Add(new StatisticEntity(item.Month, item.Year, item.Revenue));
            }
            var command = new SqliteCommand($"INSERT INTO Statistic VALUES ('{item.Month}',{item.Year},@revenue)", connection);
            command.Parameters.AddWithValue("@revenue", item.Revenue);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int year, string month)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Statistic WHERE (year = {year}) AND (month = '{month}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Statistic", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int month = reader.GetInt32(0);
                        int year = reader.GetInt32(1);
                        double revenue = reader.GetDouble(2);
                            
                        if (statistic.ContainsKey(year))
                        {
                            statistic[year].Add(new StatisticEntity(month, year, revenue));
                        }
                        else
                        {
                            statistic.Add(year, new List<StatisticEntity>());
                            statistic[year].Add(new StatisticEntity(month, year, revenue));
                        }    
                    }
                }
            }
            connection.Close();
        }

        public void Update(StatisticEntity item)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Statistic Set revenue=@revenue WHERE (year = {item.Year}) AND (month = {item.Month})", connection);
            command.Parameters.AddWithValue("@revenue", item.Revenue);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
