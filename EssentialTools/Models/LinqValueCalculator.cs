using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator: IValueCalculator
    {
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
            //return products.Sum(p => p.Price);
        }
    }
}
/*Класс LinqValueCalculator определяет единственный метод ValueProducts, использующий LINQ
метод Sum, чтобы сложить значения свойства Price каждого объекта Product, который передается
методу*/
