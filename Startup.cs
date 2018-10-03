﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace burgershack {
  public class Startup {
    // stuff is only registered in this file

    private readonly string _connectionString = "";

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
      _connectionString = configuration.GetSection("DB").GetValue<string>("MySqlConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      // the same as configuring body-parser in node
      // all about pulling in 3rd party libraries and configuring them.


      services.AddCors(options => {
        options.AddPolicy("CorsDevPolicy", builder => {
          builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
      });
      services.AddMvc();

      services.AddTransient<IDbConnection>(x => CreateDBContext());

      services.AddTransient<BurgersRepository>();
      services.AddTransient<SmoothiesRepository>();
      // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    private IDbConnection CreateDBContext() {
      MySqlConnection connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      // where you would say `app.use(bodyparser)`
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseCors("CorsDevPolicy");
      } else {
        app.UseHsts();
      }
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc();
    }
  }
}
