using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
namespace SomerenDAL
{
    public class lecturer_DAO : Base
    {

        public List<Lecturer> Db_Get_All_Lecturers()
        {
            string query = "SELECT * FROM [lecturer]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Lecturer> ReadTables(DataTable dataTable)
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Lecturer lecturer = new Lecturer()
                {
                    number = (int)dr["lecturerID"],
                    firstName = (string)(dr["firstname"]),
                    lastName = (string)(dr["lastname"]),
                    specialisation = (string)(dr["specialisation"])
                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }

    }
}
