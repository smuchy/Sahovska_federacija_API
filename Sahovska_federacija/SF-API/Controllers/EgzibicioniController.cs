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
    public class EgzibicioniController : ApiController
    {

        //GET: api/egzibicioni
        public List<EgzibicioniPregled> Get()
        {
            List<EgzibicioniPregled> egzibicioni= DTOManager.getInfosEgzibicioni(1);
            return egzibicioni;
        }


        //GET: api/egzibicioni/id_turnira
        public EgzibicioniPregled Get(int id)
        {
            EgzibicioniPregled egzibicioni = DTOManager.GetEgzibicioniBasic(id);
            return egzibicioni;
        }


        //POST: api/egzibicioni
        public int Post([FromBody]Egzibicioni bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajEgzibicioni(bp.naziv, bp.zemlja, bp.grad, bp.god_odrzavanja);
        }


        //PUT: api/egzibicioni/id_turnira
        public EgzibicioniPregled Put(int id, [FromBody]EgzibicioniPregled bp)
        {
            EgzibicioniPregled egzibicioni = DTOManager.UpdateEgzibicioni(bp, id);
            return egzibicioni;
        }

        //DELETE: api/egzibicioni/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteEgzibicioni(id);
        }
    }
}
