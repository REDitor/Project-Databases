using System;

namespace SomerenModel
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public float DrinkPrice { get; set; }
        public int VATID { get; set; }
        public int StockAmount { get; set; }
        public int SalesCount { get; set; }
    }
}
