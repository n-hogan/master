using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hcs.Data.Entities
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}
