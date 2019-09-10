using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class OrganizatorMapiranja : ClassMap<Organizator>
    {
        public OrganizatorMapiranja()
        {
            Table("ORGANIZATOR");

            Id(x => x.maticni_broj, "MATICNI_BROJ").GeneratedBy.SequenceIdentity("ORGANIZATOR_MAT_BR_SEQ");

            Map(x => x.ime, "IME");
            Map(x => x.prezime, "PREZIME");
            Map(x => x.adresa, "ADRESA");

            //mapiranje veze 1:N
            References(x => x.OrganizujeTurnir).Column("ID_TURNIRA").LazyLoad();
        }
       
    }
}
