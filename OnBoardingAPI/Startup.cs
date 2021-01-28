using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnBoardingAPI.Data;
using Newtonsoft.Json.Serialization;

namespace OnBoardingAPI
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
            services.AddCors();

            services.AddDbContext<OnBoardingContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("OnBoardingConnection")));

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IPersonalDetailsRepo, SqlPersonalDetailsRepo>();
            services.AddScoped<IEducationQualification, SqlEducationQualificationRepo>();
            services.AddScoped<IEducationCertification, SqlEducationCertificationRepo>();
            services.AddScoped<IPreviousEmployer, SqlPreviousEmployerRepo>();
            services.AddScoped<IGroupMedicalCover, SqlGroupMedicalCoverRepo>();
            services.AddScoped<IKid, SqlKidRepo>();
            services.AddScoped<IOtpGenerator, SqlOtpGeneratorRepo>();
            services.AddScoped<IOtherDetails, SqlOtherDetailsRepo>();
            services.AddScoped<IOtherProfessionalDetails, SqlOtherProfessionalDetailsRepo>();
            services.AddScoped<IUploadDocuments, SqlUploadDocumentsRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

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
