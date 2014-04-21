using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hcs.Data.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }
}
