using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    internal class DistanceEntity : IEntity
    {
        public int Id { get; set; }
        public int IdFirst { get; set; }
        public int IdSecond { get; set; }
        public int Distance { get; set; }

        public DistanceEntity(int id, int idFirst, int idSecond, int distance)
        {
            Id = id;
            IdFirst = idFirst;
            IdSecond = idSecond;
            Distance = distance;
        }
    }
}
