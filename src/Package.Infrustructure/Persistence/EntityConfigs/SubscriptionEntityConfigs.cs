namespace Package.Infrustructure.Persistence.EntityConfigs
{
    public class SubscriptionEntityConfigs : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.UserId)
                .IsRequired();

            builder.Property(s => s.Plan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.MaxItems)
                .IsRequired();

            builder.Property(s => s.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.HasIndex(s => s.UserId)
                   .IsUnique();
        }
    }
}
