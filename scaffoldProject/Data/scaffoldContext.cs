using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using scaffoldProject.Data.Models;

namespace scaffoldProject.Data
{
    public partial class scaffoldContext : DbContext
    {
        public scaffoldContext()
        {
        }

        public scaffoldContext(DbContextOptions<scaffoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LOBPVV2;Initial Catalog=scaffold;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__books__author_id__3B75D760");

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookGenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__book_genr__genre__412EB0B6"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__book_genr__book___403A8C7D"),
                        j =>
                        {
                            j.HasKey("BookId", "GenreId").HasName("PK__book_gen__78893235DA906777");

                            j.ToTable("book_genres");

                            j.IndexerProperty<int>("BookId").HasColumnName("book_id");

                            j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                        });
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PK__book_det__38E9A22494EFA300");

                entity.ToTable("book_details");

                entity.HasIndex(e => e.BookId, "UQ__book_det__490D1AE0AEB05717")
                    .IsUnique();

                entity.Property(e => e.DetailId).HasColumnName("detail_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.PublicationYear).HasColumnName("publication_year");

                entity.Property(e => e.Summary)
                    .HasColumnType("text")
                    .HasColumnName("summary");

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.BookDetail)
                    .HasForeignKey<BookDetail>(d => d.BookId)
                    .HasConstraintName("FK__book_deta__book___44FF419A");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("genre_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
