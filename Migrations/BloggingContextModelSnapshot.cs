﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreWrongMigration.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("BaseReference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Something")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BaseReference");
                });

            modelBuilder.Entity("First.OtherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseReferenceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BaseReferenceId");

                    b.ToTable("OtherEntity", "first");
                });

            modelBuilder.Entity("Second.OtherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseReferenceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BaseReferenceId")
                        .HasDatabaseName("IX_OtherEntity_BaseReferenceId1");

                    b.ToTable("OtherEntity", "second");
                });

            modelBuilder.Entity("First.OtherEntity", b =>
                {
                    b.HasOne("BaseReference", "BaseReference")
                        .WithMany()
                        .HasForeignKey("BaseReferenceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseReference");
                });

            modelBuilder.Entity("Second.OtherEntity", b =>
                {
                    b.HasOne("BaseReference", "BaseReference")
                        .WithMany()
                        .HasForeignKey("BaseReferenceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseReference");
                });
#pragma warning restore 612, 618
        }
    }
}
