using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hcs.Data.Entities
{
    public abstract class Entity : IEntity
    {
        public virtual long Id { get; set; }
    }
}
