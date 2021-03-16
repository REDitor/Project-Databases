using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    { //testtest1212are u here
        public List<Drink> Db_Get_All_Drinks()
        {
            SqlCommand cmd = new SqlCommand("SELECT drinkID, drinkname, vatID, drinkPrice, stockAmount, salesCount FROM dbo.drink WHERE stockAmount > 1 ORDER BY stockAmount, drinkPrice, salesCount;",conn);
                    OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Drink> Drinks = new List<Drink>();
            while (reader.Read())
            {
                Drink Drink1 = ReadDrink(reader);
                Drinks.Add(Drink1);
            }
            reader.Close();

            CloseConnection();
            return Drinks;
        }
        private Drink ReadDrink(SqlDataReader reader)
        {
            Drink Drink = new Drink()
            {
             DrinkID = (int)reader["drinkID"],
             DrinkName = (string)reader["drinkname"],
             DrinkPrice = (decimal)reader["drinkPrice"],
             VATID = (int)reader["vatID"],
             SalesCount = (int)reader["salesCount"],
             StockAmount = (int)reader["stockAmount"]
            };
            return Drink;
        }

    }
}
