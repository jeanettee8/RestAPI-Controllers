using System;
using Microsoft.EntityFrameworkCore;
using RestAPI_Controllers.Models;

namespace RestAPI_Controllers.DatabaseContext;

public class CatDatabaseContext : DbContext
{
    public DbSet<CatModel>Cats {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Cat.db");
    }

}
