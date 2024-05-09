using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
