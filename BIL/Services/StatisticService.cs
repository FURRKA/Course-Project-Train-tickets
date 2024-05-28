using DataLayer.Entity;
using DataLayer.Repository;

namespace BIL.Services
{
    public enum Month
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь
    }

    public class StatisticService
    {
        private StatisticRepository statistic;
        private RouteStatisticRepository routeStatistic;

        public StatisticService(string DBPath)
        {
            statistic = new StatisticRepository(DBPath);
            routeStatistic = new RouteStatisticRepository(DBPath);

            routeStatistic.Read();
            statistic.Read();
        }

        public void CreateStatisticRecord(int year, int month, double value)
        {
            var statisticData = new StatisticEntity(month, year, value);
            if (!statistic.RecordExist(statisticData))
                statistic.Create(statisticData);
            else
                AddRevenue(year, month, value);
        }

        public void CreateRouteStatisticRecord(int routeId, int month, int year, int count = 1)
        {
            var statisticData = new RouteStatisticEntity(routeId, month, year, count);
            if (!routeStatistic.RecordExist(statisticData))
                routeStatistic.Create(statisticData);
            else
            {
                var data = routeStatistic.Data[year].Find(item => item.RouteId == routeId && item.Month == month);
                if (data != null)
                {
                    data.SelectCount++;
                    routeStatistic.Update(data);
                }
            }
        }

        public void AddRevenue(int year, int month, double value)
        {
            var item = statistic.Data[year].Find(item => item.Month == month);
            if (item != null)
            {
                item.Revenue += value;
                statistic.Update(item);
            }
        }

        public void DecreaseRevenue(int year, int month, double value)
        {
            var item = statistic.Data[year].Find(item => item.Month == month);
            if (item != null)
            {
                item.Revenue -= value;
                statistic.Update(item);
            }
        }

        public List<RouteStatisticEntity> GetRouteStatistic(int month, int year)
        {
            if (routeStatistic.Data.ContainsKey(year))
                return routeStatistic.Data[year].Where(s => s.Month == month).ToList();
            else
                return new List<RouteStatisticEntity>();
        }

        public List<StatisticEntity> GetStatistic(int year)
        {
            if (statistic.Data.ContainsKey(year))
                return statistic.Data[year];
            else
                return new List<StatisticEntity>();
        }
    }
}
