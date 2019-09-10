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
    public class OrganizatorController : ApiController
    {
        //GET: api/organizator
        public List<OrganizatorPregled> Get()
        {
            List<OrganizatorPregled> organizatori = DTOManager.getInfosOrganizator();
            return organizatori;
        }


        //GET: api/organizator/maticni_broj organizatora
        public OrganizatorPregled Get(int id)
        {
            OrganizatorPregled organizator = DTOManager.GetOrganizatorBasic(id);
            return organizator;
        }


        //POST: api/organizator
        public int Post(int id, [FromBody]Organizator organizator)
        {
            DTOManager manager = new DTOManager();
            return manager.DodajOrganizatora(organizator.ime, organizator.prezime, organizator.adresa, id);
        }


        //PUT: api/organizator/maticni_broj organizatora
        public OrganizatorPregled Put(int id, [FromBody]OrganizatorPregled st)
        {
            OrganizatorPregled organizator = DTOManager.UpdateOrganizatorPregled(st, id);
            return organizator;
        }


        //DELETE: api/sorganizator/maticni_broj organizatora
        public int Delete(int id)
        {
            DTOManager manager = new DTOManager();
            return manager.DeleteOrganizatora(id);
        }
    }
}
