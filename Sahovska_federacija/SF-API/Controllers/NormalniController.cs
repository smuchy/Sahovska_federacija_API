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
    public class NormalniController : ApiController
    {
        //GET: api/normalni
        public List<NormalniPregled> Get()
        {
            List<NormalniPregled> normalni = DTOManager.getInfosNormalni(1);
            return normalni;
        }


        //GET: api/normalni/id_turnira
        public NormalniPregled Get(int id)
        {
            NormalniPregled normalni = DTOManager.GetNormalniBasic(id);
            return normalni;
        }

        //POST: api/normalni
        public int Post([FromBody]Normalni bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajNormalni(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja);
        }

        //PUT: api/normalni/id_turnira
        public NormalniPregled Put(int id, [FromBody]NormalniPregled bp)
        {
            NormalniPregled normalni = DTOManager.UpdateNormalni(bp, id);
            return normalni;
        }

        //DELETE: api/normalni/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteNormalni(id);
        }
    }
}
