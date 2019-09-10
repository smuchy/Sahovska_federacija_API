using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sahovska_Federacija;
using Sahovska_Federacija.Entiteti;
using System.Net.Http;
using System.Web.Http;

namespace SF_API.Controllers
{
    public class HumanitarniController : ApiController
    {
        //GET: api/humanitarni
        public List<HumanitarniPregled> Get()
        {
            List<HumanitarniPregled> humanitarni = DTOManager.getInfosHumanitarni(1);
            return humanitarni;
        }

        //GET: api/humanitarni/id_turnira
        public HumanitarniPregled Get(int id)
        {
            HumanitarniPregled humanitarni = DTOManager.GetHumanitarniBasic(id);
            return humanitarni;
        }

        //POST: api/humanitarni
        public int Post([FromBody]Humanitarni bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajHumanitarni(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja,bp.kome_je_namenjen,bp.prikupljeni_iznos);
        }

        //PUT: api/humanitarni/id_turnira
        public HumanitarniPregled Put(int id, [FromBody]HumanitarniPregled bp)
        {
            HumanitarniPregled humanitarni = DTOManager.UpdateHumanitarni(bp, id);
            return humanitarni;
        }

        //DELETE: api/humanitarni/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteHumanitarni(id);
        }
    }
}
