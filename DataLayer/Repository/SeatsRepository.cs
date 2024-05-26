using Microsoft.Data.Sqlite;
using System.Text;

namespace DataLayer.Repository
{
    public class SeatsRepository
    {
        //Dict<trainId, Dict<date, Dict<carNumber, List<seats> > > >
        private Dictionary<int, Dictionary<string, Dictionary<int, List<int>>>> collection;
        private SqliteConnection connection;

        public Dictionary<int, Dictionary<string, Dictionary<int, List<int>>>> Data => collection;
        public int Count => collection.Count;

        public SeatsRepository(string DBpath)
        {
            connection = new SqliteConnection(DBpath);
            collection = new Dictionary<int, Dictionary<string, Dictionary<int, List<int>>>>();
        }
        private void FillData(int trainId, int carNumber, string date, string seats)
        {
            if (collection.ContainsKey(trainId)) //key: idTrain
            {
                if (collection[trainId].ContainsKey(date))//key: date
                {
                    if (collection[trainId][date].ContainsKey(carNumber))//Key: carNumber
                    {
                        collection[trainId][date][carNumber] = StringToList(seats);
                    }
                    else
                    {
                        collection[trainId][date].Add(carNumber, new List<int>());
                        collection[trainId][date][carNumber] = StringToList(seats);
                    }
                }
                else
                {
                    collection[trainId].Add(date, new Dictionary<int, List<int>>());
                    collection[trainId][date].Add(carNumber, new List<int>());
                    collection[trainId][date][carNumber] = StringToList(seats);
                }
            }
            else
            {
                collection.Add(trainId, new Dictionary<string, Dictionary<int, List<int>>>());
                collection[trainId].Add(date, new Dictionary<int, List<int>>());
                collection[trainId][date].Add(carNumber, new List<int>());
                collection[trainId][date][carNumber] = StringToList(seats);
            }
        }

        public void Read()
        {
            connection.Open();
            var command = new SqliteCommand("select * from Seats", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var trainId = reader.GetInt32(0);
                    var carNumber = reader.GetInt32(1);
                    string date = reader.GetString(2);
                    string seats = reader.GetString(3);

                    FillData(trainId, carNumber, date, seats);
                }
            }

            connection.Close();
        }

        public void Create(int trainID, int carNumber, string Date, string seats)
        {
            connection.Open();
            if (!Find(trainID, carNumber, Date))
            {
                FillData(trainID, carNumber, Date, seats);
                var command = new SqliteCommand($"INSERT INTO Seats VALUES ({trainID},{carNumber},'{Date}','{ListToString(collection[trainID][Date][carNumber])}')", connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void Update(int trainID, int carNumber, string date)
        {
            connection.Open();
            var command = new SqliteCommand($"UPDATE Seats Set fill='{ListToString(collection[trainID][date][carNumber])}' WHERE (id_train = {trainID}) AND (date = '{date}') AND (carNumber = {carNumber})", connection);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void Delete(int trainID,int carNumber, string Date)
        {
            connection.Open();
            var command = new SqliteCommand($"DELETE FROM Seats WHERE (id_train = {trainID}) AND (date = '{Date}') AND (carNumber = {carNumber})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteOldTickets()
        {
            connection.Open();
            foreach (var trains in collection)
            {
                foreach (var time in trains.Value)
                {
                    if (DateTime.Parse(time.Key) < DateTime.Today)
                    {
                        var command = new SqliteCommand($"DELETE FROM Seats WHERE date='{time.Key}'", connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();
        }

        public List<int> StringToList(string data)
        {
            var words = data.Trim().Split(' ');
            var result = new List<int>();
            words.ToList().ForEach(item => result.Add(Convert.ToInt32(item)));

            return result;
        }

        public string ListToString(List<int> data)
        {
            var sb = new StringBuilder();
            data.ForEach(item => sb.Append(item).Append(" "));
            return sb.ToString();
        }

        public bool Find(int trainID, int carNumber, string Date)
        {
            if (!collection.ContainsKey(trainID))
                return false;

            if (!collection[trainID].ContainsKey(Date))
                return false;

            if (!collection[trainID][Date].ContainsKey(carNumber))
                return false;
        
            return true;
        }

        public void FreeSeat(int trainID, int carNumber, string Date, int seatnumber)
        {
            collection[trainID][Date][carNumber].Remove(seatnumber);
            Update(trainID, carNumber,Date);
        }
    }
}
