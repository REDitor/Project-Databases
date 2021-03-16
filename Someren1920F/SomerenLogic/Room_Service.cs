using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;
using System.Windows.Forms;

namespace SomerenLogic
{
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
            //hurdur i comment
        }
    }
}
