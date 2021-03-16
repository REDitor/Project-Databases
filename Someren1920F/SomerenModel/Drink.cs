using System;

namespace SomerenModel
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        public int VATID { get; set; }
        public int StockAmount { get; set; }
        public int SalesCount { get; set; }
        public override string ToString()
        {
            return $"{ this.DrinkName} ({ this.DrinkPrice})";
        }
       
    }
}
