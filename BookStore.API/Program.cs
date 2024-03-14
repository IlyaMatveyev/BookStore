using BookStore.Application.Services;
using BookStore.Core.Abstractions;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API
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


            //добавление контектса бд в качестве сервиса
            builder.Services.AddDbContext<BookStoreDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)));
                });
                
            //регистрация сервисов
            builder.Services.AddScoped<IBooksSevice, BooksSevice>();
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();





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

            app.Run();
        }
    }
}