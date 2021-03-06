﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
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
            //Autofac, Ninject,CastleWindsor StructureMap,LightInject,DryInject --> IoC Container
            //AOP= 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            TokenOptions _tokenOptions = new TokenOptions();

            var a =Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            _tokenOptions = new TokenOptions
            {
                Audience = Configuration["TokenOptions:Audience"],
                Issuer = Configuration["TokenOptions:Issuer"],
                ServerSecret = Configuration["TokenOptions:ServerSecret"],
                AccessTokenExpiration = Convert.ToInt32(Configuration["TokenOptions:AccessTokenExpiration"])

            };

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IProductService,ProductManager>(); // Bana arka planda bir referans oluştur.
            //services.AddSingleton<IProductDal, EfProductDal>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismy"));
            services.AddAuthentication(x => 
                { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; x.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(x =>
                { x.RequireHttpsMetadata = false; x.SaveToken = true; x.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, IssuerSigningKey = key, ValidateIssuer = true, ValidateAudience = true

                    }; });
            ServiceTool.Create(services);

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
            

            app.UseAuthentication(); //hangi yapılar sırasıyla devreye girer onu gosterır.

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule());
        }
    }
}
