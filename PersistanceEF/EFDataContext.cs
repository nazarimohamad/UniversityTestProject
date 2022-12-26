using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PersistanceEF
{
    public class EFDataContext : DbContext
    {

        public EFDataContext(string connectionString = "Server=localhost,1433\\Catalog=University;Database=University;User=sa;Password=123456a@;TrustServerCertificate=True;")
            : this(new DbContextOptionsBuilder<EFDataContext>()
        .UseSqlServer(connectionString)
        .Options)
        { }

        private EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }

        //public EFDataContext()
        //: base("name=MyAppContext")
        //{
        //    //this.Configuration.LazyLoadingEnabled = false;
        //}

        //public EFDataContext(DbConnection connection): base(connection)
        //{
        //    //this.Configuration.LazyLoadingEnabled = false;
        //}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.LazyLoadingEnabled = false;
                tracker.AutoDetectChangesEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                return tracker;
            }
        }
    }
}

