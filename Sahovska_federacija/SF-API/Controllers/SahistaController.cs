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
    public class SahistaController : ApiController
    {
        //GET: api/sahista
        public List<SahistaPregled> Get()
        {
            List<SahistaPregled> sahisti = DTOManager.getInfosSahista(1);
            return sahisti;
        }

        //GET: api/sahista/registracioni_broj sahiste
        public SahistaPregled Get(int id)
        {
            SahistaPregled sahista = DTOManager.GetSahistaBasic(id);
            return sahista;
        }


        //DELETE: api/sahista/registracioni_broj sahiste
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteSahistu(id);
        }
    }
}
