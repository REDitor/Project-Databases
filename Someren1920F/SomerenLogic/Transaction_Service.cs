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
        private Transaction_DAO transactionDao = new Transaction_DAO();

        public List<Transaction> GetOrderByDate(DateTime startDate, DateTime endDate)
        {
            return transactionDao.GetByDate(startDate, endDate);
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactionDao.db_GetAllTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionDao.AddTransaction(transaction);
        }
        
    }
}
