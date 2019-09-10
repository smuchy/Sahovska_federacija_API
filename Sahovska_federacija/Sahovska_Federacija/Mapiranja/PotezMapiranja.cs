using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class PotezMapiranja : ClassMap<Potez>
    {
        public PotezMapiranja()
        {
            Table("POTEZ");

            Id(x => x.redni_br, "REDNI_BR").GeneratedBy.SequenceIdentity("POTEZ_RED_BR_SEQ");
            Map(x => x.opis, "OPIS");
            Map(x => x.kad_odigran, "KAD_ODIGRAN");

            References(x => x.je_odigran).Column("PARTIJA_ID").LazyLoad();
        }
    }
}
