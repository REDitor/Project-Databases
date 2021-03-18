using System;
using System.IO;

namespace SomerenDAL
{
    public class ErrorLog_DAO
    {
        //path to errorlog.txt
        private string path = @"..\..\..\errorlog.txt";

        //Updates the errorlog with the error messages
        public void UpdateErrorLog(string errorMessage)
        {
            File.AppendAllText(path, $"\n({DateTime.Now}) {errorMessage}");
        }
    }
}
