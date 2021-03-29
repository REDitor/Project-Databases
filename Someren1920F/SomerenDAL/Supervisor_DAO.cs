using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
   public class Supervisor_DAO : Base
    {
        public List<Supervision> GetAllSupervisors()
        {
            List<Supervision> supervisorList = new List<Supervision>();

            // string query = "select dbo.activity.activityID, dbo.lecturer.lecturerID, dbo.activity.startDateTime,dbo.activity.endDateTime, dbo.lecturer.firstname, dbo.lecturer.lastname,dbo.lecturer.specialisation from dbo.activitySupervisorjoin dbo.activity on dbo.activitySupervisor.activityID = dbo.activity.activityIDjoin dbo.lecturer on dbo.lecturer.lecturerID = dbo.activitySupervisor.lecturerID;";
            SqlCommand cmd = new SqlCommand("select a.activityID, a.[description],a.startdatetime,a.enddatetime,s.lecturerID,l.firstname,l.lastname,l.specialisation from activity as a join activitySupervisor as s on s.activityID=a.activityID join lecturer as l on l.lecturerID=s.lecturerID", conn);
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                Supervision supervisor1 = ReadSupervisor(reader);
                supervisorList.Add(supervisor1);
            }
            reader.Close();
            CloseConnection();
            //read Lecturer
            //read dates
            //create a supervisor
            //add to supervisorList
            //return the list

            return supervisorList;

        }
        public List<Supervision> GetallsupervisorsByID(int id)
        {
            List<Supervision> supervisorList = new List<Supervision>();
            SqlCommand cmd = new SqlCommand("select a.activityID,s.lecturerID,l.firstname,l.lastname,a.startdatetime,a.enddatetime,l.specialisation from activity as a join activitySupervisor as s on s.activityID=a.activityID join lecturer as l on l.lecturerID=s.lecturerID where a.activityID=@aID", conn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@aId", id);
            SqlDataReader reader = cmd.ExecuteReader();
          
            while (reader.Read())
            {
                Supervision supervisor1 = ReadSupervisor(reader);
                supervisorList.Add(supervisor1);
            }
            reader.Close();
            CloseConnection();
            return supervisorList;
        }
        private Supervision ReadSupervisor(SqlDataReader reader)
        {
            Lecturer lecturer1 = new Lecturer()
            {


                number = (int)reader["lecturerID"],
                firstName = (string)(reader["firstname"]),
                lastName = (string)(reader["lastname"]),
                specialisation = (string)(reader["specialisation"])
            };
                
        
            
            Supervision supervisor = new Supervision()
            {
               lecturer =lecturer1,
                ActivityId = (int)reader["activityID"],
                StartTime = (DateTime)reader["startDateTime"],
                EndTime = (DateTime)reader["endDateTime"],
                
            };
            return supervisor;
        }
        public void Addsupervision(int id,int lID)
        {
          
            SqlCommand cmd = new SqlCommand("insert into activitySupervisor (lecturerID,activityID) values(@lID, @aID); ",conn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@aID", id);
            cmd.Parameters.AddWithValue("@lID", lID);
            cmd.ExecuteNonQuery();
            CloseConnection();

            
        }

        public void DeleteSupervisor(int id, int lid)
        {
            SqlCommand cmd = new SqlCommand(" delete from dbo.activitySupervisor where lecturerID=@lID and activityID=@aID;", conn);
            OpenConnection();
            cmd.Parameters.AddWithValue("@lID", lid);
            cmd.Parameters.AddWithValue("@aID", id);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
