using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class HumanitarniMapiranja : SubclassMap<Humanitarni>
    {
        public HumanitarniMapiranja()
        {
            Table("HUMANITARNI");
            KeyColumn("ID_TURNIRA");
            Map(x => x.kome_je_namenjen, "KOME_JE_NAMENJEN");
            Map(x => x.prikupljeni_iznos, "PRIKUPLJENI_IZNOS");
        }
    }
}
