using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;

namespace EFfromExistingDb.Models
{
    public partial class r5logContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Server=.;Database=r5log;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbEvent>(entity =>
            {
                entity.HasKey(e => new { e.idEvent, e.dLogged });

                entity.HasIndex(e => e.dLogged).HasName("xtEvent_dLogged");

                entity.HasIndex(e => new { e.dLogged, e.dtLogged }).HasName("xtEvent_dtLogged");

                entity.HasIndex(e => new { e.dLogged, e.idLevel }).HasName("xtEvent_idLevel");

                entity.HasIndex(e => new { e.dLogged, e.idMachine }).HasName("xtEvent_idMachine");

                entity.HasIndex(e => new { e.dLogged, e.idOrigin }).HasName("xtEvent_idOrigin");

                entity.HasIndex(e => new { e.dLogged, e.idUserAcct }).HasName("xtEvent_idUserAcct");

                entity.Property(e => e.idEvent).ValueGeneratedOnAdd();

                entity.Property(e => e.dLogged)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("CONVERT([varchar](10),getdate(),(120))");

                entity.Property(e => e.dtLocal).HasColumnType("datetime");

                entity.Property(e => e.dtLogged)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.dtLoggedUtc)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.idMessageTag).HasDefaultValue(0);

                entity.Property(e => e.sIpAddr)
                    .IsRequired()
                    .HasMaxLength(48)
                    .HasColumnType("varchar");

                entity.Property(e => e.sMessage)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.sProcess)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");

                entity.Property(e => e.sSource)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");

                entity.Property(e => e.sThread)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tbMachine>(entity =>
            {
                entity.HasKey(e => e.idMachine);

                entity.HasIndex(e => e.sMachine).HasName("xuMachine_sMachine").IsUnique();

                entity.Property(e => e.sMachine)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tbMessageCount>(entity =>
            {
                entity.HasKey(e => e.idMessageCount);

                entity.Property(e => e.dLogged).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<tbMessageTag>(entity =>
            {
                entity.HasKey(e => e.idMessageTag);

                entity.HasIndex(e => e.sMessageTag).HasName("IX_tbMessageTag").IsUnique();

                entity.Property(e => e.sMessageTag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tbStatsByTime>(entity =>
            {
                entity.HasKey(e => new { e.dLogged, e.tiHH, e.tiNN });

                entity.Property(e => e.dLogged).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<tbUserAcct>(entity =>
            {
                entity.HasKey(e => e.idUserAcct);

                entity.HasIndex(e => e.sUserAcct).HasName("xuUserAccount_sUserAcct").IsUnique();

                entity.Property(e => e.sUserAcct)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tb_Level>(entity =>
            {
                entity.HasKey(e => e.idLevel);

                entity.HasIndex(e => e.sLevel).HasName("xuLevel_sLevel").IsUnique();

                entity.Property(e => e.idLevel).ValueGeneratedNever();

                entity.Property(e => e.mLevel)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");

                entity.Property(e => e.sLevel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tb_Origin>(entity =>
            {
                entity.HasKey(e => e.idOrigin);

                entity.HasIndex(e => e.sOrigin).HasName("xuOrigin_sOrigin").IsUnique();

                entity.Property(e => e.mOrigin)
                    .HasMaxLength(255)
                    .HasColumnType("varchar");

                entity.Property(e => e.sOrigin)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<tb_Version>(entity =>
            {
                entity.HasKey(e => e.idVersion);

                entity.Property(e => e.idVersion).ValueGeneratedNever();

                entity.Property(e => e.DbTag)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnType("nchar")
                    .HasDefaultValue("R5Log");

                entity.Property(e => e.dtCreated).HasColumnType("smalldatetime");

                entity.Property(e => e.dtInstalled).HasColumnType("smalldatetime");

                entity.Property(e => e.sVersion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("varchar");
            });
        }

        public virtual DbSet<tbEvent> tbEvent { get; set; }
        public virtual DbSet<tbMachine> tbMachine { get; set; }
        public virtual DbSet<tbMessageCount> tbMessageCount { get; set; }
        public virtual DbSet<tbMessageTag> tbMessageTag { get; set; }
        public virtual DbSet<tbStatsByTime> tbStatsByTime { get; set; }
        public virtual DbSet<tbUserAcct> tbUserAcct { get; set; }
        public virtual DbSet<tb_Level> tb_Level { get; set; }
        public virtual DbSet<tb_Origin> tb_Origin { get; set; }
        public virtual DbSet<tb_Version> tb_Version { get; set; }

        public IEnumerable<tbEvent> FindEvents(int searchTerm)
        {
            return this.tbEvent.FromSql("dbo.GetEvents @level = {0}", searchTerm);
        }

    }
}