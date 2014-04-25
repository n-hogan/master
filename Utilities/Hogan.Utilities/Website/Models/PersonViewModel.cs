using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Locked { get; set; }

    }
}