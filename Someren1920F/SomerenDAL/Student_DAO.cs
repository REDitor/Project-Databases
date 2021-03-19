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
            string query = "SELECT studentID, firstname, lastname, dateOfBirth FROM dbo.student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public Student GetById(int id)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT studentID, firstname, lastname, dateOfBirth FROM student WHERE studentID = @stId", conn);

            OpenConnection();
            cmd.Parameters.AddWithValue("@stId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Student student = null;
            if (reader.Read())
            {
                student = ReadStudent(reader);
            }
            reader.Close();
            conn.Close();

            return student;
        }

        public Student GetByName(string fullName)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT studentID, firstname, lastname, dateOfBirth, fullname FROM student WHERE fullname = @fullName", conn);

            OpenConnection();
            cmd.Parameters.AddWithValue("@fullName", fullName);
            SqlDataReader reader = cmd.ExecuteReader();
            Student student = null;

            if (reader.Read())
            {
                student = ReadStudent(reader);
            }
            reader.Close();
            conn.Close();

            return student;
        }

        private Student ReadStudent(SqlDataReader reader)
        {
            Student student = new Student()
            {
                StudentId = (int)reader["studentID"],
                FirstName = (string)reader["firstname"],
                LastName = (string)reader["lastname"],
                BirthDate = (DateTime)reader["dateOfBirth"]
            };
            return student;

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
                    BirthDate = (DateTime)dr["dateOfBirth"]
                };
                students.Add(student);
            }
            return students;
        }

    }
}
