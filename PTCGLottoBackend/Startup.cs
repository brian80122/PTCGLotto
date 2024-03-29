﻿using System;
using System.IO;
using System.Reflection;
using isRock.LineBot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using PTCGLottoLibrary;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Models.CodeFirsts;
using PTCGLottoLibrary.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace PTCGLottoBackend
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
            services.AddDbContext<PTCGLottoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PTCGLottoDbConnection"),
                                     b => b.MigrationsAssembly("PTCGLottoBackend"));
            });
         
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "PTCGLotto API",
                    Description = "PTCGLotto Swagger Doc",
                    TermsOfService = "https://example.com/terms",
                    Contact = new  Contact
                    {
                        Name = "Brian",
                        Email = string.Empty,
                        Url = "https://google.com.tw/",
                    },
                    License = new License
                    {
                        Name = "Use under MIT",
                        Url = "https://example.com/license",
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc()
                 .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



            //Di
            services.AddTransient<ICardParseSerivce, CardParseSerivce>();
            services.AddTransient<IPTCGService, PTCGService>();
            services.AddTransient(ctx =>
            {
               var token =  Configuration.GetValue(typeof(string), "LineChannelToken") as string;
                return new Bot(token);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PTCGLottoContext pTCGLottoContext)
        {
            pTCGLottoContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PTCGLotto API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
