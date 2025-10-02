using Package.Infrustructure.Persistence.Constants;

namespace Package.Infrustructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region DbSets
        public DbSet<Subscription> Subscriptions { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Overriding Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(EntitySchema.BASE);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            #region Seed Data
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription
                {
                    Id = 1,
                    UserId = 1,
                    Plan = "enterprise",
                    MaxItems = 10,
                },
                new Subscription
                {
                    Id = 2,
                    UserId = 2,
                    Plan = "pro",
                    MaxItems = 5,
                },
                new Subscription
                {
                    Id = 3,
                    UserId = 3,
                    Plan = "enterprise",
                    MaxItems = 12,
                },
                new Subscription
                {
                    Id = 4,
                    UserId = 4,
                    Plan = "free",
                    MaxItems = 4,
                },
                new Subscription
                {
                    Id = 5,
                    UserId = 5,
                    Plan = "pro",
                    MaxItems = 20,
                }
            );
            #endregion
        }
        #endregion

        #region Custom Funcs
        [DbFunction("CompareRowVersions", Schema = "dbo")]
        public static int CompareRowVersions(byte[] a, byte[] b)
        {
            throw new NotSupportedException("This method is for LINQ translation only.");
        }
        #endregion
    }
}
