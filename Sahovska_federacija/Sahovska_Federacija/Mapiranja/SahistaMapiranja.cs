using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    class SahistaMapiranja : ClassMap<Sahista>
    {
        public SahistaMapiranja()
        {
            Table("SAHISTA");

            Id(x => x.registracioni_broj).Column("REGISTRACIONI_BROJ_SAHISTE").GeneratedBy.SequenceIdentity("SAHISTA_ID_SEQ");

            
            Map(x => x.br_pasosa).Column("BR_PASOSA");
            Map(x => x.ime).Column("IME");
            Map(x => x.prezime).Column("PREZIME");
            Map(x => x.ulica).Column("ULICA");
            Map(x => x.broj).Column("BROJ");
            Map(x => x.datum_rodjenja).Column("DATUM_RODJENJA");
            Map(x => x.zemlja_porekla).Column("ZEMLJA_POREKLA");
            Map(x => x.tip).Column("TIP");
            // Map(x => x.tip).Column("TIP");
            //mapiranje veze 1:N
            References(x => x.ClanFederacije).Column("FEDERACIJA_REG_BR").LazyLoad();

        }

        
    }
}
