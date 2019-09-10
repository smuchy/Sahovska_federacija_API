using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahovska_Federacija.Entiteti
{
    public class Organizator
    {
        public virtual int maticni_broj { get; set; }
        public virtual string ime { get; set; }
        public virtual string prezime { get; set; }
        public virtual string adresa { get; set; }

        public virtual Sahovski_turnir OrganizujeTurnir { get; set; }

        public Organizator()
        {

        }
    }
}
