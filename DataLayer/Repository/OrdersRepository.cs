using DataLayer.Entity;
using DataLayer.Interfaces;
using Microsoft.Data.Sqlite;

namespace DataLayer.Repository
{
    public class OrdersRepository : ICRUD<TicketEntity>
    {
        private static Dictionary<int, List<TicketEntity>> payTickets;
        private SqliteConnection connection;
        public Dictionary<int, List<TicketEntity>> Data => payTickets;
        public int Count => payTickets.Count;
        public OrdersRepository(string DBpath)
        {
            connection = new SqliteConnection(DBpath);
            payTickets = new Dictionary<int, List<TicketEntity>>();
        }

        public void Create(TicketEntity item)
        {
            connection.Open();
            if (payTickets.ContainsKey(item.UserId))
            {
                payTickets[item.UserId].Add(item);
            }
            else
            {
                payTickets.Add(item.UserId, new List<TicketEntity>());
                payTickets[item.UserId].Add(item);
            }
            var command = new SqliteCommand($"INSERT INTO Orders VALUES (" +
                $"{item.Id}," +
                $"{item.UserId}," +
                $"{item.TrainId}," +
                $"'{item.CarType}'," +
                $"{item.CarNumber}," +
                $"{item.SeatNumber}," +
                $"$cost," +
                $"'{item.Date}'," +
                $"'{item.StartStation}'," +
                $"'{item.FinalStation}'," +
                $"'{item.DepartTime}'," +
                $"'{item.ArriveTime}'," +
                $"{item.Paid}," +
                $"'{item.CreateTime}'," +
                $"{item.CardNumber}," +
                $"{item.CVC})", connection);
            command.Parameters.AddWithValue("$cost", item.TotalCost);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int id)
        {
            connection.Open();
            int key = payTickets.FirstOrDefault(x => x.Value.Any(item => item.Id == id)).Key;
            payTickets[key].Remove(payTickets[key].FirstOrDefault(item => item.Id == id));
            var command = new SqliteCommand($"DELETE FROM Orders WHERE id = {id}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand($"SELECT * FROM Orders", connection);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int userId = reader.GetInt32(1);
                        int trainId = reader.GetInt32(2);
                        string carType = reader.GetString(3);
                        int carNumber = reader.GetInt32(4);
                        int seatNumber = reader.GetInt32(5);
                        double cost = reader.GetDouble(6);
                        DateTime date = DateTime.Parse(reader.GetString(7));
                        string startStation = reader.GetString(8);
                        string finalStation = reader.GetString(9);
                        string departTime = reader.GetString(10);
                        string arrivalTime = reader.GetString(11);
                        bool paid = reader.GetBoolean(12);
                        DateTime createTime = DateTime.Parse(reader.GetString(13));
                        Int64 cardNumber = reader.GetInt64(14);
                        int cvc = reader.GetInt32(15);

                        if (payTickets.ContainsKey(userId))
                        {
                            payTickets[userId].Add(new TicketEntity(id, userId, trainId, carType, carNumber, seatNumber, cost, date, startStation, finalStation, departTime, arrivalTime, paid, createTime, cardNumber, cvc));
                        }
                        else
                        {
                            payTickets.Add(userId, new List<TicketEntity>());
                            payTickets[userId].Add(new TicketEntity(id, userId, trainId, carType, carNumber, seatNumber, cost, date, startStation, finalStation, departTime, arrivalTime, paid, createTime, cardNumber, cvc));
                        }
                    }
                }
            }
            connection.Close();
        }

        public void Update(int id)
        {
            connection.Open();
            int key = payTickets.FirstOrDefault(item => item.Value.Any(x => x.Id == id)).Key;
            var item = payTickets[key].Find(item => item.Id == id);
            var command = new SqliteCommand($"UPDATE Orders SET " +
                $"user_id = {item.UserId}," +
                $"train_id = {item.TrainId}," +
                $"cartype = '{item.CarType}'," +
                $"carnumber = {item.CarNumber}," +
                $"seatnumber = {item.SeatNumber}," +
                $"cost = $cost," +
                $"date = '{item.Date}'," +
                $"startstation = '{item.StartStation}'," +
                $"finalstation ='{item.FinalStation}'," +
                $"timedepart = '{item.DepartTime}'," +
                $"timearrive = '{item.ArriveTime}'," +
                $"paid = {item.Paid}," +
                $"cardnumber = {item.CardNumber}," +
                $"cvc = {item.CVC} WHERE id = {id}", connection);
            command.Parameters.AddWithValue("$cost", item.TotalCost);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int MaxId()
        {
            if (Count > 0)
                return payTickets.ToList()
                    .Where(item => item.Value.Any())
                    .Max(item => item.Value.Max(x => x.Id));
            else
                return 0;
        }

        public bool DeleteNonPaidTickets(SeatsRepository seats)
        {
            const int delay = 20;

            var tickets2delete = payTickets
                .Where(item => item.Value.Any(t => DateTime.Now.Minute - t.CreateTime.Minute > delay && !t.Paid))
                .ToList();

            foreach (var (userId, userTickets) in tickets2delete)
            {
                var ticketsToRemove = userTickets.ToList();
                foreach (var ticket in ticketsToRemove)
                {
                    seats.FreeSeat(ticket.TrainId, ticket.CarNumber, ticket.Date.ToString(), ticket.SeatNumber);
                    Delete(ticket.Id);
                    payTickets[userId].Remove(ticket);
                }
            }

            return tickets2delete.Count > 0;
        }

        public void DeleteOldTickets()
        {
            var tickets2delete = payTickets
                .Where(t => t.Value.Any(date => date.Date.Date < DateTime.Now.Date))
                .ToList();

            foreach (var (userId, userTickets) in tickets2delete)
            {
                var ticketsToRemove = userTickets.ToList();
                foreach (var ticket in ticketsToRemove)
                {
                    Delete(ticket.Id);
                    payTickets[userId].Remove(ticket);
                }
            }
        }
    }
}
