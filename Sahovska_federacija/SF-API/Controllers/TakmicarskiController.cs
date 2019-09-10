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
    public class TakmicarskiController : ApiController
    {

        //GET: api/takmicarski
        public List<TakmicarskiPregled> Get()
        {
            List<TakmicarskiPregled> takmicarski = DTOManager.getInfosTakmicarski(1);
            return takmicarski;
        }


        //GET: api/takmicarski/id_turnira
        public TakmicarskiPregled Get(int id)
        {
            TakmicarskiPregled takmicarski = DTOManager.GetTakmicarskiBasic(id);
            return takmicarski;
        }

        //POST: api/takmicarski
        public int Post([FromBody]Takmicarski bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajTakmicarski(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja,bp.internacionalni,bp.regionalni,bp.nacionalni);
        }

        //PUT: api/takmicarski/id_turnira
        public TakmicarskiPregled Put(int id, [FromBody]TakmicarskiPregled bp)
        {
            TakmicarskiPregled takmicarski = DTOManager.UpdateTakmicarski(bp, id);
            return takmicarski;
        }

        //DELETE: api/takmicarski/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteTakmicarski(id);
        }
    }
}
