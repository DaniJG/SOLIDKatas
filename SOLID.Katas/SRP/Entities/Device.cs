using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Katas.SRP.Entities
{
    public class Device: Entity
    {
        public string Model { get; set; }
        public int Version { get; set; }
        public User User { get; set; }        
    }
}
