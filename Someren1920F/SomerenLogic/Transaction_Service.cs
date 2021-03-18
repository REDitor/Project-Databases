using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Transaction_Service
    {
        Transaction_DAO transactionDao = new Transaction_DAO();

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = transactionDao.db_GetAllTransactions();
            return transactions;
        }

        public bool CreateTransaction(Transaction transaction)
        {
            if (transaction.studentId == null)
            {
                throw new Exception("Please select a student");
            }

            if (transaction.drinkId == null)
            {
                throw new Exception("Please select a drink");
            }

            transactionDao.AddTransaction(transaction);
            return true;
        }
    }
}
