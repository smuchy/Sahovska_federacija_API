using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class SponzorMapiranja : ClassMap<Sponzor>
    {
        public SponzorMapiranja()
        {
            Table("SPONZOR");

            Id(x => x.reg_broj, "REG_BROJ").GeneratedBy.SequenceIdentity("SPONZOR_ID_SEQ");
            Map(x => x.ime, "IME");
            Map(x => x.opis, "OPIS");
            Map(x => x.logo, "LOGO");
           

            HasManyToMany(x => x.Sahovski_turniri)
                .Table("JE_SPONZOR")
                .ParentKeyColumn("REG_BR_SPONZORA")
                .ChildKeyColumn("ID_TURNIRA")
                .Cascade.All();

            HasMany(x => x.Sponzor_je_sponzor).KeyColumn("REG_BR_SPONZORA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
