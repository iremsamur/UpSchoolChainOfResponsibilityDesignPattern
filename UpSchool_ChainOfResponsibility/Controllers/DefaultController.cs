using Microsoft.AspNetCore.Mvc;
using UpSchool_ChainOfResponsibility.ChainOfResponsibility;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(WithdrawViewModel p)
        {
            Employee treasurer = new Treasurer();//veznedar
            Employee managerAsistant = new ManagerAsistant();
            Employee manager = new Manager();
            Employee regionManager = new RegionManager();
            //her biri  bir sonraki adım için yönlendirilecek
            treasurer.SetNextApprover(managerAsistant);//veznenin sonraki adımı şube müdür yardımcısı
            managerAsistant.SetNextApprover(manager);//müdür
            manager.SetNextApprover(regionManager);//müdürün bir üstü bölge müdürü
            treasurer.ProcessRequest(p);//Veznedardan itibaren parametreden gelen işlemi başlatır. Çünkü Process Request istek gönderiyor
            //employee içinde bu metot var.


            return View();
        }
    }
}
