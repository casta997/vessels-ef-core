using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DBContext
{
    public class ManageVesselContext: DbContext
    {
        internal DbSet<Owner> Owners { get; set; }

        internal DbSet<Vessel> Vessels { get; set; }

        public ManageVesselContext(DbContextOptions<ManageVesselContext> options)
        : base(options)
        {
        }
    }
}
