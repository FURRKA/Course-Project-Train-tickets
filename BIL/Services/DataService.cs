﻿using DataLayer.Entity;
using DataLayer.Repository;

namespace BIL.Services
{
    public class DataService
    {
        private SeatsRepository seats;
        private TrainCompositionRepository trainComposition;
        private OrdersRepository orders;
        private ClientService clients;
        public DataService(string DBPath)
        {
            seats = new SeatsRepository(DBPath);
            trainComposition = new TrainCompositionRepository(DBPath);
            orders = new OrdersRepository(DBPath);
            clients = new ClientService(DBPath);

            orders.Read();
            trainComposition.Read();
            seats.Read();

            seats.DeleteOldTickets();
            DeleteOldTickets();
        }

        public List<int> SeatsList(int trainId, int carNumber, string date)
        {
            if (seats.Find(trainId, carNumber, date))
            {
                return seats.Data[trainId][date][carNumber];
            }
            else
            {
                seats.Create(trainId, carNumber, date, "0");
                return seats.Data[trainId][date][carNumber];
            }
        }
        public void SeatsDataUpdate(int trainId, int carNumber, string date) => seats.Update(trainId, carNumber, date);
        public List<CarEntity> GetCarsInfo(int trainId) => trainComposition.Data[trainId];

        public void CreateOrder(UserEnity user, int trainID, string carType, int carNumber, int seatNumber, double totalCost, 
            DateTime date, string startStation, string finalStation, string departTime, string arriveTime)
        {
            orders.Create(new TicketEntity(orders.MaxId() + 1, user.Id, trainID, carType, carNumber, seatNumber, totalCost, date, startStation, finalStation, departTime, arriveTime, false, DateTime.Now));
        }

        public List<TicketEntity> GetTickets(int userId)
        {
            if (!orders.Data.ContainsKey(userId))
                orders.Data.Add(userId, new List<TicketEntity>());

            return orders.Data[userId];
        }
        public bool UserHasOrders(int userId)
        {
            if (!orders.Data.ContainsKey(userId))
                orders.Data.Add(userId, new List<TicketEntity>());

            return orders.Data[userId].Where(t => t.Paid).Count() > 0;
        }
        public bool UserHasUnpaidOrders(int userId)
        {
            if (!orders.Data.ContainsKey(userId))
                orders.Data.Add(userId, new List<TicketEntity>());

            return orders.Data[userId].Where(t => !t.Paid).Count() > 0;
        }
        public bool HasOrders => orders.Count > 0;

        public bool DeleteNonPaidTickets()
        {
            return orders.DeleteNonPaidTickets(seats);
        }

        public void DeleteOldTickets() => orders.DeleteOldTickets();

        public void ChangePaidStatus(int userId, List<int> ids, Int64 cardNumer, int cvc)
        {
            orders.Data[userId]
                .Where(t => ids.Contains(t.Id))
                .ToList()
                .ForEach(t => { 
                    t.Paid = true;
                    t.CardNumber = cardNumer;
                    t.CVC = cvc;
                });

            ids.ForEach(id => orders.Update(id));
        }

        public void CancelTicket(int userId, int ticketId, PaymentService paymentService, StatisticService statisticService)
        {
            var order = orders.Data[userId].Find(t => t.Id == ticketId);
            seats.FreeSeat(order.TrainId, order.CarNumber, order.Date.ToString(), order.SeatNumber);
            paymentService.Replenish(order.CardNumber, order.CVC, order.TotalCost);
            statisticService.DecreaseRevenue(order.Date.Year, order.Date.Month, order.TotalCost);
            orders.Delete(ticketId);
        }

        public void DeleteUser(int id) => clients.DeleteUser(id);
    }
}
