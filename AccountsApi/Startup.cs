using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsApi.Config.properties;
using AccountsApi.Exceptions;
using AccountsApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;


namespace AccountsApi
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
           
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IAccountService, AccountService>();
            //services.AddSingleton<IAccountRepository, MockAccountRepository>();
            services.AddSingleton<IAccountRepository, AccountMongoDbRepository>();

            services.Configure<AccountDatabaseSettings>(
        Configuration.GetSection(nameof(AccountDatabaseSettings)));

            services.AddSingleton<IAccountDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AccountDatabaseSettings>>().Value);
            services.AddLogging(opt =>
            {
                opt.AddConsole();
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
            
        {
     
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    GlobalExceptionHandler.handle(options, loggerFactory);
                    //options.Run(async context =>
                    //{
                    //    context.Response.StatusCode = 500;
                    //    context.Response.ContentType = "application/json";
                    //    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    //    if (errorFeature != null)
                    //    {
                    //        ///TODO: Need to Log here
                    //        ///
                    //    }

                    //    await context.Response.WriteAsync("{code:100,error:Internalerror}");
                    //});
                });
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
