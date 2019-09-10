using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class MajstorMapiranja : SubclassMap<Majstor>
    {
        public MajstorMapiranja()
        {
            Table("MAJSTOR");
            KeyColumn("REGISTRACIONI_BROJ_SAHISTE");
            Map(x => x.datum_sticanja_zvanja, "DATUM_STICANJA_ZVANJA");
        }
    }
}
