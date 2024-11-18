
using AutoMapper;
using BookWebApi.Data;
using BookWebApi.Mappers;
using BookWebApi.Repositories;
using BookWebApi.Service;



//using BookWebApi.Repositories;
//using BookWebApi.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BookWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<BookContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
            }
 );
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IAuthorService, AuthorService>();
            builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();

            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddTransient<IBookRepository, BookRepository>();

            builder.Services.AddTransient<IAuthorDetailService, AuthorDetailsService>();
            builder.Services.AddTransient<IAuthorDetailRepository, AuthorDetailsRepository>();

            builder.Services.AddControllers();
            //Ignore Cyclic issue
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
