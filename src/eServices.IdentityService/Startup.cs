using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using eServices.IdentityService.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using eServices.IdentityService.Data;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

namespace eServices.IdentityService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                                                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var connectionString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"]; //@"Data Source=(LocalDb)\MSSQLLocalDB;database=IdentityServer4.Quickstart.EntityFramework-2.0.0;trusted_connection=yes;";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentity<AppIdentityUser, AppIdentityRole>()
           .AddEntityFrameworkStores<AppIdentityDbContext>()
           .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddInMemoryIdentityResources(Config.GetIdentityResources())
                //.AddInMemoryApiResources(Config.GetAllApiResources())
                //.AddInMemoryClients(Config.GetAllClients())
                //.AddTestUsers(Config.GetUsers())
                .AddAspNetIdentity<AppIdentityUser>()
                // Define Identityserver configuration store containing config data with EF
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                            builder.UseSqlServer(connectionString,
                                sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                // Define Identityserver operation store containing config data with EF: tokens, consent, etc.
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b =>
                     b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                     sql => sql.MigrationsAssembly(migrationsAssembly));
                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30; // interval in seconds
                })
                ;

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // See iinitial data
            InitializeIdneityServerDatabase(app);

            app.UseIdentityServer();

            //app.UseRouting();

            app.UseStaticFiles();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeIdneityServerDatabase(IApplicationBuilder app)
        {
            //throw new NotImplementedException();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetAllClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiResources.Any())
                {
                    foreach (var resource in Config.GetAllApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
