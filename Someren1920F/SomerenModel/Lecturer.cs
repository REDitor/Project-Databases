﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Lecturer
    {
        public string firstName { get; set; }//  Lecturerfirstname, e.g. gerwin
        public string lastName { get; set; }//  Lecturerlastname, e.g. Van dijken

        public string specialisation { get; set; }
        public int number { get; set; } // LecturerNumber, e.g. 47198

    }
}