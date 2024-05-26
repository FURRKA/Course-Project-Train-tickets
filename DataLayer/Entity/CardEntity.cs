using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class CardEntity : IEntity
    {
        public int Id { get; set; }
        public Int64 Number { get; set; }
        public int CVC { get; set; }
        public double Balance { get; set; }

        public CardEntity(int id, Int64 number, int cVC, double balance)
        {
            Id = id;
            Number = number;
            CVC = cVC;
            Balance = balance;
        }
    }
}
