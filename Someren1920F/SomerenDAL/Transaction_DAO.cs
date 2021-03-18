using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Transaction_DAO : Base
    {
        public List<Transaction> db_GetAllTransactions()
        {
            string query = "SELECT transactionID, purchaseDate, voucherID, drinkID, studentID, totalPrice" +
                           "FROM [transaction];";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Transaction> ReadTables(DataTable dataTable)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Transaction t = new Transaction()
                {
                    transactionId = (int)dr["transactionID"],
                    transactionDate = (DateTime)dr["purchaseDate"],
                    voucherId = (int)dr["voucherID"],
                    drinkId = (int)dr["drinkID"],
                    studentId = (int)dr["studentID"],
                    totalPrice = (int)dr["totalPrice"]
                };
                transactions.Add(t);
            }
            return transactions;
        }


        public bool AddTransaction(Transaction transaction)
        {
            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT [transaction] ON " +
                                            "INSERT INTO [transaction] (transactionID, purchaseDate, voucherID, drinkID, studentID, totalPrice) " +
                                            "values(@transactionId, @purchaseDate, @voucherId, @drinkId, @studentId, @totalPrice) " +
                                            "SET IDENTITY_INSERT [transaction] OFF", conn);

            OpenConnection();

            cmd.Parameters.AddWithValue("@transactionId", transaction.transactionId);
            cmd.Parameters.AddWithValue("@purchaseDate", transaction.transactionDate);
            cmd.Parameters.AddWithValue("@voucherId", transaction.voucherId);
            cmd.Parameters.AddWithValue("@drinkId", transaction.drinkId);
            cmd.Parameters.AddWithValue("@studentId", transaction.studentId);
            cmd.Parameters.AddWithValue("@totalPrice", transaction.totalPrice);
            cmd.ExecuteNonQuery();

            CloseConnection();
            return true;
        }

        
    }
}

