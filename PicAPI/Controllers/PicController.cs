using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Http;

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

        [HttpGet("{swlat}/{swlong}/{nelat}/{nelong}")]
        public ActionResult Get(double swlat, double swlong, double nelat, double nelong)
        {

            if(invalid(swlat) || invalid(swlong) || invalid(nelat) || invalid(nelong)){
                return BadRequest(new { message = "please provide all valid GPS co-ordinates" });
            }


            var b = from p in _db.MetaImages
                 where p.lat > swlat &&
                       p.lng > swlong &&
                       p.lat < nelat &&
                       p.lng < nelong
                       select new { p.id, p.urlt, p.urll, p.urls, p.lat, p.lng };

 

             return Ok(b.ToList());
        }

        private bool invalid(double x)
        {
            if (x == 0)
            {
                return true;
            }
            return false;
        }

        
       
    }
}
