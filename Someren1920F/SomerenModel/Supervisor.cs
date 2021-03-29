using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
     public class Supervision
    {
        public Lecturer lecturer { get; set; }
        public int ActivityId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public string TeacherFullName
        {

            get
            {

                return lecturer.firstName + " " + lecturer.lastName;

            }
        }


    }
}
