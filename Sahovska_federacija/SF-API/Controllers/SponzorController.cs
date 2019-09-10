using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sahovska_Federacija.Entiteti;
using NHibernate;
using NHibernate.Linq;
using Sahovska_Federacija;
using System.Web.Http;


namespace SF_API.Controllers
{
    public class SponzorController : ApiController
    {
        //GET: api/sponzor
        public List<SponzorPregled> Get()
        {
            List<SponzorPregled> sponzori = DTOManager.getInfosSponzor();
            return sponzori;
        }


        //GET: api/sponzor/registracioni_broj sponzora
        public SponzorPregled Get(int id)
        {
            SponzorPregled sponzor = DTOManager.GetSponzorBasic(id);
            return sponzor;
        }


        //POST: api/sponzor
        public int Post([FromBody]Sponzor sponzor)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajSponzora(sponzor.ime, sponzor.opis, sponzor.logo);
        }

        //PUT: api/sponzor/registracioni_broj sponzora
        public SponzorPregled Put(int id, [FromBody]SponzorPregled st)
        {
            SponzorPregled sponzor = DTOManager.UpdateSponzorPregled(st, id);
            return sponzor;
        }


        //DELETE: api/sponzor/registracioni_broj sponzora
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteSponzora(id);
        }
    }
}
