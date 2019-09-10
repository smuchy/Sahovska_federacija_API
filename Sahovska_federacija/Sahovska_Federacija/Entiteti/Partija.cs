using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahovska_Federacija.Entiteti
{
    public class Partija
    {
        public virtual int id_partije { get; set; }
        public virtual string bele { get; set; }
        public virtual string crne { get; set; }
        public virtual string kad_se_igra { get; set; }
        public virtual int trajanje { get; set; }
        public virtual string pat { get; set; }
        public virtual string mat { get; set; }
        public virtual string rem { get; set; }

        public virtual Sahovski_turnir IgraSe { get; set; }

        public virtual IList<Potez> Potezi { get; set; }
        public Partija()
        {
            Potezi = new List<Potez>();
        }
    }
}
