using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> Data { get; }
        public int Count { get; }
    }
}
