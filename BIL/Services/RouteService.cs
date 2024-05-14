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

        private StationEntity startStation;
        private StationEntity finalStation;
        public int RouteId { get; set; }

        public RouteService(string DBpath)
        {
            stations = new StationsRepository(DBpath);
            routes = new RouteRepository(DBpath);
            distances = new DistanceRepository(DBpath);
            routeStationList = new RouteStationsDictionary(DBpath);

            stations.Read();
            routes.Read();
            distances.Read();
            routeStationList.Read();
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

        public List<string> StationsInRoute()
        {
            return routeStationList.Data[RouteId]
                .Select(item => stations.Data[item - 1].Name)
                .ToList();
        }

        public int GetRouteDistance()
        {
            int startIndex = routeStationList.Data[RouteId - 1].IndexOf(startStation.Id);
            int finalIndex = routeStationList.Data[RouteId - 1].IndexOf(finalStation.Id);
            var stationsInRoute = routeStationList.Data[RouteId].Take(startIndex..finalIndex);
            return distances.Data.Where(item => stationsInRoute.Contains(item.IdFirst) && stationsInRoute.Contains(item.IdSecond)).Sum(item => item.Distance);
        }
    }
}
