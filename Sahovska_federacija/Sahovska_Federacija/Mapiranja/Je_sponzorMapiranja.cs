using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class Je_sponzorMapiranja : ClassMap<Je_sponzor>
    {
        public Je_sponzorMapiranja()
        {
            Table("JE_SPONZOR");

            Id(x => x.Id, "ID").GeneratedBy.SequenceIdentity("JE_SPONZOR_ID_SEQ");

            References(x => x.SponzoriseTurnir).Column("ID_TURNIRA");
            References(x => x.SponzorJe).Column("REG_BR_SPONZORA");
                
        }
    }
}
