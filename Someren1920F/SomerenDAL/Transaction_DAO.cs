using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class Transaction_DAO : Base
    {
        public void AddTransaction(Transaction tr)
        {
            // conn.Open();
            // string query = ("INSERT INTO [transaction](totalPrice,drinkID,studentID) VALUES " +
            // "('" + tr.TotalPrice + "','" + tr.DrinkID + "','" + tr.StudentID + "')");

            // SqlCommand Cmd = new SqlCommand(query, conn);

            //// Cmd.Parameters.AddWithValue("@PurchaseDate", tr.PurchaseDate);
            // Cmd.Parameters.AddWithValue("@totalPrice", tr.TotalPrice);
            // //Cmd.Parameters.AddWithValue("@VoucherID", tr.VoucherID);
            // Cmd.Parameters.AddWithValue("@drinkID", tr.DrinkID);
            // Cmd.Parameters.AddWithValue("@studentID", tr.StudentID);
            OpenConnection();
            string query = "INSERT INTO [transaction](drinkID,studentID,totalPrice,purchaseDate) VALUES(@drinkID, @studentID,@totalPrice,@PurchaseDate)";

            //SqlParameter[] sqlParameters = new SqlParameter[0];
            //ExecuteEditQuery(query, sqlParameters);
            SqlCommand Cmd = new SqlCommand(query, conn);
            Cmd.Parameters.AddWithValue("@PurchaseDate", tr.PurchaseDate);
            Cmd.Parameters.AddWithValue("@totalPrice", tr.TotalPrice.ToString("0.00"));
            Cmd.Parameters.AddWithValue("@drinkID", tr.DrinkID);
            Cmd.Parameters.AddWithValue("@studentID", tr.StudentID);
            Cmd.ExecuteNonQuery();

        }
        //public void updateDrink(Transaction t)
        //{
        //    conn.Open();
        //    string query = "UPDATE [Drink] ( salesCount, stockAmount  )" + "VALUES (@salesCount+1, @stockAmount-1)" + "WHERE( drinkname= @drinkname)";

        //    SqlCommand Cmd = new SqlCommand(query, conn);
        //    //Cmd.Parameters.AddWithValue("@salesCount", t.TransactionID);
        //    //Cmd.Parameters.AddWithValue("@", t.PurchaseDate);


        //}

    }  
}
