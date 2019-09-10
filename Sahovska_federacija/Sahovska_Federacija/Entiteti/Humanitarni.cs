using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Humanitarni : Egzibicioni
    {
        public virtual string kome_je_namenjen { get; set; }
        public virtual int prikupljeni_iznos { get; set; }
    }
}
