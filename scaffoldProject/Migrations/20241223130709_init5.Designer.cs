﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using scaffoldProject.Data;

#nullable disable

namespace scaffoldProject.Migrations
{
    [DbContext(typeof(scaffoldContext))]
    [Migration("20241223130709_init5")]
    partial class init5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.HasKey("BookId", "GenreId")
                        .HasName("PK__book_gen__78893235DA906777");

                    b.HasIndex("GenreId");

                    b.ToTable("book_genres", (string)null);
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.HasKey("AuthorId");

                    b.ToTable("authors", (string)null);
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.BookDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int?>("PublicationYear")
                        .HasColumnType("int")
                        .HasColumnName("publication_year");

                    b.Property<string>("Summary")
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.HasKey("DetailId")
                        .HasName("PK__book_det__38E9A22494EFA300");

                    b.HasIndex(new[] { "BookId" }, "UQ__book_det__490D1AE0AEB05717")
                        .IsUnique()
                        .HasFilter("[book_id] IS NOT NULL");

                    b.ToTable("book_details", (string)null);
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("GenreName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("genre_name");

                    b.HasKey("GenreId");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("scaffoldProject.Data.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__book_genr__book___403A8C7D");

                    b.HasOne("scaffoldProject.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK__book_genr__genre__412EB0B6");
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Book", b =>
                {
                    b.HasOne("scaffoldProject.Data.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK__books__author_id__3B75D760");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.BookDetail", b =>
                {
                    b.HasOne("scaffoldProject.Data.Models.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("scaffoldProject.Data.Models.BookDetail", "BookId")
                        .HasConstraintName("FK__book_deta__book___44FF419A");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("scaffoldProject.Data.Models.Book", b =>
                {
                    b.Navigation("BookDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
