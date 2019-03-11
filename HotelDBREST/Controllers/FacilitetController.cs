using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBREST.DBUtil;
using ModelLib.model;

namespace HotelDBREST.Controllers
{
    public class FacilitetController : ApiController
    {
        private static ManageFacilitet fmgr = new ManageFacilitet();
        // GET: api/Facilitet
        public IEnumerable<Facilitet> Get()
        {
            return fmgr.Get();
        }

        // GET: api/Facilitet/5
        public Facilitet Get(int id)
        {
            return fmgr.Get(id);
        }

        // POST: api/Facilitet
        public void Post([FromBody]Facilitet value)
        {
            fmgr.Post(value);
        }

        // PUT: api/Facilitet/5
        public void Put(int id, [FromBody]Facilitet value)
        {
            fmgr.Put(id, value);
        }

        // DELETE: api/Facilitet/5
        public void Delete(int id)
        {
            fmgr.Delete(id);
        }
    }
}
