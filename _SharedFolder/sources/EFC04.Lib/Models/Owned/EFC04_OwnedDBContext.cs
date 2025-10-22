using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EFC04.Lib.Models.Owned;

public partial class EFC04_SingleDBContext : DbContext
{
    public EFC04_SingleDBContext()
    {
    }

    public EFC04_SingleDBContext(DbContextOptions<EFC04_SingleDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kunde> KundeListe { get;set; }
    public virtual DbSet<Adresse> AdresseListe { get;set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer("data source=SQL-SRV0;initial catalog=EFC01;Integrated Security=true;TrustServerCertificate=Yes;Encrypt=False;");
        IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

        var connectionString = config.GetConnectionString("DBConnectionString");
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OwnedTypeMapping(modelBuilder);
    }

    private void OwnedTypeMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kunde>()
            .OwnsOne(p => p.Kundedetails);

        modelBuilder.Entity<Kunde>()
               .Navigation(p => p.Kundedetails)
               .IsRequired();
    }
}
