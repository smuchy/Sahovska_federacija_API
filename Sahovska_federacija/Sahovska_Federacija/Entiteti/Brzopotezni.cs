using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Brzopotezni : Sahovski_turnir
    {
        public virtual int max_vreme_trajanja_partija { get; set; }
    }
}
