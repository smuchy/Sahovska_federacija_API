using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Takmicarski : Sahovski_turnir
    {
        public virtual string internacionalni { get; set; }
        public virtual string regionalni { get; set; }
        public virtual string nacionalni { get; set; }
    }
}
