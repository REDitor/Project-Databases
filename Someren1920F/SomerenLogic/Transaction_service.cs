using System;
using System.Collections.Generic;
using System.Linq;
using SomerenDAL;
using SomerenModel;
using System.Text;
using System.Threading.Tasks;


namespace SomerenLogic
{
   public  class Transaction_service
    {
        Transaction_DAO transaction_db = new Transaction_DAO();
        public void  GETTransaction(Transaction tr)
        {
            try
            {
                transaction_db.AddTransaction(tr);

                
            }
            catch (Exception e)
            {
                // something went wrong connecting to the database, so we will add a fake list of rooms from the database to make sure the rest of the application continues working!

                string errorMessage = String.Format
                 ($"[{e.Message}] Transaction - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);


                //throw new Exception("Someren couldn't connect to the database");
                throw new Exception("Something went wrong when connecting to the database for Transaction!");
            }
        } 
        
    }
}


