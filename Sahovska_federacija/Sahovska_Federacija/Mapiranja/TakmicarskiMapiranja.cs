using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class TakmicarskiMapiranja : SubclassMap<Takmicarski>
    {
        public TakmicarskiMapiranja()
        {
            Table("TAKMICARSKI");
            KeyColumn("ID_TURNIRA");
            Map(x => x.internacionalni, "INTERNACIONALNI");
            Map(x => x.nacionalni, "NACIONALNI");
            Map(x => x.regionalni, "REGIONALNI");
        }
    }
}
