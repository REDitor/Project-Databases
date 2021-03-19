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
        private Student_DAO studentDao = new Student_DAO();
        private Drink_DAO drinkDao = new Drink_DAO();

        public List<Transaction> db_GetAllTransactions()
        {
            string query = "SELECT transactionID, student.studentID, student.firstname, student.lastname, drink.drinkID, drink.drinkname, drink.drinkprice, " +
                            "drink.stockAmount, [transaction].totalPrice, [transaction].purchaseDate " +
                            "FROM [transaction] " +
                            "INNER JOIN drink on [transaction].drinkID=drink.drinkID " +
                            "INNER JOIN student on [transaction].studentID=student.studentID";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Transaction> ReadTables(DataTable dataTable)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int studentId = (int)dr["studentID"];
                int drinkId = (int)dr["drinkID"];

                Drink drink = drinkDao.GetById(drinkId);

                Transaction transaction = new Transaction()
                {
                    transactionId = (int)dr["transactionID"],
                    transactionDate = (DateTime)dr["purchaseDate"],
                    student = studentDao.GetById(studentId),
                    drink = drink,
                    totalPrice = Convert.ToDecimal(dr["totalPrice"])
                };
                transactions.Add(transaction);
            }
            return transactions;
        }

        public List<Transaction> GetByDate(DateTime startDate, DateTime endDate)
        {
            List<Transaction> tempTransactions = db_GetAllTransactions();
            List<Transaction> transactions = new List<Transaction>();

            foreach (Transaction t in tempTransactions)
            {
                if (t.transactionDate.Day >= startDate.Day && t.transactionDate.Day <= endDate.Day)
                { 
                    transactions.Add(t);
                }
            }

            return transactions;
        }


        public bool AddTransaction(Transaction transaction)
        {
            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT [transaction] OFF " +
                                            "INSERT INTO [transaction] (purchaseDate, drinkID, studentID, totalPrice) " +
                                            "values(@purchaseDate, @drinkId, @studentId, @totalPrice)", conn);

            OpenConnection();

            cmd.Parameters.AddWithValue("@purchaseDate", transaction.transactionDate);
            cmd.Parameters.AddWithValue("@drinkId", transaction.drink.DrinkID);
            cmd.Parameters.AddWithValue("@studentId", transaction.student.StudentId);
            cmd.Parameters.AddWithValue("@totalPrice", transaction.drink.PriceInclVAT);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();

            CloseConnection();
            return true;
        }
    }
}

