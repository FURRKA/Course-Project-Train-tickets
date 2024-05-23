using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class TicketEntity : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainId { get; set; }
        public string CarType { get; set; }
        public int CarNumber { get; set; }
        public int SeatNumber { get; set; }
        public double TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string StartStation { get; set; }
        public string FinalStation { get; set; }
        public string DepartTime { get; set; }
        public string ArriveTime { get; set; }
        public bool Paid { get; set; }

        public TicketEntity(int id, int userId, int trainId, string carType, int carNumber, int seatNumber, double totalCost, DateTime date, string startStation, string finalStation, string departTime, string arriveTime, bool paid)
        {
            Id = id;
            UserId = userId;
            TrainId = trainId;
            CarType = carType;
            CarNumber = carNumber;
            SeatNumber = seatNumber;
            TotalCost = totalCost;
            Date = date;
            StartStation = startStation;
            FinalStation = finalStation;
            DepartTime = departTime;
            ArriveTime = arriveTime;
            Paid = paid;
        }
    }
}
