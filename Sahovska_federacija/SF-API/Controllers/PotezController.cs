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
    public class PotezController : ApiController
    {
        //GET: api/potez
        public List<PotezPregled> Get()
        {
            List<PotezPregled> potezi = DTOManager.getInfosPotez();
            return potezi;
        }

        //GET: api/potez/id_poteza
        public PotezPregled Get(int id)
        {
            PotezPregled potez = DTOManager.GetPotezBasic(id);
            return potez;
        }

        //POST: api/potez/id_partije
        public int Post(int id, [FromBody]Potez bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajPotez(bp.opis, bp.kad_odigran, id);
        }

        //PUT: api/potez/id_potez
        public PotezPregled Put(int id, [FromBody]PotezPregled bp)
        {
            PotezPregled potez = DTOManager.UpdatePotezPregled(bp, id);
            return potez;
        }

        //DELETE: api/potez/id_poteza
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeletePotez(id);
        }
    }
}
