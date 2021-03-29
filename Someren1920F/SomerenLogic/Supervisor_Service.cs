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
   public class Supervisor_Service
    {
        Supervisor_DAO supervisor_db = new Supervisor_DAO();
        public List<Supervision> GetSupervisorsbyid(int id)
        {
            List<Supervision> supervisors = new List<Supervision>();
            supervisors = supervisor_db.GetallsupervisorsByID(id);
            return supervisors;
            //try
            //{
            //    supervisors = supervisor_db.GetAllSupervisors();
            //    return supervisors;
            //}catch(Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //    Supervisor supervisor = new Supervisor()
            //    {
            //        ActivityId = 0101123,
            //        StartTime = DateTime.UtcNow,
            //        EndTime = DateTime.UtcNow,
            //        lecturer= new Lecturer()
            //        {
            //            firstName = "test failed",
            //            lastName = "Mr. Test lastname lecturer ",
            //            number = 474791,
            //            specialisation = "name of field",
            //        }


            //    };
            //    supervisors.Add(supervisor);
            //    return supervisors;
            //}
        }

        public void AddSupervisor(int id, int lecturer_id)
        {
           supervisor_db.Addsupervision(id, lecturer_id);
            
        }
        public void DeleteSupervisor(int id, int l_id)
        {
            supervisor_db.DeleteSupervisor(id, l_id);
        }
    }
}
