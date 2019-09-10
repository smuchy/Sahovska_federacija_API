using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class BrzopotezniMapiranja : SubclassMap<Brzopotezni>
    {
        public BrzopotezniMapiranja()
        {
            Table("BRZOPOTEZNI");
            KeyColumn("ID_TURNIRA");
            Map(x => x.max_vreme_trajanja_partija).Column("MAX_VREME_TRAJANJA_PARTIJA");
        }
    }
}
