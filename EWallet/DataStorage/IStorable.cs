using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; }
    }
}
