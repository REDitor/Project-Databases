using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Drinks_DAO : Base
    {
        public List<Drinks> Db_Get_All_Drinks()
        {
            //string query = "SELECT roomID, Capacity, Type FROM room";
            //SqlParameter[] sqlParameters = new SqlParameter[0];
            //return ReadTables(ExecuteSelectQuery(query, sqlParameters));

            SqlCommand cmd = new SqlCommand("SELECT drinkID, drinkname, vatID, drinkPrice, stockAmount, salesCount FROM drink WHERE stockAmount > 1 AND drinkPrice > 1 ORDER BY stockAmount, drinkPrice, salesCount; ", conn);
            OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Drinks> Drink = new List<Drinks>();
            while (reader.Read())
            {
                Drinks Drink1 = ReadDrinks(reader);
                Drink.Add(Drink1);
            }
            reader.Close();

            CloseConnection();
            return Drink;


        }
        Drinks ReadDrinks(SqlDataReader reader)
        {
            Drinks drink = new Drinks()
            {
                DrinkID = (int)reader["drinkID"],
                DrinkName = (string)reader["drinkname"],
                DrinkPrice = (float)reader["drinkPrice"],
                VATID = (int)reader["vatID"],
                StockAmount = (int)reader["stockAmount"]
            };
            return drink;
        }
    }
}
