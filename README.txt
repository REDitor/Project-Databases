!!!(INCLUDES ALL ASSIGNMENTS, PLEASE SCROLL DOWN)!!!

ASSIGNMENT 2 - PROJECT DATABASES
============================================================================================================================
Report Assignment 2 (Variant A, by Sander):
===========================================
SomerenDAL --> Student_DAO.cs:
	- Changed querry string to retrieve the data needed (not using SELECT *).
	- Added required variables inherited from Model Layer(SomerenModel) and used by sql-query for the 
	  students.

SomerenLogic --> Student_Services.cs:
	- Separated 'Name' variable inherited from SomerenModel/Student.cs into 'FirstName' and 'LastName'
	  for testing purposes.

SomerenModel --> Student.cs:
	- Changed and added properties to meet the variables used by the database connection.

SomerenUI --> SomerenUI.cs(Form Design):
	- Changed property 'view' to show details (for displaying columns).

SomerenUI --> SomerenUI.cs(code):
	- Added ColumnHeader Objects for each required column header.
	- Added SubItems to tthe ListViewItems with 'li.SubItems.Add(column)'
	- Added AutoResizeColumns method for both ColumnContent and HeaderSize.

EXTRA:
	- Added 'dateOfBirth' property to dbo.student within the database using an SQL query.
	- Updated 'studentID' for student 'Fehri Imen'
    - Added Lines of code to lecturer panel for autoresizing the columns

Report Assignment 2 (Variant B, by Taher):
==========================================
Write your changes here:
//SomerenUI.cs
added panel room_panel
renamed panel "Dashboard" to pnl_Dashbaord
renamed panel "Students" to pnl_students
changed IF statement to switch

filled up rooms listview with the following foreach

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
                
//added Room_DAO to DAL layer
commented the demented code
 //string query = "SELECT roomID, Capacity, Type FROM room";
            //SqlParameter[] sqlParameters = new SqlParameter[0];
            //return ReadTables(ExecuteSelectQuery(query, sqlParameters));
 and replaced it with :
  SqlCommand cmd = new SqlCommand("SELECT roomID, capacity, roomtype FROM room",conn);
            OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                Room room1 = ReadRoom(reader);
                rooms.Add(room1);
            }
            reader.Close();

            CloseConnection();
            return rooms;
            
            added method:
             Room ReadRoom(SqlDataReader reader)
        {
            Room Rooms = new Room()
            {
                Number=(int)reader["roomID"],
                Type=(bool)reader["roomtype"],
                Capacity = (int)reader["capacity"]
            };
            return Rooms;
        }
        to replace Readtables method
        sql datareader is a bit newer than the Reading the tables the way that was originally written
        
        // Room_Services added to somerenlogic
         public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            try
            {
               rooms  = room_db.Db_Get_All_Rooms();
                return rooms;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Room room1 = new Room()
                {
                    Number = 1234,
                    Type=false,
                    Capacity=4

                };
                rooms.Add(room1);
                return rooms;
            }
        }
    }
    
    // can't remeber if i changed base all that much so imma just copy it over and i will compare it with a fresh someren copy
    
     public abstract class Base
    {
        protected SqlDataAdapter adapter;
        protected SqlConnection conn;
        public Base()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SomerenDatabase"].ConnectionString);
            adapter = new SqlDataAdapter();
        }

        protected SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        protected void CloseConnection()
        {
            conn.Close();
        }

        /* For Insert/Update/Delete Queries with transaction */
        protected void ExecuteEditTranQuery(String query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        {
            SqlCommand command = new SqlCommand(query, conn, sqlTransaction);
            try
            {
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Print.ErrorLog(e);
                throw;
            }
        }

        /* For Insert/Update/Delete Queries */
        protected void ExecuteEditQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                // Print.ErrorLog(e);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }



        /* For Select Queries */
        protected DataTable ExecuteSelectQuery(String query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
                // Print.ErrorLog(e);
                return null;
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
    }

Report Assignment 2 (Variant C, by Imen):
=========================================
In this part of the project I was responsible for variant B, 
I was creating the lecturer table in the data base, 
by implementing some codes ( taking examples from student one ) 
and making sure that the menu button works correctly, 
 also by connecting  it to the data base,
 showing the data from the database and finally some design to the table and creating the panels ...
 My work was mixed by typing some SQL QUERIES and some C# programming structures 
to develop a part of Someren application that displays a list of lecturer.



ASSIGNMENT 3 - PROJECT DATABASES
============================================================================================================================
Report Assignment 3 (Variant A, by Taher):
==========================================
added relevant buttons and labels
added drinks DAO
Added drink Service

added drink name form, stock amount etc..
added add update, delete, buttons
added feature of selecting records by ids for updates or deletes
added alc content as a checkbox

added methods Adddrink(Drink drink)
and method Deletedrink(Drink drink)
and updateDrink(Drink drink)
to someren logic and they call the actual methods from drinkDao

Added the following code to drink dao

public bool AddDrink(Drink drink)
        {

            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.drink ON insert into dbo.drink (drinkname,stockAmount,drinkprice,drinkID,salesCount,vatID) values(@Drinkname,@stockAmount,@drinkPrice,@drinkID,@salescount,@vatid) SET IDENTITY_INSERT dbo.drink OFF", conn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@Drinkname", drink.DrinkName);
            cmd.Parameters.AddWithValue("@stockAmount", drink.StockAmount);
            cmd.Parameters.AddWithValue("@drinkPrice", drink.DrinkPrice);
            cmd.Parameters.AddWithValue("@drinkID", drink.DrinkID);
            cmd.Parameters.AddWithValue("@salescount", drink.SalesCount);
            cmd.Parameters.AddWithValue("@vatid", drink.VATID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;


        }


 public bool Deletedrink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("delete dbo.drink where DrinkID=@id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", drink.DrinkID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        public bool updateDrink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("update dbo.drink set StockAmount=@Stock,DrinkPrice=@price,drinkname=@drinkname where DrinkID=@id", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", drink.DrinkID);
            cmd.Parameters.AddWithValue("@drinkname", drink.DrinkName);
            cmd.Parameters.AddWithValue("@price", drink.DrinkPrice);
            cmd.Parameters.AddWithValue("@stock", drink.StockAmount);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }



all of which were called by the following methods in drink service

 public bool Adddrink(Drink drink)
        {
            try
            {
                drinkDao.AddDrink(drink);
                return true;
            }catch(Exception e)
            {
                //display exception?
              
            }
            return true;
        }

        public bool Deletedrink(Drink drink)
        {
            drinkDao.Deletedrink(drink);
            return true;
        }
        public bool updateDrink(Drink drink)
        {
            drinkDao.updateDrink(drink);
            return true;
        }
added the following event handlers

 private void Add_Click(object sender, EventArgs e)
        {
            Drink drink = new Drink();
            drink.DrinkName = Drink_name_in.Text;
            drink.StockAmount = Convert.ToInt32(Amount_in.Text);
            drink.DrinkPrice = Convert.ToInt32(Price_in.Text);
            drink.DrinkID = Convert.ToInt32(ID_in.Text);
            drink.SalesCount = Convert.ToInt32(Count_in.Text);
            if (VATID.Checked)
            {
                drink.VATID = 1;
            }
            else
            {
                drink.VATID = 0;
            }
            if (Amount_in.Text == "" || Price_in.Text == ""|| Drink_name_in.Text==""|| ID_in.Text==""|| Count_in.Text=="")
            {
                MessageBox.Show("fill in all information correctly");
            }
            service.Adddrink(drink);
            MessageBox.Show($"{drink.DrinkName} has been added");
            //refresh page?
            this.Refresh();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count < 1)
            {
                MessageBox.Show("select a drink");
            }
            Drink drink = listViewDrinks.SelectedItems[0].Tag as Drink;
            service.Deletedrink(drink);
            MessageBox.Show("Record removal is sucessful");
            //page  refresh
            this.Refresh();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count < 1)
            {
                MessageBox.Show("select a drink");
            }
            Drink drink = listViewDrinks.SelectedItems[0].Tag as Drink;
           
             if (Amount_in.Text == "" || Price_in.Text == ""||Drink_name_in.Text=="")
            {
                MessageBox.Show("fill in all information correctly, in either drink price or stock amount or both");
            }
            drink.DrinkName = Drink_name_in.Text;
            drink.StockAmount = Convert.ToInt32(Amount_in.Text);
            drink.DrinkPrice = Convert.ToInt32(Price_in.Text);
            service.updateDrink(drink);
            MessageBox.Show("update successful");
            this.Refresh();

        }



Report Assignment 3 (Variant B + C, by Sander):
===============================================
SomerenDAL --> Transaction_DAO.cs:
	- (Variant B) Added Transaction_DAO class for storing and retrieving from database.
	- (Variant B) Added AddTransaction() method for creating/checking out transactions. 
	- (Variant B) Recreated ReadTables() method which stores the values from the database into variables and then into a 
	  transaction 
	  object, which is then added to the list of all transactions (order history panel in the UI).
	- (Variant C) Added GetByDate() method for selecting transactions from specific start- and end dates for generating 
	  the revenue report. 

SomerenLogic --> Transaction_Services.cs:
	- Added methods GetOrderByDate(), GetAllTransactions() and AddTransaction() in the service layer for handling/throwing 
	  exceptions(catched in the UI(no exceptions implemented in the Transaction_Service yet. To be added later)).

SomerenModel --> Transaction.cs:
	- Added the properties needed transactionId, transactionDate, student(object), drink(object), totalPrice and 
	  purchaseAmount(to be added later) for storing database data into variables.

SomerenUI --> SomerenUI.cs(Form Design):
	- Added button for opening the OrderForm(which handles the creation of orders).

SomerenUI --> SomerenUI.cs(code):
	- Added new else if statement for showing panel for Revenue Report.
	- Added Event handler btnOpenOrderWindow_Click() for button "New Order". (opens order form).

SomerenUI --> OrderForm.cs(Form Design):
	- Added OrderForm.cs
	- Added combobox for both selecting a student and a drink.
	- Added checkout button.

SomerenUI --> OrderForm.cs(code):
	- Added so much in this I prefer not to type it out as it is 20 minutes before the deadline and I forgot to write
	  the logs.
EXTRA:
	- Created method db_GetAllTransactions() containing a query (INNER JOIN) for retrieving all previous orders placed 
	  in the database(wasn't mandatory)
	- Added ListView + ListViewColumns + Header for order history to view all orders that have been placed in the past.
	- Added method RefreshDrinkPanel() for cleaning up the code (to be implemented for all panels).
	- Neurotically improved some details in the Drinks panel XD.
