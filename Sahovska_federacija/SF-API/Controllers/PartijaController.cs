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
    public class PartijaController : ApiController
    {
        //GET: api/partija
        public List<PartijaPregled> Get()
        {
            List<PartijaPregled> partije = DTOManager.getInfosPartija();
            return partije;
        }

        //GET: api/partija/id_partije
        public PartijaPregled Get(int id)
        {
            PartijaPregled partije = DTOManager.GetPartijaBasic(id);
            return partije;
        }

        //POST: api/partija/id_turnira
        public int Post(int id, [FromBody]Partija bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajPartija(bp.bele, bp.crne, bp.kad_se_igra, bp.trajanje, bp.pat, bp.mat, bp.rem, id);
        }

        //PUT: api/partija/id_partije
        public PartijaPregled Put(int id, [FromBody]PartijaPregled bp)
        {
            PartijaPregled partija = DTOManager.UpdatePartijaPregled(bp, id);
            return partija;
        }

        //DELETE: api/partija/id_partije
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeletePartija(id);
        }
    }
}
