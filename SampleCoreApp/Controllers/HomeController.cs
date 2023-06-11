using Microsoft.AspNetCore.Mvc;
using SampleCoreApp.Models;

namespace SampleCoreApp.Controllers
{
    #region Information
    //sıradan bir classın req karsılayabılır ve response dondurebılır
    //ozellıge gelmesı ıcın
    //controller sınıfından miras alması zorunludur. Controllerın temel amacı requestlerı karsılamadır ve
    //baska hıcbır algorıtma veya yapı amacı ıcın kullanılmamalıdır. ıcınde iş kodları bulunmamalıdır.
    //Actıonlar da yonlendırme yapmalıdır iş yapmamalıdır
    //controller .NET frameworkden gelmektedır controller sınıfında viewde
    //veri tasıyabılecegımız elemanlar mevcuttur
    //controllerbase ise gelen req uzerındekı butun dataları sana getırebılecek yapılar vardır
    //aynı zamanda response ıle ılgılı confıgurasyonları yapmanı saglayacak yapılar vardır
    //api controllerlar controllerbaseden mıras alır mvc controllerlar ıse normal controllerdan mıras alır
    #endregion

    #region Information About Views
    //Viewler kesınlıkle Views diye bir klasörde olmak zorundadır.Bır controllera aıt vıewlerın hepsı ılgılı
    //controllerın ısmının oldugu bır klasor altında bulunmak zorundadır. Aynı ısımlı Viewlar farklı klasorlerın altında bulunabılır
    //mimari bunu bilir. actıonlar ViewResult olarak sonucu dönerler ve tarayıcı alır bunu render eder gosterır
    //.cshtml render edılınce HTML verir Cs Kodunun cıktısı alınır Cs kodu ayıklanır.
    #endregion
    public class HomeController : Controller
    {
        #region Information
        //controller sınıfların ıcerısınde ısteklerı karsılayan metotlara actıon denır.
        //kontroller sınıfları ıcerısınde tanımlanan tum metotlar artık actıon metot olarak adlandırılırlar
        //eger controllerdan mıras almıyorsa o metot actıon degıl normal metottur. Bir sınıf controller nıtelıgı
        //kazanmıyorsa ıcındekı metotlar da actıon nıtelıgı kazanmazlar
        //actıon metot controllerlara gelen ıstegı karsılar ve gereklı işlemi yapar.
        //tetıkleme asamasında controller classdan nesne alınır ve ılgılı actıon ınvoke edılır
        #endregion
        public IActionResult Index()
        {
            #region Information
            //modele gider oradakı sınıfı kullanır ve gerekırse viewe gider gereklı makyajı yapar bunun sonucu olan 
            //ViewResultu da kullanıcıya return eder 
            #endregion
            Product product = new Product();
            #region Information
            //verı uretıldı View() fonksyonu bu actıona aıt cshtml dosyasını tetıkleyecek. View() geriye ViewResult döner
            //ViewResult result =new View() bu boyle kullanılabılır. Burada yapılan ilgili kontrollerdan verinin üretilip viewe 
            //gonderılır orada makyajlanıp makyaj yapılmıs halının buraya geri result degıskenıne donmesıdır. Bu sonuc kullanıcıya
            //yollanır. Viewresult olarak yollandıgında tarayıcı ılgılı html kaynagını yorumlayacaktır result. deyıp ıncelenebılır
            // View() boş olan overload ılgılı actıon ısmıyle bırebır aynı cshtmle gıdecektır
            // fakat spesıfık bır view tetıklemek istersek View("Ahmet"); dememız gerekır tabıkı yolunu da vererek
            //viewler gerı donus tıpı olan metotlardır
            //cshtml dostasının render edılmıs halıne vıewresult denmektedır
            #endregion
            return View();
        }
        #region actıons
        //actıonların gerı donus turlerıne uygun deger uretmemız gerekıyorsa bu degerlerı uretecek Fonksyonlar base class
        //tarafından bıze saglanmaktadır bu durumda controller oluyor bu.
        //hangı turde clıente deger doneceksek bu ture uygun fonksyonu cagırmamız yeterlıdır.

        #region ViewResult
        //Response olarak bir .cshtml dosyasını render etmemızı saglayan bır turdur. Cshtml dosyasını render edıp
        //sonucu clıenta yollayacaksak vıewresult olarak gonderıyoruz. Viewi render ettıkten sonra sonuc viewresult olarak gelır
        //ve bu clıente yollanır
        public IActionResult Sample()
        {
            //View() ilgili controller ismine karsılık gelen views klasoru altındaki bir klasorun içerisindeki
            //action metodunun ismine karsılık gelen .cshtmli render eden ve bu pathı baz alıp calısan. Ve sonucu bize viewresult olarak 
            //veren bır fonksyondur
            ViewResult result = View();
            return result;
        }
        #endregion
        #region PartivalViewResult
        //yine bir view dosyasını yani cshtml dosyasını render etmemızı saglayan bır turdur.
        //ViewResulttan temel farkı clıent tabanlı yapılan ajax ısteklerınde kullanıma cok uygun
        //olmasıdır.
        //genelde yapılan istek client tabanlı degılse viewresult kullanılır. Fakat clıent tabanlı ise yanı
        //ajax kullanılıyorsa Partıalvıewresult kullanılır.lokal noktaları olusturmak ıcın kullanılır.
        //maliyeti uygundur layout kullanmaz genel sayfa render edılmez
        public PartialViewResult Sample2()
        {
            PartialViewResult result = new PartialViewResult();
            return result;
        }
        #endregion
        #region JsonResult
        //cliente Json formatında deger donecek ıse bu kullanılır içi dolu olmalıdır
        //clıent tabanlı verının clıent tarafında ıslenecegı projelerde bunlar cok kullanılır 
        //bi apı bunları serve eder
        public JsonResult Sample3()
        {
            Product p = new Product();
            JsonResult result = Json(p);
            return result;
        }
        #endregion
        #region EmptyResult
        //bazen gelen ıstekler netıcesınde bırsey dondurmek ıstemeyebılırız o zaman bunu donerız
        //void de aynı seyı yapar
        public EmptyResult Sample4()
        {
            return new EmptyResult();
        }
        #endregion
        #region ContentResult
        //istek neticesinde metınsel bir ifade dondurmek istersek
        //sonucu text yollar AJAX tabanlı ıslemlerde tercıh edılır
        public ContentResult Sample5()
        {
            string ContentString = "laksjdjakdsjlkasdmnaklds";
            ContentResult result = Content(ContentString);
            return result;
        }
        #endregion
        #region ActionResult
        //ActıonResult butun metot turlerının base classıdır. Gerıye donecek actıon turlerı degıskenlık gosterecek ıse kullanılır.
        //ifler falan varsa geriye ne donecegı bellı degılse ortak olan budur. Actıon turlerının atasıdır. genellıkle bu kullanılır cunku 
        //ozellıstırılmeden herseyı doner
        public ActionResult Sample6()
        {
         return View();
        }
        //IActıonResult ise actıonresultun bır ınterfaceıdır. bu kadar genelde bu kullanılır
        public IActionResult Sample7()
        {
            return View();
        }
        #endregion

        #endregion
    }
}
