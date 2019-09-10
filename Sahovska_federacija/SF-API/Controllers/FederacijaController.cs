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
    public class FederacijaController : ApiController
    {

        //GET: api/federacija
        public List<FederacijaPregled> Get()
        {
            List<FederacijaPregled> federacija = DTOManager.getInfosFederacija();
            return federacija;
        }

        //GET: api/federacija/registracioni_broj federacije
        public FederacijaPregled Get(int id)
        {
            FederacijaPregled federacija = DTOManager.GetFederacijaBasic(id);
            return federacija;
        }

        //POST: api/federacija
        public int Post([FromBody]Federacija bp)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajFederaciju(bp.lokacija);
        }

        //PUT: api/federacija/registracioni_broj federacije
        public FederacijaPregled Put(int id, [FromBody]FederacijaPregled bp)
        {
            FederacijaPregled federacija = DTOManager.UpdateFederaciju(bp, id);
            return federacija;
        }

    }
}
