using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BaoMen.Demo.AdminWebApi
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置信息的实例</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureBmDemo(services);
            ConfigureAutoMapper(services);
            ConfigureSwagger(services);

            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddControllers()
                //.AddJsonOptions(options =>
                //{
                //    // Use the default property (Pascal) casing.
                //    // options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //})
                .AddNewtonsoftJson(options =>
                {
                    // Use the default property (Pascal) casing
                    // options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = 10;
                })
                .AddMvcOptions(options =>
                {
                    //options.ValueProviderFactories.Insert(0, new Microsoft.AspNetCore.Mvc.ModelBinding.JQueryFormValueProviderFactory());
                    //支持jquery格式的querystring
                    options.ValueProviderFactories.Insert(0, new Microsoft.AspNetCore.Mvc.ModelBinding.JQueryQueryStringValueProviderFactory());
                });

            ConfigureValidation(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bmcc ADMIN API V1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// 配置Demo
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureBmDemo(IServiceCollection services)
        {
            services.AddBmmf();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICurrentUserService, Utils.CurrentUserService>();
            services.AddScoped<IMerchantService, Utils.MerchantService>();

            services.AddSingleton<WeChat.Util.IConfigBuilder, MultiMerchant.WeChat.ConfigBuilder>();
        }

        /// <summary>
        /// 配置Swagger
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "BaoMen Shop API",
                    Description = "BaoMen Shop ASP.NET Core Web API"
                });
                //c.OrderActionsBy(o => o.RelativePath);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BaoMen.MultiMerchant.xml"));
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BaoMen.MultiMerchant.Web.xml"));

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(schemalIdSelector => schemalIdSelector.FullName);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });

                Microsoft.OpenApi.Models.OpenApiSecurityRequirement openApiSecurityRequirement = new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    { new Microsoft.OpenApi.Models.OpenApiSecurityScheme { Name = "Bearer" }, new List<string>() }
                };
            });
        }

        /// <summary>
        /// 配置AutoMapper
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(p => p.FullName.StartsWith("BaoMen"));
            var assemblies = assemblyNames.Select(p => Assembly.Load(p));
            services.AddAutoMapper(assemblies);

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        /// 配置验证
        /// </summary>
        /// <param name="services"></param>
        private IServiceCollection ConfigureValidation(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    if (context.ModelState.IsValid)
                        return null;
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var modelState in context.ModelState)
                    {
                        var modelStateEntry = modelState.Value;
                        string message = string.Join(' ', modelStateEntry.Errors.Select(p => p.ErrorMessage).ToArray());
                        stringBuilder.Append(message);
                        //var message = modelStateEntry.Errors.FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.ErrorMessage))?.ErrorMessage;
                        //if (string.IsNullOrWhiteSpace(message))
                        //{
                        //    message = modelStateEntry.Errors.FirstOrDefault(o => o.Exception != null)?.Exception.Message;
                        //}
                        //if (string.IsNullOrWhiteSpace(message))
                        //    continue;
                        //error = message;
                        //break;
                    }
                    return new JsonResult(new ResponseData { ErrorNumber = 400, ErrorMessage = stringBuilder.ToString() });
                };
            });
            return services;
        }
    }
}
