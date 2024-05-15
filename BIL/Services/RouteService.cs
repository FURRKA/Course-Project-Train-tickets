using DataLayer.Entity;
using DataLayer.Repository;

namespace BIL.Services
{
    public class RouteService
    {
        private StationsRepository stations;
        private RouteRepository routes;
        private DistanceRepository distances;
        private RouteStationsDictionary routeStationList;
        private DirectoryRepository directory;

        private StationEntity startStation;
        private StationEntity finalStation;
        public int RouteId { get; set; }
        public RouteService(string DBpath)
        {
            stations = new StationsRepository(DBpath);
            routes = new RouteRepository(DBpath);
            distances = new DistanceRepository(DBpath);
            routeStationList = new RouteStationsDictionary(DBpath);
            directory = new DirectoryRepository(DBpath);

            stations.Read();
            routes.Read();
            distances.Read();
            routeStationList.Read();
            directory.Read();
        }

        public List<string> StationsNames()
        {
            var result = new List<string>();
            stations.Data.ForEach(stations => result.Add(stations.Name));
            return result;
        }

        public List<RoutEntity> FindRoute(string startStation, string finalStation)
        {
            var stationsName = new List<string>() { startStation, finalStation };

            var stationResult = stations.Data
                .Where(item => stationsName.Contains(item.Name))
                .OrderBy(item => stationsName.IndexOf(item.Name))
                .ToList();

            this.startStation = stationResult[0];
            this.finalStation = stationResult[1];

            var id = routeStationList.Data
                .Where(route => route.Value.Contains(stationResult[0].Id) &&
                route.Value.Contains(stationResult[1].Id) &&
                route.Value.IndexOf(stationResult[1].Id) > route.Value.IndexOf(stationResult[0].Id))
                .Select(item => item.Key);

            return routes.Data.Where(item => id.Contains(item.Id)).ToList();
        }

        public List<dynamic> StationsInRoute()
        {
            var stationsInRoute = routeStationList.Data[RouteId];
            var time = directory.Data.Where(item => stationsInRoute.Contains(item.StationId) && item.RouteId == RouteId)
                .ToList();
            var result = stationsInRoute
                .Join(time, s => s, t => t.StationId, (s, t) => new { stations.Data[s-1].Name, t.Time })
                .ToList<dynamic>();

            return result;
        }

        public int GetRouteDistance()
        {
            int startIndex = routeStationList.Data[RouteId].IndexOf(startStation.Id);
            int finalIndex = routeStationList.Data[RouteId].IndexOf(finalStation.Id);
            var stationsInRoute = routeStationList.Data[RouteId].Take(startIndex..(finalIndex+1)).ToList();
            return distances.Data.Where(item => stationsInRoute.Contains(item.IdFirst) && stationsInRoute.Contains(item.IdSecond)).Sum(item => item.Distance);
        }
    }
}
