using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DBContext
{
    internal class ManageVesselContext: DbContext
    {
        internal DbSet<Owner> Owners { get; set; }

        internal DbSet<Vessel> Vessels { get; set; }

        private readonly string _dbSource;

        private readonly string _nameDb;

        public ManageVesselContext()
        {
            _dbSource = "(localdb)\\quellochevuoi";
            _nameDb = "envDev";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server={_dbSource};Database={_nameDb};Trusted_Connection=True;ConnectRetryCount=0");
    }
}
