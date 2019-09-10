using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class Obican_clanMapiranja : SubclassMap<Obican_clan>
    {
        public Obican_clanMapiranja()
        {
            Table("OBICAN_CLAN");
            KeyColumn("REGISTRACIONI_BROJ_SAHISTE");
        }
    }
}
