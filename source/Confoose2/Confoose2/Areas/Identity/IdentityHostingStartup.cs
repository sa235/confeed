using System;
using Confoose2.Areas.Identity.Data;
using Confoose2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Confoose2.Areas.Identity.IdentityHostingStartup))]
namespace Confoose2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ConfooseContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ConfooseContextConnection")));

                services.AddDefaultIdentity<ConfooseUser>()
                    .AddEntityFrameworkStores<ConfooseContext>();
            });
        }
    }
}