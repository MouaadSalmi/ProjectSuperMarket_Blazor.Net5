using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperMarket.Data.InMemory;
using SuperMarket.Data.Sql;
using SuperMarket.Data.Sql.Repositories;
using SuperMarket.Management.CategoriesManagement;
using SuperMarket.Management.Interfaces;
using SuperMarket.Management.ManagementInterafaces;
using SuperMarket.Management.ProductInterface;
using SuperMarket.Management.ProductManagement;
using SuperMarket.Management.Transactions;
using SuperMarket.Management.TranscationsInterface;
using WebApp.Data;

namespace WebApp
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
                options.AddPolicy("CaissierOnly", p => p.RequireClaim("Position", "Caissier"));
            });

            //Di InMemory
            /*services.AddScoped<ICategoriesManagementRepository, CategoryInMemoryRepository>();
            services.AddScoped<IProductInMemoryRepository, ProductInMemoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionsInMemoryRepository>();*/
            //DI SQL Repositories
            services.AddScoped<ICategoriesManagementRepository, CategoriesManagementRepository>();
            services.AddScoped<IProductManagementRepository, ProductManagementRepository>();
            services.AddScoped<ITransactionsManagementRepository, TransactionsManagementRepository>();
            //DI Management Categorie
            services.AddTransient<IViewCategory, ViewCategories>();
            services.AddTransient<IAddCategory, AddCategory>();
            services.AddTransient<IUpdateCategory, UpdateCategory>();
            services.AddTransient<IDeleteCategory, DeleteCategory>();
            services.AddTransient<ISelectByIdCategory, SelectByIdCategory>();
            //DI Management Products
            services.AddTransient<IAddProduct, AddProduct>();
            services.AddTransient<IDeleteProduct, DeleteProduct>();
            services.AddTransient<IGetProductById, GetProductById>();
            services.AddTransient<IGetProductsByCategoryId, GetProductsByCategoryId>();
            services.AddTransient<IUpdateProduct, UpdateProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();
            services.AddTransient<ISellProduct, SellProduct>();
            //Di Transactions
            services.AddTransient<IGetTransactions, GetTransactions>();
            services.AddTransient<IGetTodayTransactions, GetTodayTransactions>();
            services.AddTransient<IRecordTransactions, RecordTransaction>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //identity
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
