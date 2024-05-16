using DataLayer.Repository;

namespace BIL.Services
{
    public class DataService
    {
        private TrainCompositionRepostitory trainComposition;
        public DataService(string DBPath)
        {
            trainComposition = new TrainCompositionRepostitory(DBPath);
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
    }
}
