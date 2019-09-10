using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Sahovski_turnir
    {
        public virtual int id_turnira { get; set; }
        public virtual string naziv { get; set; }
        public virtual string zemlja { get; set; }
        public virtual string grad { get; set; }
        public virtual int god_odrzavanja { get; set; }
        public virtual string tip { get; set; }
        public virtual string odigran { get; set; }

        public virtual Federacija Je_pokrovitelj { get; set; }
        public virtual IList<Sponzor> Sponzori { get; set; }
        public virtual IList<Je_sponzor> Sponzor_je { get; set; }
        public virtual IList<Organizator> Organizatori { get; set; }
        public virtual IList<Partija> Partije { get; set; }

        public Sahovski_turnir()
        {
            Sponzor_je = new List<Je_sponzor>();
            Sponzori = new List<Sponzor>();
            Organizatori = new List<Organizator>();
            Partije = new List<Partija>();
        }
    }

 
}
