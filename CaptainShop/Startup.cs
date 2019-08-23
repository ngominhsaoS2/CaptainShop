using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CaptainShop.Services;
using CaptainShop.Data.EF;
using CaptainShop.Data.Entities;
using AutoMapper;
using CaptainShop.Application.Interfaces;
using CaptainShop.Data.IRepositories;
using CaptainShop.Data.EF.Repositories;
using CaptainShop.Application.Implementation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using CaptainShop.Helpers;
using CaptainShop.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CaptainShop.Authorization;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using CaptainShop.Extensions;
using Microsoft.AspNetCore.Mvc;
using CaptainShop.Application.Dapper.Interfaces;
using CaptainShop.Application.Dapper.Implementation;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace CaptainShop
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("CaptainShop.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();
            services.AddMinResponse();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddRecaptcha(new RecaptchaOptions()
            {
                SiteKey = Configuration["Recaptcha:SiteKey"],
                SecretKey = Configuration["Recaptcha:SecretKey"]
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

            services.AddAutoMapper();
            services.AddImageResizer();
            services.AddAuthentication()
                .AddFacebook(facebookOpts =>
                {
                    facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOpts =>
                {
                    googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                });

            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();

            services.AddTransient<DbInitializer>();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 60
                    });
                options.CacheProfiles.Add("Never",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            })
            .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
            .AddDataAnnotationsLocalization()
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            services.Configure<RequestLocalizationOptions>(
              opts =>
              {
                  var supportedCultures = new List<CultureInfo>
                  {
                    new CultureInfo("en-US"),
                    new CultureInfo("vi-VN")
                  };

                  opts.DefaultRequestCulture = new RequestCulture("en-US");
                  // Formatting numbers, dates, etc.
                  opts.SupportedCultures = supportedCultures;
                  // UI strings that we have localized.
                  opts.SupportedUICultures = supportedCultures;
              });

            //IUnitOfWork and IRepository
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            //Repositories
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IProductTagRepository, ProductTagRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<IBillDetailRepository, BillDetailRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<IProductQuantityRepository, ProductQuantityRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IWholePriceRepository, WholePriceRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogTagRepository, BlogTagRepository>();
            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ISystemConfigRepository, SystemConfigRepository>();
            services.AddTransient<IFooterRepository, FooterRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IPageRepository, PageRepository>();

            //Service
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IReportService, ReportService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/CaptainShop-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseImageResizer();
            app.UseStaticFiles();
            app.UseMinResponse();
            app.UseAuthentication();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });

        }
    }
}