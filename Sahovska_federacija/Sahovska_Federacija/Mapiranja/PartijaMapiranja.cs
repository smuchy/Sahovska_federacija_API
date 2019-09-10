using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class PartijaMapiranja : ClassMap<Partija>
    {
        public PartijaMapiranja()
        {
            Table("PARTIJA");

            Id(x => x.id_partije, "ID_PARTIJE").GeneratedBy.SequenceIdentity("PARTIJA_ID_SEQ");

            Map(x => x.bele, "BELE_FIGURE");
            Map(x => x.crne, "CRNE_FIGURE");
            Map(x => x.kad_se_igra, "KAD_SE_IGRA");
            Map(x => x.trajanje, "TRAJANJE");
            Map(x => x.pat, "PAT");
            Map(x => x.mat, "MAT");
            Map(x => x.rem, "REM");

            References(x => x.IgraSe).Column("TURNIR_ID").LazyLoad();

            HasMany(x => x.Potezi).KeyColumn("PARTIJA_ID").LazyLoad().Cascade.All().Inverse();
        }

    }
}
