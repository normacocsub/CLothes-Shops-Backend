using Datos;
using Infraestructura;
using Logica;
using Logica.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ClotheShops;

public class Startup
{
    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Este método se utiliza para configurar los servicios (dependencies) de la aplicación
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar el DbContext
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ClothesContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProovedorService, ProveedorService>();
            services.AddScoped<IClothesContext, ClothesContext>();
            services.AddScoped<IGoogleDriveService, GoogleDriveService>();
            

            services.AddCors();


            services.AddControllers();


            services.AddSwaggerGen();

        }

        // Este método se utiliza para configurar la canalización de solicitud HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // Configuración para entorno de producción
                // app.UseExceptionHandler();
                // app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("https://tienda-online-upc-iota.vercel.app", "http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });


            app.UseHttpsRedirection();
            app.UseRouting();

            // Configuración para autenticación y autorización (si es necesario)
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Otros middlewares y configuraciones adicionales...
        }
}
