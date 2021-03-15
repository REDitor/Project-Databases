using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        public List<Room> Db_Get_All_Rooms()
        {
            //string query = "SELECT roomID, Capacity, Type FROM room";
            //SqlParameter[] sqlParameters = new SqlParameter[0];
            //return ReadTables(ExecuteSelectQuery(query, sqlParameters));

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


        }
        private Room ReadRoom(SqlDataReader reader)
        {
            Room Rooms = new Room()
            {
                Number=(int)reader["roomID"],
                Type=(bool)reader["roomtype"],
                Capacity = (int)reader["capacity"]
            };
            return Rooms;
        }
        //private List<Room> ReadTables(DataTable data)
        //{
        //    List<Room> rooms = new List<Room>();
        //    foreach(DataRow dr in data.Rows)
        //    {
        //        Room room = new Room()
        //        {
        //            Number = (int)dr["RoomID"],
        //            Capacity = (int)dr["capacity"],
        //            Type = (bool)dr["Type"]
        //        };
        //        rooms.Add(room);

        //    }
        //    return rooms;
        //}
    }
}
