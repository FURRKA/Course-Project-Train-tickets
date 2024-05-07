using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Interfaces
{
    internal interface IEntity
    {
        public int Id { get; set; }
    }
}
