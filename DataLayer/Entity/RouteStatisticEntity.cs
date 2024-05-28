namespace DataLayer.Entity
{
    public class RouteStatisticEntity
    {
        public int RouteId { get; set; }
        public int SelectCount { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public RouteStatisticEntity(int routeId, int month, int year, int selectCount)
        {
            RouteId = routeId;
            SelectCount = selectCount;
            Month = month;
            Year = year;
        }
    }
}
