using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class Majstorski_kandidatMapiranja : SubclassMap<Majstorski_kandidat>
    {
        public Majstorski_kandidatMapiranja()
        {
            Table("MAJSTORSKI_KANDIDAT");
            KeyColumn("REGISTRACIONI_BROJ_SAHISTE");
            Map(x => x.br_odigranih_partija, "BR_ODIGRANIH_PARTIJA");
            Map(x => x.br_partija_do_zvanja, "BR_PARTIJA_DO_ZVANJA");
        }
    }
}
