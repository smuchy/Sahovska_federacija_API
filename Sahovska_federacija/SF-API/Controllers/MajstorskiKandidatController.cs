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
    public class MajstorskiKandidatController : ApiController
    {
        //GET: api/majstorskikandidat
        public List<MajstorskiKandidatPregled> Get()
        {
            List<MajstorskiKandidatPregled> kandidat = DTOManager.getInfosMajstorskiKandidat();
            return kandidat;
        }

        //GET: api/majstorskikandidat/registracioni_broj sahiste
        public MajstorskiKandidatPregled Get(int id)
        {
            MajstorskiKandidatPregled kandidat = DTOManager.GetMajstorskiKandidatBasic(id);
            return kandidat;
        }

        //POST: api/majstor
        public int Post([FromBody]Majstorski_kandidat kandidat)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajMajstorskiKandidat(kandidat.br_pasosa, kandidat.ime, kandidat.prezime, kandidat.ulica, kandidat.broj, kandidat.datum_rodjenja, kandidat.zemlja_porekla, kandidat.br_odigranih_partija, kandidat.br_partija_do_zvanja);
        }

        //PUT: api/majstorskikandidat/registracioni_broj sahiste
        public MajstorskiKandidatPregled Put(int id, [FromBody]MajstorskiKandidatPregled st)
        {
            MajstorskiKandidatPregled kandidat = DTOManager.UpdateMajstorskiKandidatPregled(st, id);
            return kandidat;
        }

        //DELETE: api/majstorskikandidat/registracioni_broj sahiste
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteMajstorskiKandidat(id);
        }
    }
}
