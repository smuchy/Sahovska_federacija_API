using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Majstor : Sahista
    {
        public virtual string datum_sticanja_zvanja { get; set; }
    }
}
