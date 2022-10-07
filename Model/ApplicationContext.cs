namespace SendMessageEmail.Model
{
    public class ApplicationContext: DbContext
    {
        public DbSet<MailMessage> Mail { get; set; } = null!;
        public DbSet<MessageStatus> Status { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Создание связи один ко многим
            modelBuilder.Entity<MailMessage>()
                .HasOne(m => m.MessageStatus)
                .WithMany(s => s.MailMessage)
                .HasForeignKey(m => m.MessageStatusId);
        }
    }
}
