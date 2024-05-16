using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TrainId { get; set; }
        public int CarNumber { get; set; }
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public double Cost { get; set; }

        public Ticket(int id, int clientId, int trainId, int carNumber, string startStation, string endStation, double cost)
        {
            Id = id;
            ClientId = clientId;
            TrainId = trainId;
            CarNumber = carNumber;
            StartStation = startStation;
            EndStation = endStation;
            Cost = cost;
        }
    }
}
