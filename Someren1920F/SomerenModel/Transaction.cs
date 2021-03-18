using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
   public class Transaction
    {
        public int TransactionID { get; set; }

        public DateTime PurchaseDate { get { return DateTime.Now; }   }

        public float TotalPrice { get; set; }
        public int VoucherID { get; set; }

        public int DrinkID { get; set; }

        public int StudentID {get; set;}

        // construct for transaction
        public Transaction( float totalPrice,  int drinkID, int studentID)
        {
            

            this.TotalPrice = totalPrice;
            
            this.DrinkID = drinkID;

            this.StudentID = studentID;

        }
    }
}
