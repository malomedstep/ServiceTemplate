using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ServiceTemplate.Domain.Common;
using ServiceTemplate.Domain.Converters;
using ServiceTemplate.Domain.Entities;
using ServiceTemplate.Domain.Interfaces;
using ServiceTemplate.Domain.Models;
using ServiceTemplate.Domain.Services;
using ServiceTemplate.Infrastructure.Common;
using ServiceTemplate.Infrastructure.Repositories;
using ServiceTemplate.Infrastructure.Services;

namespace ServiceTemplate.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddRouting(c => c.LowercaseUrls = true);
            services.AddControllers();
            
            services.AddSingleton<EmailSettings>(_ => new EmailSettings(
                from: Configuration["email:from"],
                login: Configuration["email:login"],
                password: Configuration["email:password"],
                server: Configuration["email:server"],
                port: int.Parse(Configuration["email:port"])
            ));
            services.AddSingleton<RepositorySettings<BookRepository>>(_ => new RepositorySettings<BookRepository>(
                connectionString: Configuration["mongodb:connectionString"],
                database: Configuration["mongodb:database"],
                collection: Configuration["mongodb:collections:books"]
            ));
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUniqueCodeGenerator, UniqueCodeGenerator>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddTransient<IModelConverter<BookEntity, Book>, BookEntityConverter>();
            services.AddTransient<IModelConverter<(CreateBookRequest request, string code), BookEntity>,
                CreateBookRequestConverter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
