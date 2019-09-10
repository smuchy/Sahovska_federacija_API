using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sahovska_Federacija.Entiteti;
using FluentNHibernate.Mapping;

namespace Sahovska_Federacija.Mapiranja
{
    public class EgzibicioniMapiranja : SubclassMap<Egzibicioni>
    {
        public EgzibicioniMapiranja()
        {
            Table("EGZIBICIONI");
            KeyColumn("ID_TURNIRA");
        }
    }
}
