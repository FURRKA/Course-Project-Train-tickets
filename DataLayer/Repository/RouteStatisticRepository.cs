using DataLayer.Entity;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class RouteStatisticRepository
    {
        private static Dictionary<int, List<RouteStatisticEntity>> statistic;
        private SqliteConnection connection;

        public Dictionary<int, List<RouteStatisticEntity>> Data => statistic;
        public int Count => statistic.Count;

        public RouteStatisticRepository(string DBpath)
        {
            connection = new SqliteConnection(DBpath);
            statistic = new Dictionary<int, List<RouteStatisticEntity>>();
        }

        public bool RecordExist(RouteStatisticEntity item)
        {
            if (statistic.ContainsKey(item.Year))
                if (statistic[item.Year].Where(s => s.RouteId == item.RouteId && s.Month == item.Month && s.Year == item.Year).Count() > 0)
                    return true;

            return false;
        }

        public void Create(RouteStatisticEntity item)
        {
            connection.Open();
            if (statistic.ContainsKey(item.Year))
            {
                statistic[item.Year].Add(new RouteStatisticEntity(item.RouteId, item.Month, item.Year, item.SelectCount));
            }
            else
            {
                statistic.Add(item.Year, new List<RouteStatisticEntity>());
                statistic[item.Year].Add(new RouteStatisticEntity(item.RouteId, item.Month, item.Year, item.SelectCount));
            }
            var command = new SqliteCommand($"INSERT INTO RouteStatistic VALUES ({item.RouteId}, {item.Month}, {item.Year}, {item.SelectCount})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int route_id, int year, string month)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM RouteStatistic WHERE (year = {year}) AND (month = {month}) AND (route_id = {route_id})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM RouteStatistic", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int routeID = reader.GetInt32(0);
                        int month = reader.GetInt32(1);
                        int year = reader.GetInt32(2);
                        int count = reader.GetInt32(3);

                        if (statistic.ContainsKey(year))
                        {
                            statistic[year].Add(new RouteStatisticEntity(routeID, month, year, count));
                        }
                        else
                        {
                            statistic.Add(year, new List<RouteStatisticEntity>());
                            statistic[year].Add(new RouteStatisticEntity(routeID, month, year, count));
                        }
                    }
                }
            }
            connection.Close();
        }

        public void Update(RouteStatisticEntity item)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE RouteStatistic Set count={item.SelectCount} WHERE (year = {item.Year}) AND (month = {item.Month}) AND (route_id = {item.RouteId})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
