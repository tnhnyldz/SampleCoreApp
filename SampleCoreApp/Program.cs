using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreApp
{
    public class Program
    {
        #region Information
        //Asp.Net Core uygulamalarý özünde bir console uygulamasýdýr. Asp.net core kendi icerisinde bir sunucu barýndýrýr. Ýþte o suncuyu ayaða kaldýrdýðý 
        //nokta bu Program.cs dosyasýdýr.
        #endregion
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        #region Information
        //Program.cs icerisinde ayaga kaldýrýlacak hostun kullanacagý konfigurasyonlarý nereden alacaðýný bildirmektedir. Startupdaki konfigurasyonlarý alýr
        //startup temel konfýgurasyon sýnýfýdýr.
        #endregion
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
