using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GigManagement.GigManagement.Model
{
    public partial class GigManagementContext : DbContext
    {
        public GigManagementContext()
        {
        }

        public GigManagementContext(DbContextOptions<GigManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArtistDetail> ArtistDetails { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<Gig> Gigs { get; set; }
        public virtual DbSet<GigCalender> GigCalenders { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MAITRAYEE1;Initial Catalog=GigManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ArtistDetail>(entity =>
            {
                entity.HasKey(e => e.ArtistUsername)
                    .HasName("PK__artist_d__62F93B1EEC0ADDFC");

                entity.ToTable("artist_details");

                entity.Property(e => e.ArtistUsername)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("artist_username");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.Passwords)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("passwords");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.ArtistUsername })
                    .HasName("PK__followin__05F456C2A3B9C61A");

                entity.ToTable("following");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.ArtistUsername)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("artist_username");

                entity.HasOne(d => d.ArtistUsernameNavigation)
                    .WithMany(p => p.Followings)
                    .HasForeignKey(d => d.ArtistUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__following__artis__36B12243");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Followings)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__following__usern__35BCFE0A");
            });

            modelBuilder.Entity<Gig>(entity =>
            {
                entity.ToTable("gigs");

                entity.Property(e => e.GigId)
                    .ValueGeneratedNever()
                    .HasColumnName("gig_id");

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("artist_name");

                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.GigDate)
                    .HasColumnType("datetime")
                    .HasColumnName("gig_date");

                entity.Property(e => e.GigName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gig_name");

                entity.Property(e => e.IsCancelled)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("isCancelled")
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("venue");
            });

            modelBuilder.Entity<GigCalender>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gig_calender");

                entity.Property(e => e.GigId).HasColumnName("gig_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Gig)
                    .WithMany()
                    .HasForeignKey(d => d.GigId)
                    .HasConstraintName("FK__gig_calen__gig_i__2B3F6F97");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__gig_calen__usern__2A4B4B5E");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__user_det__F3DBC573D0EA0191");

                entity.ToTable("user_details");

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.Passwords)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("passwords");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
