namespace RegistroNotas.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using SocialMedia.Infrastructure.Filters;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers(Options =>
            {
                Options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(optons =>
            {
                optons.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                optons.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Cors
            services.AddCors(o => o.AddPolicy(
                    "PoliticaCors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }));
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestión De Notas", Version = "v1", Description="--DIEGO MADRID--" });
            });
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meals.Notas.API v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/Notas/swagger/v1/swagger.json", "Meals.Notas.API v1"));
            }

            // Habilitar Cors
            app.UseRouting();

            app.UseCors("PoliticaCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}