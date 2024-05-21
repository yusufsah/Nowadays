using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using Service.Contract;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _manager;

        public HomeController(ILogger<HomeController> logger, IServiceManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CompanyService.GetAllProducts(false);
            return View(model);
        }

        //

        [HttpGet]
        public IActionResult Creat()
        {   // ismi yanlışlıkla creat yazdım   burası ürün ekleme kısmı

           

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat([FromForm] CompanyDtosForinsertion companyDtosForinsertion)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim //,IFormFile file bu kısım resim seçmek için sonradan eklendi asyc o yüzden yaptık
        {

            if (ModelState.IsValid)
            {
                

                _manager.CompanyService.createproduct(companyDtosForinsertion);

                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }


        //

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.CompanyService.DeleteOneProduct(id);

            return RedirectToAction("Index");
            // delete işle Product index de delete buntonun içindeki asp-action="Delete"  sayesinde  çalışıyor
        }


        /// <summary>
        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            



            var model = _manager.CompanyService.GetOneProductForUpdate(id, false);

            //var model = _manager.ProductService.GetOneProduct(id, false); // dto kullanmadan önce böyle yaptık 
            return View(model);      // bunu yaptık çünkü isimli kendiliğinden getiriyor ana ekrana  dto ve eskiside aynı işe yarıyor
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] CompanyDtosForUpdate CompanyDtosForUpdate)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim // ve resim güncellemek için file ve asyn yaptık 
        {
            if (ModelState.IsValid)
            {

          


                // resim güncelleme olmasa yukarıya gerek yoktu
                _manager.CompanyService.UpadateOneProduct(CompanyDtosForUpdate);

                return RedirectToAction("Index");
            }
            else
            {
                return View();

            }

        }
        ////////////////////////////////////////////////////////////////////////
        ///


        public IActionResult get([FromRoute(Name = "id")] int id)  // te bir ürün almak istiyorum
        {
            var model = _manager.CompanyService.GetOneProduct(id, false);

            return View(model);
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
