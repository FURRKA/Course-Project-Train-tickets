using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class StatisticEntity
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public double Revenue { get; set; }

        public StatisticEntity(int month, int year, double revenue)
        {
            Month = month;
            Year = year;
            Revenue = revenue;
        }
    }
}
