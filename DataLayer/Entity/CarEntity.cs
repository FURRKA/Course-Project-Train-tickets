using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class CarEntity : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public CarEntity(int id, string type, int number)
        {
            Id = id;
            Type = type;
            Number = number;
        }
    }
}
