using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Drink_Service
    {
        Drink_DAO drinkDao = new Drink_DAO();

        public List<Drink> GetDrinks()
        {
            try
            {
                List<Drink> drinks = drinkDao.Db_Get_All_Drinks();
                return drinks;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Drink> drinks = new List<Drink>();
                Drink d = new Drink();
                d.DrinkID = 120;
                d.DrinkName= "Test Drink";
                d.DrinkPrice = 1;
                d.VATID = 2;
                drinks.Add(d);
                Drink d2 = new Drink();
                d2.DrinkID = 121;
                d2.DrinkName = "Test Drink2";
                d2.DrinkPrice = 2;
                d2.VATID = 2;
                drinks.Add(d2);
                return drinks;
                //throw new Exception("Someren couldn't connect to the database");
            }
        }
    }
}
