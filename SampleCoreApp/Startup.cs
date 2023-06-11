using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreApp
{
    public class Startup
    {

        #region Informations
        //Uygulamaya servisleri ekledi�imiz bi yandan da konfigure etti�imiz metot
        //belirli i�lere odaklanm�� ve o i�lerin sorumlulu�unu �stlenmi� k�t�phanelerdir
        //servis=modul=kutuphane
        //bu metot i�erisinde uygulamaya services parametresi �zerinden mvc servisi entegre edilmeli
        #endregion
        public void ConfigureServices(IServiceCollection services)
        {
            #region ControllersWithViews
            //Asp.net core uygulamas�nda mvc mimarisini kullanabilmek i�in
            //uygulamada controller ve view yap�lanmalar�n�n eklenmesi gerekmektedir
            //ve bunlar ekleniyor. Yani uygulama art�k mvc davran��� sergileyecektir
            services.AddControllersWithViews();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //middlewares var burada onlar �a�r�l�yor
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Routing
            //gelen iste�in rotas� bu middleware sayesinde belirlenmektedir.
            //ve ona g�re controllerlara gitmektedir
            app.UseRouting();
            #endregion

            #region Endpoints
            //Yap�lan iste�in var�� noktas�d�r yani URL. Bu uygulamaya gelen isteklerin hangi �ablonlar e�li�inde gelece�ini burada belirtece�iz
            app.UseEndpoints(endpoints =>
            {
                #region Default Routing
                //default route kullan�lacag�n� bel�rt�r
                //endpo�nt �cer�s�nde suslu parantez �c�ndek� parametreler ozel anlam �fade ederler
                //bu demek gelen istek /controller/action/parametre seklinde gelecek demekt�r
                //gelen iste�in format�n� bel�rler
                endpoints.MapDefaultControllerRoute();
                #endregion
            });
            #endregion
        }
    }
}
