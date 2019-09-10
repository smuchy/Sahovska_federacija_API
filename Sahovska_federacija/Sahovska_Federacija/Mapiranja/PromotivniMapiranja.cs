using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;


namespace Sahovska_Federacija.Mapiranja
{
    public class PromotivniMapiranja : SubclassMap<Promotivni>
    {
        public PromotivniMapiranja()
        {
            Table("PROMOTIVNI");
            KeyColumn("ID_TURNIRA");
        }
    }
}
