using DataLayer.Repository;

namespace BIL.Services
{
    public class DataService
    {
        private SeatsRepository trainComposition;
        public DataService(string DBPath)
        {
            trainComposition = new SeatsRepository(DBPath);
            trainComposition.Read();
            trainComposition.DeleteOldTickets();
        }

        public List<int> SeatsList(int trainId, int carNumber, string date)
        {
            if (trainComposition.Find(trainId, carNumber, date))
            {
                return trainComposition.Data[trainId][date][carNumber];
            }
            else
            {
                trainComposition.Create(trainId, carNumber, date, "0");
                return trainComposition.Data[trainId][date][carNumber];
            }
        }
        public void SeatsDataUpdate(int trainId, int carNumber, string date) => trainComposition.Update(trainId, carNumber, date);
        public List<dynamic> GetCarsInfo(int trainId)
        {
            return new List<dynamic>();
        }
    }
}
