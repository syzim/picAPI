using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PicAPI.Controllers
{
    [Route("api/[controller]")]
    public class PicController : Controller
    {
        private usapics_dbContext _db;

        public PicController(usapics_dbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
       

        // GET api/values/5
        [HttpGet("{swlat}/{swlong}/{nelat}/{nelong}")]
        public ActionResult Get(double swlat, double swlong, double nelat, double nelong)
        {
          
         var b = from p in _db.MetaImages
                 where p.lat > swlat &&
                       p.lng > swlong &&
                       p.lat < nelat &&
                       p.lng < nelong
                       select p;

             return Ok(b.ToList());
        }
       
    }
}
