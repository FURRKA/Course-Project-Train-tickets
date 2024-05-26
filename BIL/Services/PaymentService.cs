using DataLayer.Entity;
using DataLayer.Repository;

namespace BIL.Services
{
    public class PaymentService
    {
        private CardsRepository cards;
        public PaymentService(string DBPath)
        {
            cards = new CardsRepository(DBPath);
            cards.Read();
        }

        private CardEntity? FindCard(Int64 number, int cvc) => cards.Data.Find(c => c.Number == number && c.CVC == cvc);
        public bool CardExist(Int64 number, int cvc) => cards.Data.Any(c => c.Number == number && c.CVC == cvc);
        public bool BalanceEnough(Int64 number,int cvc, double value)
        {
            var card = FindCard(number, cvc);
            return card != null && card.Balance > value;                
        }
        public bool WithdrawBalance(Int64 number,int cvc, double value)
        {
            var card = FindCard(number,cvc);

            if (BalanceEnough(number, cvc, value) && card != null)
            {
                int index = cards.Data.IndexOf(card);
                cards.Data[index].Balance -= value;
                cards.Update(index + 1);
                return true;
            }

            return false;
        }

        public bool Replenish(Int64 number,int cvc, double value)
        {
            var card = FindCard(number, cvc);

            if (card != null)
            {
                int index = cards.Data.IndexOf(card);
                cards.Data[index].Balance += value;
                cards.Update(index + 1);
                return true;
            }

            return false;
        }
    }
}
