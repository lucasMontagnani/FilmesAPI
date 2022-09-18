using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data;
using UsuariosAPI.Services;

namespace UsuariosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Inserindo Conexão ao Banco de Dados (MySQL)
            services.AddDbContext<UserDbContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("UsuarioConnection")));

            // Adicionando referência necessária ao Identity
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
                // Adicionando confirmação por e-mail
                opt => opt.SignIn.RequireConfirmedEmail = true
                ).AddEntityFrameworkStores<UserDbContext>().
                AddDefaultTokenProviders(); // Para geração de Token de confirmação do e-mail

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuariosAPI", Version = "v1" });
            });

            // Inserindo referencia ao AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeção de Dependencia das classes Services
            services.AddScoped<ICadastroService, CadastroService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuariosAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
