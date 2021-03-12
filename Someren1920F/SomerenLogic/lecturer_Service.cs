using System;
using System.Collections.Generic;
using System.Linq;
using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class lecturer_Service
    {
        lecturer_DAO lecturer_db = new lecturer_DAO();

        public List<Lecturer> Getlecturers()
        {
            try
            {
                List<Lecturer> lecturer = lecturer_db.Db_Get_All_Lecturers();
                return lecturer;
            }
            catch (Exception e)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Lecturer> lecturer = new List<Lecturer>();
                Lecturer a = new Lecturer();
                a.firstName = "test failed";
                a.lastName = "Mr. Test lastname lecturer ";
                a.number = 474791;
                a.specialisation = "name of field";
                lecturer.Add(a);
                Lecturer b = new Lecturer();
                b.firstName = "Mr. Test firstname lecturer ";
                b.lastName = "Mr. Test lastname lecturer ";
                b.number = 474791;
                a.specialisation = "name of field";
                lecturer.Add(b);
                return lecturer;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}
