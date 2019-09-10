using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahovska_Federacija.Entiteti
{
    public class Je_sponzorId
    {
        public virtual int id { get; set; }

        public virtual Sponzor je_sponzor_sponzor { get; set; }
        public virtual Sahovski_turnir je_sponzor_turnir { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Je_sponzorId))
                return false;
            Je_sponzorId receivedObject = (Je_sponzorId)obj;

            if((je_sponzor_sponzor.reg_broj == receivedObject.je_sponzor_sponzor.reg_broj) && (je_sponzor_turnir.id_turnira == receivedObject.je_sponzor_turnir.id_turnira))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
