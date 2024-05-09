using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class StationEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StationEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
