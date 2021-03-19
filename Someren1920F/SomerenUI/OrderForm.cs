using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;

namespace SomerenUI
{
    public partial class OrderForm : Form
    {
        public Student_Service studentService = new Student_Service();
        public Drink_Service drinkService = new Drink_Service();
        public Transaction_Service transactionService = new Transaction_Service();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            List<Student> students = studentService.GetStudents();

            foreach (Student student in students)
            {
                cmbStudents.Items.Add(student.FullName);
            }

            List<Drink> drinks = drinkService.GetDrinks();
            foreach (Drink drink in drinks)
            {
                cmbDrinks.Items.Add(drink.DrinkName);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = null;

                if (cmbStudents.SelectedIndex >= 0)
                {
                    
                    student = studentService.GetByName(cmbStudents.SelectedItem.ToString());
                }

                Drink drink = null;

                if (cmbDrinks.SelectedIndex >= 0)
                {
                    drink = drinkService.GetByName(cmbDrinks.SelectedItem.ToString());
                }

                //check for stock
                if (drink.StockAmount >= 0)
                {
                    drink.StockAmount -= 1;
                    drinkService.updateDrink(drink);

                    //create new order
                    Transaction transaction = new Transaction()
                    {
                        student = student,
                        drink = drink,
                        transactionDate = DateTime.Now
                    };

                    //check for birthdate (alcoholic)
                    int age = DateTime.Now.Year - transaction.student.BirthDate.Year;
                    if (DateTime.Now.Day > transaction.student.BirthDate.Day)
                    {
                        age += 1;
                    }

                    if (age < 18 && drink.VATID == 2)
                    {
                        MessageBox.Show("You cannot buy alcohol yet!");
                    }

                    else
                    {
                        DialogResult print = MessageBox.Show($"Price (incl. VAT): {drink.PriceInclVAT} vouchers\nProceed?", "", MessageBoxButtons.YesNo);

                        if (print == DialogResult.Yes)
                        {
                            transactionService.AddTransaction(transaction);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("This product is currently out of stock.");
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
