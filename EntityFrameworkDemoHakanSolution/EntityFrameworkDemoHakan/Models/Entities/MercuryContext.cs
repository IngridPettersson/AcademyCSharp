using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFrameworkDemoHakan.Models.Entities
{
    public partial class MercuryContext : DbContext
    {
        public MercuryContext()
        {
        }

        public MercuryContext(DbContextOptions<MercuryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressBook> AddressBooks { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<HistoricalPrice> HistoricalPrices { get; set; }
        public virtual DbSet<P2a> P2as { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<WhereMagicHappen> WhereMagicHappens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => new { e.Street, e.City, e.ZipCode }, "UQ__Addresse__8F22AFF074C05809")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AddressBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AddressBook");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Gata)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Kontaktinfo)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Kontakttyp)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Personnummer)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Postnummer)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Stad)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasIndex(e => e.ContactInfo, "UQ__ContactD__41ABC0B8D868FBBF")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactInfo)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ContactType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.ContactDetails)
                    .HasForeignKey(d => d.PersonsId)
                    .HasConstraintName("FK__ContactDe__Perso__4D94879B");
            });

            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.HasIndex(e => new { e.FruitType, e.FruitName }, "UQ__Fruits__FE7D1CBDDBDE78B7")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FruitName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FruitType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerKg).HasColumnType("money");
            });

            modelBuilder.Entity<HistoricalPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.NewPrice).HasColumnType("money");

                entity.Property(e => e.OldPrice).HasColumnType("money");

                entity.Property(e => e.ProductsId).HasColumnName("ProductsID");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.HistoricalPrices)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historica__Produ__76969D2E");
            });

            modelBuilder.Entity<P2a>(entity =>
            {
                entity.ToTable("P2A");

                entity.HasIndex(e => new { e.PersonsId, e.AddressesId }, "UQ__P2A__215206A32792965E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressesId).HasColumnName("AddressesID");

                entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.AddressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__AddressesID__5EBF139D");

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.PersonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__PersonsID__5DCAEF64");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.Personnr, "UQ__Persons__AA2D17261E2E912B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Personnr)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ChefsId).HasColumnName("ChefsID");

                entity.Property(e => e.Lön).HasColumnType("money");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Chefs)
                    .WithMany(p => p.InverseChefs)
                    .HasForeignKey(d => d.ChefsId)
                    .HasConstraintName("FK__Personal__ChefsI__45F365D3");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WhereMagicHappen>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Where magic happens");

                entity.Property(e => e.MagicNumber).HasColumnName("Magic Number");

                entity.Property(e => e.MagicWords)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Magic Words");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
