namespace DataLayer.Entity
{
    public class DirectoryEntity
    {
        public int StationId { get; set; }
        public int RouteId { get; set; }
        public int TrainId { get; set; }
        public string Time { get; set; }

        public DirectoryEntity(int stationId, int trainId, int routeId, string time)
        {
            StationId = stationId;
            RouteId = routeId;
            TrainId = trainId;
            Time = time;
        }
    }
}
