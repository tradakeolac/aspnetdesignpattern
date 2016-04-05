using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.Concurrency.Model
{
    public abstract class EntityBase
    {
        private int Version { get; set; }
    }
}
