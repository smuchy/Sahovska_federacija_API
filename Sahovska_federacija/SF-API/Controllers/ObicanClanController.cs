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
    public class ObicanClanController : ApiController
    {
        //GET: api/obicanclan
        public List<ObicanClanPregled> Get()
        {
            List<ObicanClanPregled> obican = DTOManager.getInfosObicanClan();
            return obican;
        }


        //GET: api/obicanclan/registracioni_broj sahiste
        public ObicanClanPregled Get(int id)
        {
            ObicanClanPregled obican = DTOManager.GetObicanClanBasic(id);
            return obican;
        }

        //POST: api/obicanclan
        public int Post([FromBody]Obican_clan obican)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajObicanClan(obican.br_pasosa, obican.ime, obican.prezime, obican.ulica, obican.broj, obican.datum_rodjenja, obican.zemlja_porekla);
        }

        //PUT: api/obicanclan/registracioni_broj sahiste
        public ObicanClanPregled Put(int id, [FromBody]ObicanClanPregled st)
        {
            ObicanClanPregled obican = DTOManager.UpdateObicanClanPregled(st, id);
            return obican;
        }

        //DELETE: api/obicanclan/registracioni_broj sahiste
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteObicanClan(id);
        }
    }
}
