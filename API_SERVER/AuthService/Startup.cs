using System;
using System.Collections.Generic;
using System.Text;
using AuthService.Server.auth;
using AuthService.Server.Notification;
using AuthService.Server.Role;
using AuthService.Server.Role.Chucnang;
using AuthService.Server.Role.Phanquyen;
using AuthService.Server.Role.QuyenSudungChucnang;
using AuthService.Server.user;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Model;
using Model.AuthorizationHandler;
using Model.CheckPermissions;
using Model.Connection;
using Model.Connection.Oracle;
using Model.Connection.SQLServer;
using Model.Model;

namespace AuthService
{
    public class Startup
    {
        Connection connection = new Connection();
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Iauth, AuthImpl>();
            services.AddScoped<Iuser, UserImpl>();
            services.AddScoped<Inotification, NotificationImpl>();
            services.AddScoped<Iphanquyen, PhanquyenImpl>();
            services.AddScoped<Iquyen, QuyenImpl>();
            services.AddScoped<Ichucnang, ChucnangImpl>();
            services.AddScoped<IquyenSudungChucnang, QuyenSudungChucnangImpl>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection.connectionStringSQL));


            services.AddScoped<ICheckPermissions, CheckPermissionImpl>();
            services.AddScoped<IAuthorizationHandler, CheckPermissionsHandler>();


            //authozire policy
            //services.AddAuthorization(options => {
            //    options.AddPolicy("Lay_DS_Nguoidung", policy => { policy.RequireRole("admin1", "user"); });
            //});
            services.AddAuthorization(options =>
            {
                for (int i = 1; i <= 11; i++)
                {
                    options.AddPolicy(i.ToString(),
                        policy => policy.Requirements.Add(new CheckPermissionsRequirement(i)));
                }

            });

            //authozire
            var audience = new Audience();
            var audienceConfig = Configuration.GetSection("Audience");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audience.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audience.Iss,
                ValidateAudience = true,
                ValidAudience = audience.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
              
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
