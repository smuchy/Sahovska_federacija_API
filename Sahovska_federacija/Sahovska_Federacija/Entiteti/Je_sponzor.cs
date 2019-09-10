using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Je_sponzor
    {
        public virtual int Id { get; set; }

        public virtual Sahovski_turnir SponzoriseTurnir { get; set; }
        public virtual Sponzor SponzorJe { get; set; }
    }
}
