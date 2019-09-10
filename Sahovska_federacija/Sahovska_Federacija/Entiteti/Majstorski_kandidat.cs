using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Majstorski_kandidat : Sahista
    {
        public virtual int br_odigranih_partija { get; set; }
        public virtual int br_partija_do_zvanja { get; set; }
    }
}
