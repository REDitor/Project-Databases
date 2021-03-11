Report Assignment 2 (Variant A):
============================================================================================================
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

VARIANT B (by Taher)
====================================================================================

SomerenUI --> SomerenUI.cs(code):
	- Added ColumnHeader Objects for each required column header.
	- Added SubItems to tthe ListViewItems with 'li.SubItems.Add(column)'
	- Added AutoResizeColumns method for both ColumnContent and HeaderSize.

EXTRA:
	- Added 'dateOfBirth' property to dbo.student within the database using an SQL query.
	- Updated 'studentID' for student 'Fehri Imen'
	
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
