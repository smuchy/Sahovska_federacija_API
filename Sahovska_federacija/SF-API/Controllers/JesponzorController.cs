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
    public class JesponzorController : ApiController
    {
        //POST: api/jesponzor
        public int Post([FromBody]Je_sponzorDTO je)
        {
            DTOManager manager = new DTOManager();
            return manager.PoveziSponzorTurnir(je);
        }
    }
}
