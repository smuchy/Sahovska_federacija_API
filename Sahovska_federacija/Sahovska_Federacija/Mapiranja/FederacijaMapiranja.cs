using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    class FederacijaMapiranja : ClassMap<Sahovska_Federacija.Entiteti.Federacija>
    {
        public FederacijaMapiranja() {

            Table("FEDERACIJA");
            Id(x => x.registracioni_broj, "REGISTRACIONI_BROJ").GeneratedBy.SequenceIdentity("FEDERACIJA_ID_SEQ");
        
            Map(x => x.lokacija, "LOKACIJA");

            HasMany(x => x.Sahovski_turniri).KeyColumn("FEDERACIJA_REG_BR").LazyLoad().Cascade.All();
            HasMany(x => x.Sahisti).KeyColumn("FEDERACIJA_REG_BR");
        }
    }
}
