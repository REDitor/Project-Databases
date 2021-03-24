using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class Activity_DAO : Base
    {
        public List<Activity> db_GetAllActivities()
        {
            SqlCommand cmd = new SqlCommand("SELECT activityID, description, startDateTime, endDateTime " +
                             "FROM dbo.activity;", conn);

            OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Activity> activities = new List<Activity>();

            while (reader.Read())
            {
                Activity activity = ReadActivity(reader);
                activities.Add(activity);
            }
            reader.Close();
            CloseConnection();

            return activities;
        }

        private Activity ReadActivity(SqlDataReader reader)
        {
            Activity activity = new Activity()
            {
                activityID = (int)reader["activityID"],
                description = (string)reader["description"],
                startDate = (DateTime)reader["startDateTime"],
                endDate = (DateTime)reader["endDateTime"]
            };
            return activity;
        }

        public bool AddActivity(Activity activity)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.activity (description, startDateTime, endDateTime) " +
                                            "VALUES(@description, @startdatetime, @enddatetime)", conn);

            OpenConnection();

            cmd.Parameters.AddWithValue("@description", activity.description);
            cmd.Parameters.AddWithValue("@startdatetime", activity.startDate);
            cmd.Parameters.AddWithValue("@enddatetime", activity.endDate);
            cmd.ExecuteNonQuery();

            CloseConnection();

            return true;
        }
        public bool DeleteActivity(Activity activity)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.activity " +
                                            "WHERE activityID=@id", conn);
            OpenConnection();

            cmd.Parameters.AddWithValue("@id", activity.activityID);
            cmd.ExecuteNonQuery();

            CloseConnection();
            return true;
        }
        public bool UpdateActivity(Activity activity)
        {
            SqlCommand cmd = new SqlCommand("UPDATE dbo.activity " +
                                            "SET description=@description, startDateTime=@start, endDateTime=@end " +
                                            "WHERE activityID=@id", conn);
            OpenConnection();

            cmd.Parameters.AddWithValue("@id", activity.activityID);
            cmd.Parameters.AddWithValue("@description", activity.description);
            cmd.Parameters.AddWithValue("@start", activity.startDate);
            cmd.Parameters.AddWithValue("@end", activity.endDate);
            cmd.ExecuteNonQuery();

            CloseConnection();

            return true;
        }
    }
}
