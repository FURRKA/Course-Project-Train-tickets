using DataLayer.Interfaces;

namespace DataLayer.Entity
{
    public class RoutEntity : IEntity
    {
        public int Id { get; set; }
        public string RouteName { get; set; }

        public RoutEntity(int id, string routeName)
        {
            Id = id;
            RouteName = routeName;
        }
    }
}
