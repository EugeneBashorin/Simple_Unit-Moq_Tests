using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        //private LinqValueCalculator calc;
        private IValueCalculator calc;
        public ShoppingCart(/*LinqValueCalculator*/ IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}
/*
 ShoppingCart, он представляет собой коллекцию объектов
Product и использует LinqValueCalculator для определения их общей стоимости
*/
