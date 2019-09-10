using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;


namespace Sahovska_Federacija.Mapiranja
{
    public class Sahovski_turnirMapiranja : ClassMap<Sahovski_turnir>
    {
        public Sahovski_turnirMapiranja()
        {
            Table("SAHOVSKI_TURNIR");
  
            Id(x => x.id_turnira, "ID_TURNIRA").GeneratedBy.SequenceIdentity("SAHOVSKI_TURNIR_ID_SEQ");
            Map(x => x.naziv, "NAZIV");
            Map(x => x.grad, "GRAD");
            Map(x => x.god_odrzavanja, "GOD_ODRZAVANJA");
            Map(x => x.zemlja, "ZEMLJA");
            Map(x => x.tip, "TIP");
            Map(x => x.odigran, "ODIGRAN");

            References(x => x.Je_pokrovitelj).Column("FEDERACIJA_REG_BR").LazyLoad();

            HasManyToMany(x => x.Sponzori)
                .Table("JE_SPONZOR")
                .ParentKeyColumn("ID_TURNIRA")
                .ChildKeyColumn("REG_BR_SPONZORA")
                .Inverse()
                .Cascade.All();

           HasMany(x => x.Sponzor_je).KeyColumn("ID_TURNIRA").LazyLoad().Cascade.All().Inverse();
           HasMany(x => x.Organizatori).KeyColumn("ID_TURNIRA");
           HasMany(x => x.Partije).KeyColumn("TURNIR_ID");
        }
    }

}
