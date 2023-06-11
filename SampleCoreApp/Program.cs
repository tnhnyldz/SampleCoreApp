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
        //Asp.Net Core uygulamalar� �z�nde bir console uygulamas�d�r. Asp.net core kendi icerisinde bir sunucu bar�nd�r�r. ��te o suncuyu aya�a kald�rd��� 
        //nokta bu Program.cs dosyas�d�r.
        #endregion
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        #region Information
        //Program.cs icerisinde ayaga kald�r�lacak hostun kullanacag� konfigurasyonlar� nereden alaca��n� bildirmektedir. Startupdaki konfigurasyonlar� al�r
        //startup temel konf�gurasyon s�n�f�d�r.
        #endregion
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
