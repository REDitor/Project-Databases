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
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT studentID, firstname, lastname, origin, dateOfBirth FROM dbo.Student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentId = (int)dr["studentID"],
                    FirstName = (string)dr["firstname"],
                    LastName = (string)dr["lastname"],
                    Origin = (string)dr["origin"],
                    BirthDate = (DateTime)dr["dateOfBirth"]
                };
                students.Add(student);
            }
            return students;
        }

    }
}
