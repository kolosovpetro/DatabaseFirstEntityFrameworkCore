using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseFirst.SqlServer.SqlServerScaffold
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Copy> Copies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Starring> Starrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P87PH2B;Initial Catalog=CodeFirstEntityFramework;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actors");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copies");

                entity.HasIndex(e => e.MovieId, "IX_copies_movie_id");

                entity.Property(e => e.CopyId).HasColumnName("copy_id");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Copies)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.AgeRestriction).HasColumnName("age_restriction");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.CopyId })
                    .HasName("rentals_pkey");

                entity.ToTable("rentals");

                entity.HasIndex(e => e.CopyId, "IX_rentals_copy_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CopyId).HasColumnName("copy_id");

                entity.Property(e => e.DateOfRental).HasColumnName("date_of_rental");

                entity.Property(e => e.DateOfReturn).HasColumnName("date_of_return");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.CopyId);
            });

            modelBuilder.Entity<Starring>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.MovieId });

                entity.ToTable("starring");

                entity.HasIndex(e => e.MovieId, "IX_starring_movie_id");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Starrings)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Starrings)
                    .HasForeignKey(d => d.MovieId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
