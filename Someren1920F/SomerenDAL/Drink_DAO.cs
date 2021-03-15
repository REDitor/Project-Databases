using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    {
        public List<Drink> Db_Get_All_Drinks()
        {
            string query = "SELECT drinkID, drinkname, vatID, drinkPrice, stockAmount, salesCount FROM dbo.drink WHERE stockAmount > 1 AND drinkPrice > 1 ORDER BY stockAmount, drinkPrice, salesCount;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    DrinkID = (int)dr["drinkID"],
                    DrinkName = (string)(dr["drinkname"]),
                    VATID = (int)dr["vatID"],
                    DrinkPrice = (int)dr["drinkPrice"],
                    StockAmount = (int)dr["stockAmount"],
                    SalesCount = (int)dr["salesCount"]
                };
                drinks.Add(drink);
            }
            return drinks;
        }
    }
}
