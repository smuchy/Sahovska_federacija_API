using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sahovska_Federacija.Entiteti
{
    public class Sahista
    {
        public virtual int registracioni_broj { get; set; }
        public virtual int br_pasosa { get; set; }
        public virtual string ime { get; set; }
        public virtual string prezime { get; set; }
        public virtual string ulica { get; set; }
        public virtual int broj { get; set; }
        public virtual string datum_rodjenja { get; set; }
        public virtual string zemlja_porekla { get; set; }
        public virtual string tip { get; set; }

        public virtual Federacija ClanFederacije { get; set; }

        public Sahista()
        {
        }
    }

    
}
