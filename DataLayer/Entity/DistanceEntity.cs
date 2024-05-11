using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    public class DistanceEntity
    {
        public int IdFirst { get; set; }
        public int IdSecond { get; set; }
        public int Distance { get; set; }

        public DistanceEntity(int idFirst, int idSecond, int distance)
        {
            IdFirst = idFirst;
            IdSecond = idSecond;
            Distance = distance;
        }
    }
}
