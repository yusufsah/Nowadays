using Entity.Dtos;
using Entity.Model;
using Entity.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using Service.Contract;

namespace Presentation.Controllers
{
    public class ProjectController : Controller
    {

        private readonly IServiceManager _manager;

        public ProjectController(IServiceManager manager)
        {
            _manager = manager;
        }




        public IActionResult Index(int companysId)  // companysId parametresi metoda geçiriliyor
        {
            var requestParameters = new ProductRequestParameters { CompanysId = companysId }; // Yeni bir ProductRequestParameters nesnesi oluşturuluyor ve companysId atanıyor
            var model = _manager.ProjectService.GetAllProductwithDetails(requestParameters).ToList();
            return View(model);
        }








        /// ///////////////////////////////


        [HttpGet]
        public IActionResult Creat()
        {   // ismi yanlışlıkla creat yazdım   burası ürün ekleme kısmı

            ViewBag.categores = new SelectList(_manager.CompanyService.GetAllProducts(false), "CompanysId", "CompanyName", "1");


            return View();

        }

        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat([FromForm] ProjectsDtosForinsertion productDto)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim //,IFormFile file bu kısım resim seçmek için sonradan eklendi asyc o yüzden yaptık
        {

            if (ModelState.IsValid)
            {
              

                _manager.ProjectService.createproduct(productDto);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }




        }


        //////////////////////
        ///

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {




            var model = _manager.ProjectService.GetOneProductForUpdate(id, false);

           
            return View(model);      
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProjectsDtosForUpdate projectsDtosForUpdate)  // burası Product yapmıştık sonra  dto ekleyince değiştirdim // ve resim güncellemek için file ve asyn yaptık 
        {
            if (ModelState.IsValid)
            {




              
                _manager.ProjectService.UpadateOneProduct(projectsDtosForUpdate);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }

        }

        //////////////////////
        ///
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProjectService.DeleteOneProduct(id);

            return RedirectToAction("Index", "Home");
            // delete işle Product index de delete buntonun içindeki asp-action="Delete"  sayesinde  çalışıyor
        }


        /////
        
    }
}
