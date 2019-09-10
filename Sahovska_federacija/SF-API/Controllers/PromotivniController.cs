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
    public class PromotivniController : ApiController
    {


        //GET: api/promotivni
        public List<PromotivniPregled> Get()
        {
            List<PromotivniPregled> promotivni = DTOManager.getInfosPromotivni(1);
            return promotivni;
        }


        //GET: api/promotivni/id_turnira
        public PromotivniPregled Get(int id)
        {
            PromotivniPregled promotivni = DTOManager.GetPromotivniBasic(id);
            return promotivni;
        }

        //POST: api/promotivni
        public int Post([FromBody]Promotivni bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajPromotivni(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja);
        }

        //PUT: api/promotivni/id_turnira
        public PromotivniPregled Put(int id, [FromBody]PromotivniPregled bp)
        {
            PromotivniPregled promotivni = DTOManager.UpdatePromotivni(bp, id);
            return promotivni;
        }

        //DELETE: api/promotivni/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeletePromotivni(id);
        }
    }
}
