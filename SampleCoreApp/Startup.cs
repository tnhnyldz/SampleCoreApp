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
        //Uygulamaya servisleri eklediðimiz bi yandan da konfigure ettiðimiz metot
        //belirli iþlere odaklanmýþ ve o iþlerin sorumluluðunu üstlenmiþ kütüphanelerdir
        //servis=modul=kutuphane
        //bu metot içerisinde uygulamaya services parametresi üzerinden mvc servisi entegre edilmeli
        #endregion
        public void ConfigureServices(IServiceCollection services)
        {
            #region ControllersWithViews
            //Asp.net core uygulamasýnda mvc mimarisini kullanabilmek için
            //uygulamada controller ve view yapýlanmalarýnýn eklenmesi gerekmektedir
            //ve bunlar ekleniyor. Yani uygulama artýk mvc davranýþý sergileyecektir
            services.AddControllersWithViews();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //middlewares var burada onlar çaðrýlýyor
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Routing
            //gelen isteðin rotasý bu middleware sayesinde belirlenmektedir.
            //ve ona göre controllerlara gitmektedir
            app.UseRouting();
            #endregion

            #region Endpoints
            //Yapýlan isteðin varýþ noktasýdýr yani URL. Bu uygulamaya gelen isteklerin hangi þablonlar eþliðinde geleceðini burada belirteceðiz
            app.UseEndpoints(endpoints =>
            {
                #region Default Routing
                //default route kullanýlacagýný belýrtýr
                //endpoýnt ýcerýsýnde suslu parantez ýcýndeký parametreler ozel anlam ýfade ederler
                //bu demek gelen istek /controller/action/parametre seklinde gelecek demektýr
                //gelen isteðin formatýný belýrler
                endpoints.MapDefaultControllerRoute();
                #endregion
            });
            #endregion
        }
    }
}
