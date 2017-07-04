using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PicAPI
{
    public class usapics_dbContext: DbContext
    {
        public usapics_dbContext(DbContextOptions<usapics_dbContext> options)
           : base(options)
        { }

        public DbSet<MetaImages> MetaImages { get; set; }
    }

    public class MetaImages
    {
        public string path { get; set; }
        public string id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public DateTime taken { get; set; }
        public string bucketname { get; set; }
        public string urlo { get; set; }
        public string urls { get; set; }
        public string urlm { get; set; }
        public string urll { get; set; }
        public string urlt { get; set; }
        public string urln { get; set; }
        public string urlx { get; set; }

    }
}
