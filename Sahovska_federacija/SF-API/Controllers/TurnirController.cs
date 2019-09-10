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
    public class TurnirController : ApiController
    {
        //GET: api/turnir
        public List<TurnirPregled> Get()
        {
            List<TurnirPregled> turniri = DTOManager.getInfos(1);
            return turniri;
        }
        //GET: api/turnir/id_turnira
        public TurnirBasic Get(int id)
        {
            TurnirBasic turnir = DTOManager.GetTurnirBasic(id);
            return turnir;
        }

        //POST: api/turnir
        public int Post([FromBody]Sahovski_turnir turnir)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajTurnir(turnir.naziv, turnir.zemlja, turnir.grad, turnir.god_odrzavanja, turnir.tip);
        }

        //PUT: api/turnir/id_turnira
        public TurnirBasic Put(int id, [FromBody]TurnirBasic st)
        {
            TurnirBasic turnir = DTOManager.UpdateTurnirBasic(st, id);
            return turnir;
        }

        //DELETE: api/turnir/id_turnira
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteTurnir(id);
        }
    }
}
