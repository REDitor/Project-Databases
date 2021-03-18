using System;

namespace SomerenModel
{
    public class Drink
    {
        private decimal priceInclVat;

        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        public int VATID { get; set; }
        public int StockAmount { get; set; }
        public int SalesCount { get; set; }

        public decimal PriceInclVAT
        {
            get
            {
                if (VATID == 1)
                {
                    priceInclVat = DrinkPrice * 1.06m;
                }

                else
                {
                    priceInclVat = DrinkPrice * 1.21m;
                }
                return priceInclVat;
            }
        }
    }
}
