using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Sponzor
    {
        public virtual int reg_broj { get; set; }
        public virtual string ime { get; set; }
        public virtual string opis { get; set; }
        public virtual string logo { get; set; }

        public virtual IList<Je_sponzor> Sponzor_je_sponzor { get; set; }
        public virtual IList<Sahovski_turnir> Sahovski_turniri { get; set; }

        public Sponzor()
        {
            Sponzor_je_sponzor = new List<Je_sponzor>();
            Sahovski_turniri = new List<Sahovski_turnir>();
        }
    }
}
