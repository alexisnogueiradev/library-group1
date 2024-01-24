﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryInfrastructure.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("PersonSequence");

            modelBuilder.Entity("Library.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Appartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DomainId")
                        .HasColumnType("int");

                    b.Property<int>("PagesNumber")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("WriterId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Entities.Domain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Romans francophones.",
                            Name = "Littérature française"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Apprendre à utiliser les Outils Bureautique, à créer un site Web, à programmer ou à comprendre le Bitcoin.",
                            Name = "Informatique"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Genre policier qui se distinguent par la mise en scène d’une énigme policière.",
                            Name = "Polar"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Relate des événements totalement étranges, le plus souvent irrationnels ou incompréhensibles par l'humain.",
                            Name = "Fantastique"
                        });
                });

            modelBuilder.Entity("Library.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReaderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [PersonSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Library.Entities.Admin", b =>
                {
                    b.HasBaseType("Library.Entities.Person");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Library.Entities.Reader", b =>
                {
                    b.HasBaseType("Library.Entities.Person");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AddressId");

                    b.ToTable("Readers", (string)null);
                });

            modelBuilder.Entity("Library.Entities.Writer", b =>
                {
                    b.HasBaseType("Library.Entities.Person");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Writers", (string)null);
                });

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.HasOne("Library.Entities.Domain", "Domain")
                        .WithMany("Books")
                        .HasForeignKey("DomainId");

                    b.HasOne("Library.Entities.Writer", "Writer")
                        .WithMany("Books")
                        .HasForeignKey("WriterId");

                    b.Navigation("Domain");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Library.Entities.Loan", b =>
                {
                    b.HasOne("Library.Entities.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId");

                    b.HasOne("Library.Entities.Reader", "Reader")
                        .WithMany("Loans")
                        .HasForeignKey("ReaderId");

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Library.Entities.Reader", b =>
                {
                    b.HasOne("Library.Entities.Address", "Address")
                        .WithMany("Readers")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Library.Entities.Address", b =>
                {
                    b.Navigation("Readers");
                });

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Library.Entities.Domain", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Entities.Reader", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Library.Entities.Writer", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
