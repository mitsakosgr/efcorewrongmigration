using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BloggingContext : DbContext
{
    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<First.OtherEntity>()
            .ToTable("OtherEntity", "first")
            .HasOne(i => i.BaseReference)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Second.OtherEntity>()
            .ToTable("OtherEntity", "second")
            .HasOne(i => i.BaseReference)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class BaseReference
{
    [Key]
    public int Id { get; set; }

    public string Something { get; set; } = "";
}

namespace First
{
    public class OtherEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BaseReference))]
        public int BaseReferenceId { get; set; }
        public virtual BaseReference? BaseReference { get; set; }
    }
}

namespace Second
{
    public class OtherEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(BaseReference))]
        public int BaseReferenceId { get; set; }
        public virtual BaseReference? BaseReference { get; set; }
    }
}