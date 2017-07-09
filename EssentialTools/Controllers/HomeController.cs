using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        //Add in constuctor DI
        private IValueCalculator calc;
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            //For Ninject Connect
          //  IKernel ninjectKernel = new StandardKernel();//создание экземпляра Ninject ядра
          //  ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();//создание связи между интерфейсами в нашем приложении и реализациями классов, с которыми мы хотим работать
         //   IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();// использование Ninject
            //LinqValueCalculator calc = new LinqValueCalculator();
            //IValueCalculator calc = new LinqValueCalculator(); //for IoC injection
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}