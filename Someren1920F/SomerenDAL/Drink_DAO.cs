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
            SqlCommand cmd = new SqlCommand("SELECT drinkID, drinkname, vatID, drinkPrice, stockAmount, salesCount FROM dbo.drink WHERE stockAmount > 1 ORDER BY stockAmount, drinkPrice, salesCount;", conn);
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
        public bool AddDrink(Drink drink)
        {

            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.drink ON insert into dbo.drink (drinkname,stockAmount,drinkprice,drinkID,salesCount,vatID) values(@Drinkname,@stockAmount,@drinkPrice,@drinkID,@salescount,@vatid) SET IDENTITY_INSERT dbo.drink OFF", conn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@Drinkname", drink.DrinkName);
            cmd.Parameters.AddWithValue("@stockAmount", drink.StockAmount);
            cmd.Parameters.AddWithValue("@drinkPrice", drink.DrinkPrice);
            cmd.Parameters.AddWithValue("@drinkID", drink.DrinkID);
            cmd.Parameters.AddWithValue("@salescount", drink.SalesCount);
            cmd.Parameters.AddWithValue("@vatid", drink.VATID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;


        }
        public bool Deletedrink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("delete dbo.drink where DrinkID=@id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", drink.DrinkID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        public bool updateDrink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("update dbo.drink set StockAmount=@Stock,DrinkPrice=@price,drinkname=@drinkname where DrinkID=@id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", drink.DrinkID);
            cmd.Parameters.AddWithValue("@drinkname", drink.DrinkName);
            cmd.Parameters.AddWithValue("@price", drink.DrinkPrice);
            cmd.Parameters.AddWithValue("@stock", drink.StockAmount);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
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
