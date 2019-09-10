using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahovska_Federacija.Entiteti
{
    public class Potez
    {
        public virtual int redni_br { get; set; }
        public virtual string opis { get; set; }
        public virtual string kad_odigran { get; set; }
        public virtual Partija je_odigran { get; set; }

        public Potez() { }
    }
}
