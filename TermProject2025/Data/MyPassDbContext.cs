using Microsoft.EntityFrameworkCore;
using TermProject2025.Models;

namespace TermProject2025.Data
{
    public class MyPassDbContext : DbContext
    {
        #region DbSets
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<SecurityQuestion> SecurityQuestions { get; set; } = null!;
        public DbSet<VaultItem> VaultItems { get; set; } = null!;

        #endregion

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // SQLite database file path
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mypass.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Salt).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();

                // One-to-many relationship with SecurityQuestions
                entity.HasMany(e => e.SecurityQuestions)
                      .WithOne(sq => sq.User)
                      .HasForeignKey(sq => sq.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                // One-to-many relationship with VaultItems
                entity.HasMany(e => e.VaultItems)
                      .WithOne(vi => vi.User)
                      .HasForeignKey(vi => vi.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure SecurityQuestion entity
            modelBuilder.Entity<SecurityQuestion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Question).IsRequired().HasMaxLength(500);
                entity.Property(e => e.AnswerHash).IsRequired();
                entity.Property(e => e.QuestionNumber).IsRequired();
            });

            // Configure VaultItem entity (base class)
            modelBuilder.Entity<VaultItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EncryptedData).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();

                // Table Per Hierarchy (TPH) inheritance strategy
                entity.HasDiscriminator<string>("Type")
                      .HasValue<LoginItem>("Login")
                      .HasValue<CreditCardItem>("CreditCard")
                      .HasValue<IdentityItem>("Identity")
                      .HasValue<SecureNoteItem>("SecureNote");
            });

            // Configure LoginItem
            modelBuilder.Entity<LoginItem>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Username).HasMaxLength(255);
                entity.Property(e => e.Url).HasMaxLength(1000);
            });

            // Configure CreditCardItem
            modelBuilder.Entity<CreditCardItem>(entity =>
            {
                entity.Property(e => e.CardholderName).HasMaxLength(255);
                entity.Property(e => e.BillingAddress).HasMaxLength(500);
            });

            // Configure IdentityItem
            modelBuilder.Entity<IdentityItem>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(500);
            });

            // Configure SecureNoteItem
            modelBuilder.Entity<SecureNoteItem>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(255);
            });
        }

        #endregion
    }
}
