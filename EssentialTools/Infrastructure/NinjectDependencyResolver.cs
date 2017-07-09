using EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices (Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
            /*Новая связка указывает, что если класс FlexibleDiscountHelper должен использоваться в качестве
реализации интерфейса IDiscountHelper, тогда Ninject будет внедрять реализацию в объект LinqValueCalculator.*/
        }
    }
}
/*
MVC фреймворк вызовет методы GetService или GetServices, когда ему будет нужен экземпляр
класса для обработки входящих запросов. Работа DR заключается в создании этого экземпляра:
задача, которую мы выполняем при помощи методов Ninject TryGet и GetAll. Метод TryGet
работает как метод Get, который мы использовали ранее, но он возвращает null, если нет
подходящей связки, а не выбрасывает исключение. Метод GetAll поддерживает несколько связок
для одного типа.
Наш класс DR также находится там, где мы установили наши Ninject связки. В методе AddBindings
мы используем методы Bind и To, чтобы установить связь между интерфейсом IValueCalculator и
классом LinqValueCalculator.
*/
