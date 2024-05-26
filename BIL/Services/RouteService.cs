using DataLayer.Entity;
using DataLayer.Repository;
using System.Runtime.InteropServices;

namespace BIL.Services
{
    public class RouteService
    {
        private StationsRepository stations;
        private RouteRepository routes;
        private DistanceRepository distances;
        private RouteStationsDictionary routeStationList;
        private DirectoryRepository directory;
        private TrainsRouteRepository trains;

        private StationEntity startStation;
        private StationEntity finalStation;

        public int RouteId { get; set; }
        public int TrainId { get; set; }
        public double Cost { get; set; }
        public string StartStation => startStation.Name;
        public string FinalStation => finalStation.Name;
        public RouteService(string DBpath)
        {
            stations = new StationsRepository(DBpath);
            routes = new RouteRepository(DBpath);
            distances = new DistanceRepository(DBpath);
            routeStationList = new RouteStationsDictionary(DBpath);
            directory = new DirectoryRepository(DBpath);
            trains = new TrainsRouteRepository(DBpath);

            stations.Read();
            trains.Read();
            routes.Read();
            distances.Read();
            routeStationList.Read();
            directory.Read();
            Cost = 0.06;
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
            TrainId = trains.Data.FirstOrDefault(item => item.Value.Contains(RouteId)).Key;

            var time = directory.Data.Where(item => stationsInRoute.Contains(item.StationId) && item.RouteId == RouteId && trains.Data[TrainId].Contains(item.RouteId))
                .ToList();

            var result = stationsInRoute
                .Join(time, s => s, t => t.StationId, (s, t) => new {Станция = stations.Data[s-1].Name, Время = t.Time, Поезд = t.TrainId })
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

        public void GetTrainId()
        {
            TrainId = trains.Data.FirstOrDefault(item => item.Value.Contains(RouteId)).Key;
        }

        public string FindStationTime(int routeID, string stationName)
        {
            return directory.Data.Find(item => item.RouteId == routeID && item.StationId == stations.Data.Find(s => s.Name == stationName).Id).Time;
        }
    }
}
