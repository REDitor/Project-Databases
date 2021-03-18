using System;
using SomerenLogic;
using SomerenModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        private Drink_Service drinkService = new Drink_Service();

        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {
            //Hide all panels
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_Students.Hide();
            pnl_lecturer.Hide();
            pnl_Room.Hide();
            pnl_Drinks.Hide();
            pnl_CashRegister.Hide();

            if (panelName == "Dashboard")
            {
                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // show students
                pnl_Students.Show();

                // clear the listview before filling it again
                listViewStudents.Clear();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                ColumnHeader id = new ColumnHeader();
                id.Text = "StudentID";

                ColumnHeader firstName = new ColumnHeader();
                firstName.Text = "FirstName";

                ColumnHeader lastName = new ColumnHeader();
                lastName.Text = "LastName";

                ColumnHeader origin = new ColumnHeader();
                origin.Text = "Origin";

                ColumnHeader dateOfBirth = new ColumnHeader();
                dateOfBirth.Text = "BirthDate";



                listViewStudents.Columns.AddRange(new ColumnHeader[] { id, firstName, lastName, origin, dateOfBirth });


                foreach (Student s in studentList)
                {
                    ListViewItem li = new ListViewItem(s.StudentId.ToString(), 0);
                    li.SubItems.Add(s.FirstName);
                    li.SubItems.Add(s.LastName);
                    li.SubItems.Add(s.Origin);
                    li.SubItems.Add(s.BirthDate.ToString("dd-MM-yyyy"));
                    listViewStudents.Items.Add(li);
                }

                listViewStudents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewStudents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else if (panelName == "Lecturers")
            {
                // show lecturers
                pnl_lecturer.Show();

                // clear the listview before filling it again
                lvlecturer.Items.Clear();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.lecturer_Service lectService = new SomerenLogic.lecturer_Service();
                List<Lecturer> lecturerList = lectService.Getlecturers();

                foreach (SomerenModel.Lecturer l in lecturerList)
                {

                    ListViewItem li = new ListViewItem(new[] { l.number.ToString(), l.firstName, l.lastName, l.specialisation });
                    lvlecturer.Items.Add(li);
                }

                lvlecturer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvlecturer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }



            else if (panelName == "room_panel")
            {
                //show rooms
                pnl_Room.Show();

                Room_Service room_Service = new Room_Service();
                List<Room> RoomList = room_Service.GetRooms();

                //clear listview before filling it
                listViewRoom.Items.Clear();

                //fill up list view
                foreach (Room r in RoomList)
                {
                    ListViewItem Item = new ListViewItem(r.Number.ToString());

                    if (r.Type)
                    {
                        Item.SubItems.Add("Teacher");
                    }
                    else
                    {
                        Item.SubItems.Add("Students");
                    }
                    Item.SubItems.Add(r.Capacity.ToString());
                    Item.Tag = r;

                    listViewRoom.Items.Add(Item);
                }

                listViewStudents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }

            else if (panelName == "Drinks")
            {
                //show drinks
                pnl_Drinks.Show();

                RefreshDrinkPanel();

                listViewDrinks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewDrinks.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            else if (panelName == "Cash Register")
            {
                //show cash register
                pnl_CashRegister.Show();

                RefreshCashRegisterPanel();
            }
        }

        private void RefreshCashRegisterPanel()
        {
            //Add students to combobox
            Student_Service studentService = new Student_Service();
            List<Student> students = studentService.GetStudents();

            //Clear comboboxes
            cmbDrinks.Items.Clear();
            cmbStudents.Items.Clear();

            foreach (Student student in students)
            {
                cmbStudents.Items.Add(student.FullName);
            }

            //Add drinks to combobox
            Drink_Service drinkService = new Drink_Service();
            List<Drink> drinks = drinkService.GetDrinks();

            foreach (Drink drink in drinks)
            {
                cmbDrinks.Items.Add($"{drink.DrinkName}, (€ {drink.PriceInclVAT:0.00})");
            }
        }

        private void RefreshDrinkPanel()
        {
            Drink_Service drinkService = new Drink_Service();
            List<Drink> drinks = drinkService.GetDrinks();

            //clear listview before filling it
            listViewDrinks.Items.Clear();

            //fill up list view
            foreach (Drink d in drinks)
            {
                ListViewItem li = new ListViewItem(d.DrinkID.ToString(), 0);
                li.SubItems.Add(d.DrinkName);
                li.SubItems.Add(d.VATID.ToString());
                li.SubItems.Add(d.DrinkPrice.ToString());
                li.SubItems.Add(d.StockAmount.ToString());

                //if(d.StockAmount< 10)
                //{
                //    li.SubItems.Add(d.StockAmount.ToString());
                //    li.SubItems.Add("Nearly depleted");

                //}else if (d.StockAmount == 0)
                //{
                //    li.SubItems.Add(d.StockAmount.ToString());
                //    li.SubItems.Add("is empty");

                //}
                //else
                //{
                //    li.SubItems.Add("stock sufficient");

                //}

                li.SubItems.Add(d.SalesCount.ToString());
                li.Tag = d;
                listViewDrinks.Items.Add(li);
            }
        }//????????????????????????????????????????????????

        private void btnCheckout_Click(object sender, EventArgs e)
        {
           
            Transaction_Service transactionService = new Transaction_Service();
            Transaction transaction = new Transaction();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void RoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("room_panel");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addUpdateDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }

        private void cashRegisterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Cash Register");
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lvlecturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lvlecturer_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Amount_in_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Drink drink = new Drink();

            drink.VATID = 1;
            drink.DrinkID = Convert.ToInt32(ID_in.Text);
            drink.DrinkName = Drink_name_in.Text;

            if (VATID.Checked)
            {
                drink.VATID = 2;
            }

            drink.StockAmount = Convert.ToInt32(Amount_in.Text);
            drink.SalesCount = Convert.ToInt32(Count_in.Text);
            drink.DrinkPrice = Convert.ToDecimal(Price_in.Text);

            if (Amount_in.Text == "" || Price_in.Text == "" || Drink_name_in.Text == "" || ID_in.Text == "" || Count_in.Text == "")
            {
                MessageBox.Show("fill in all information correctly");
            }
            drinkService.Adddrink(drink);
            MessageBox.Show($"{drink.DrinkName} has been added");

            //refresh page
            RefreshDrinkPanel();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count < 1)
            {
                MessageBox.Show("select a drink");
            }
            Drink drink = listViewDrinks.SelectedItems[0].Tag as Drink;
            drinkService.Deletedrink(drink);
            MessageBox.Show("Record removal is sucessful");

            //page  refresh
            RefreshDrinkPanel();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            Drink drink;
            try
            {
                drink = listViewDrinks.SelectedItems[0].Tag as Drink;
                drink.DrinkName = Drink_name_in.Text;
                drink.StockAmount = Convert.ToInt32(Amount_in.Text);
                drink.SalesCount = Convert.ToInt32(Count_in.Text);
                drink.DrinkPrice = Convert.ToDecimal(Price_in.Text);
                drinkService.updateDrink(drink);

                MessageBox.Show("update successful");
            }
            catch (Exception)
            {
                MessageBox.Show("select a drink");
            }
            //page  refresh
            RefreshDrinkPanel();
        }

        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count == 1)
            {
                ID_in.Enabled = false;
                Count_in.Enabled = false;
                VATID.Enabled = false;

                Drink drink = listViewDrinks.SelectedItems[0].Tag as Drink;

                //ListViewItem item = listViewDrinks.SelectedItems[0];
                ID_in.Text = drink.DrinkID.ToString();
                Drink_name_in.Text = drink.DrinkName;
                Price_in.Text = drink.DrinkPrice.ToString();
                Amount_in.Text = drink.StockAmount.ToString();
                Count_in.Text = drink.SalesCount.ToString();

                if (drink.VATID == 2)
                {
                    VATID.CheckState = CheckState.Checked;
                }
            }

            else if (listViewDrinks.SelectedItems.Count == 0)
            {
                VATID.CheckState = CheckState.Unchecked;

                ID_in.Enabled = true;
                Count_in.Enabled = true;
                VATID.Enabled = true;

                ID_in.ResetText();
                Drink_name_in.ResetText();
                Amount_in.ResetText();
                Price_in.ResetText();
                Amount_in.ResetText();
                Count_in.ResetText();
            }
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStudents.SelectedItem;
        }

        private void cmbDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
