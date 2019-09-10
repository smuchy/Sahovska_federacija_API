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
    public class MajstorController : ApiController
    {
        //GET: api/majstor
        public List<MajstorPregled> Get()
        {
            List<MajstorPregled> majstor = DTOManager.getInfosMajstor();
            return majstor;
        }

        //GET: api/majstor/registracioni_broj sahiste
        public MajstorPregled Get(int id)
        {
            MajstorPregled majstor = DTOManager.GetMajstorBasic(id);
            return majstor;
        }

        //POST: api/majstor
        public int Post([FromBody]Majstor majstor)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajMajstor(majstor.br_pasosa, majstor.ime, majstor.prezime, majstor.ulica, majstor.broj, majstor.datum_rodjenja, majstor.zemlja_porekla, majstor.datum_sticanja_zvanja);
        }

        //PUT: api/majstor/registracioni_broj sahiste
        public MajstorPregled Put(int id, [FromBody]MajstorPregled st)
        {
            MajstorPregled majstor = DTOManager.UpdateMajstorPregled(st, id);
            return majstor;
        }

        //DELETE: api/majstor/registracioni_broj sahiste
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteMajstor(id);
        }
    }
}
