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
    public class BrzopotezniController : ApiController
    {
        //GET: api/brzopotezni
        public List<BrzopotezniPregled> Get()
        {
            List<BrzopotezniPregled> brzopotezni = DTOManager.getInfosBrzopotezni(1);
            return brzopotezni;
        }

        //GET: api/brzopotezni/id_turnira
        public BrzopotezniPregled Get(int id)
        {
            BrzopotezniPregled brzopotezni = DTOManager.GetBrzopotezniBasic(id);
            return brzopotezni;
        }

        //POST: api/brzopotezni
        public int Post([FromBody]Brzopotezni bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajBrzopotezni(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja, bp.max_vreme_trajanja_partija);
        }

        //PUT: api/brzopotezni/id_turnira
        public BrzopotezniPregled Put(int id, [FromBody]BrzopotezniPregled bp)
        {
            BrzopotezniPregled brzopotezni = DTOManager.UpdateBrzopotezni(bp, id);
            return brzopotezni;
        }

        //DELETE: api/brzopotezni/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteBrzopotezni(id);
        }
    }
}
