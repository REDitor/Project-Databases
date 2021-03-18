using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Transaction
    {
        public int transactionId { get; set; }
        public DateTime transactionDate { get; set; }
        public int voucherId { get; set; }
        public int drinkId { get; set; }
        public int studentId { get; set; }
        public decimal totalPrice { get; set; }
    }
}
