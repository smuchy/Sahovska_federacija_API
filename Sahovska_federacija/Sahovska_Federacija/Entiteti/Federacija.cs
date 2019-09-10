using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Federacija
    {
        public virtual int registracioni_broj { get; set; }
        public virtual string lokacija { get; set; }

        public virtual IList<Sahovski_turnir> Sahovski_turniri { get; set; }
        public virtual IList<Sahista> Sahisti { get; set; }

        public Federacija() {
            Sahovski_turniri = new List<Sahovski_turnir>();

            Sahisti = new List<Sahista>();
        }
    }
}
