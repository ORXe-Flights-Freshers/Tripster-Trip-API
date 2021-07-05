using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tavisca.Tripster.Data.Models;

namespace Tavisca.Tripster.Web.Models
{
    public class TaviscaTripsterWebContext : DbContext
    {
        public TaviscaTripsterWebContext (DbContextOptions<TaviscaTripsterWebContext> options)
            : base(options)
        {
        }

        public DbSet<Tavisca.Tripster.Data.Models.User> User { get; set; }
    }
}
