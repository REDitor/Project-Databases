using SomerenLogic;
using SomerenModel;
using System;
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
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("pnl_Dashboard");
        }

        private void showPanel(string panelName)
        {

            switch(panelName)
            {
                case "pnl_Dashboard":
                    
                    pnl_Dashboard.Show();
                    img_Dashboard.Show();

                    pnl_Students.Hide();
                    room_panel.Hide();

                
               
                    break;
                case "pnl_Students":
            
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                room_panel.Hide();

                    // show students
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);
                }
                    break;

                case "room_panel":
            
                //hide other panels

                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();


                //show rooms

                room_panel.Show();
                

                SomerenLogic.Room_Service room_Service = new SomerenLogic.Room_Service();
                List<Room> RoomList = room_Service.GetRooms();
                //clear listview before filling it

                listViewRoom.Items.Clear();
                //fill up list view
                foreach(SomerenModel.Room r in RoomList)
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
                    break;
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Dashboard");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("pnl_Dashboard");
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
            showPanel("pnl_Students");
        }

        private void RoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("room_panel");
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
