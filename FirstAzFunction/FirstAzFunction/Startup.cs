using FirstAzFunction;
using FirstAzFunction.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly:WebJobsStartup(typeof(Startup))]
namespace FirstAzFunction
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            string connstr = Environment.GetEnvironmentVariable("AzureSqlDatabase");
            builder.Services.AddDbContext<EmployeeDBContext>(options =>
            {
                options.UseSqlServer(connstr);
            });

            builder.Services.BuildServiceProvider();
        }
    }
}
