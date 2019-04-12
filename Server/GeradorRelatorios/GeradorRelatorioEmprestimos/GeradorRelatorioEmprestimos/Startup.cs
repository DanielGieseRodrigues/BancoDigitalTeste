using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ServerSide.Models;

namespace GeradorRelatorioEmprestimos
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
            var connection = @"Data Source=DESKTOP-9AUJK9K\SQLEXPRESS;Initial Catalog=BancoDigital;Integrated Security=True";
            services.AddDbContext<BancoDigitalContext>(options => options.UseSqlServer(connection));

        }
    }
}
