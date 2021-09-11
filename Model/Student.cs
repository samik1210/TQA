using System;
using System.Data;
using System.Data.SqlClient;



namespace Model
{
    public class Student
    {
        public int Stud_ID { get; set; }
        public string Stud_FirstName { get; set; }
        public string Stud_LastName { get; set; }
        public string Stud_Address { get; set; }
        public string Stud_Batch { get; set; }
        public string Stud_Trainer { get; set; }
        public int Stud_COMMUNICATIONSKILL { get; set; }
        public int Stud_Theory { get; set; }

        public int Stud_Practical { get; set; }
        public int Total { get; set; }
        public double Stud_Per { get; set; }
        public string Stud_Result { get; set; }

    }
}
