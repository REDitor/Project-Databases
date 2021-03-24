using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activityDao = new Activity_DAO();

        public List<Activity> GetAllActivities()
        {
            return activityDao.db_GetAllActivities();
        }

        public bool AddActivity(Activity activity)
        {
            activityDao.AddActivity(activity);
            return true;
        }

        public bool DeleteActivity(Activity activity)
        {
            activityDao.DeleteActivity(activity);
            return true;
        }
        public bool UpdateActivity(Activity activity)
        {
            activityDao.UpdateActivity(activity);
            return true;
        }
    }
}
