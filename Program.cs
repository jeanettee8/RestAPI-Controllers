using Microsoft.AspNetCore.Mvc;
using RestAPI_Controllers.DatabaseContext;
using RestAPI_Controllers.Models;

namespace RestAPI_Controllers;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<CatDatabaseContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();
        using (var context=new CatDatabaseContext()){
            if (!context.Cats.Any()) {
                var cats = File.ReadAllLines("cat_breeds.csv");
                foreach (var cat in cats.Skip(1)) {
                    var catData = cat.Split(',',StringSplitOptions.None).ToList();
                    while (catData.Count<6) {
                        catData.Add(string.Empty);
                    }
                    var newCat = new CatModel() {
                        Breed = catData[0], Country = catData[1], BodyType = catData[3], Coat = catData[4], Pattern = catData[5]
                    };
                    context.Cats.Add(newCat);
                }
                context.SaveChanges();
            }
        }
        app.Run();
    }
}
