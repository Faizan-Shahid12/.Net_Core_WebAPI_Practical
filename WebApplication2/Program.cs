
using WebApi_Practice.Models;
using WebApi_Practice.Controllers;
using WebApi_Practice.Models.Interface;
using WebApi_Practice.Models.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi_Practice
{
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


            builder.Services.AddSingleton<DB>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookService1,BookService1>();

            builder.Services.AddAutoMapper(typeof(Program));

            try
            {
                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Unhandled Exception:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}
