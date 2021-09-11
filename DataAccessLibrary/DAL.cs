using System;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Text.RegularExpressions;

namespace DataAccessLibrary
{
   public class DAL
    {
        static string constr = "Data Source=DESKTOP-I2Q9QKQ\\SQLEXPRESS;Initial Catalog=TQACADEMY;Integrated Security=True;";
        public void ShowBestStudent()
        {
            DataTable DT = ExecuteData("Select Stud_FirstName,Stud_LastName,Stud_Batch,Stud_Trainer,Total,Stud_Per,Stud_Result from ACADEMY order by Stud_Per desc");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("*************************List of Students*************************");
                Console.WriteLine("=====================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["Stud_FirstName"].ToString() + "| |" + row["Stud_LastName"].ToString() + "| |" +row["Stud_Batch"].ToString() + "| |" + row["Stud_Trainer"].ToString() + "| |"+ row["Total"].ToString() +  "| |" +row["Stud_Per"].ToString() + "| |" +row["Stud_Result"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!No Records Found!!!");
                Console.Write(Environment.NewLine);
            }

        }
        public void DisplayStudent()
        {
            DataTable dt = ExecuteData("select * from ACADEMY");
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("======================================================================================");
                Console.WriteLine("DataBase Records");
                Console.WriteLine("========================================================================================");

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Stud_ID"].ToString() + "| |" + row["Stud_FirstName"].ToString() + "| |" + row["Stud_LastName"].ToString() + "| |" + row["Stud_Address"].ToString() + "| |" + row["Stud_Batch"].ToString() + "| |" + row["Stud_Trainer"].ToString() + "| |" + row["Stud_COMMUNICATIONSKILL"].ToString() + "| |" + row["Stud_Theory"].ToString() + "| |" + row["Stud_Practical"].ToString() +  "| |" + row["Total"].ToString() +   "| |" + row["Stud_Per"].ToString() + "| |" + row["Stud_Result"].ToString());
                }

                Console.WriteLine("===============================================" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("========================================================================================");
                Console.WriteLine("No Student found in the database table ....");
                Console.WriteLine("========================================================================================");
                Console.WriteLine(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(String Query)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    //  sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void AddStudent(Student student)
        {
            ExecuteCommand(String.Format("Insert into ACADEMY(Stud_ID,Stud_FirstName,Stud_LastName,Stud_Address,Stud_Batch,Stud_Trainer,Stud_COMMUNICATIONSKILL,Stud_Theory,Stud_Practical,Total,Stud_Per,Stud_Result) values ({0},'{1}','{2}','{3}','{4}','{5}','{6}' ,'{7}','{8}',{9},{10},'{11}')", student.Stud_ID, student.Stud_FirstName, student.Stud_LastName, student.Stud_Address, student.Stud_Batch, student.Stud_Trainer, student.Stud_COMMUNICATIONSKILL, student.Stud_Theory, student.Stud_Practical, student.Total, student.Stud_Per, student.Stud_Result));

        }
        public bool ExecuteCommand(string queury)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void EditStudent(Student student)
        {
            Console.WriteLine("========================================================================================");
            Console.WriteLine("Modify Existing Student");
            Console.WriteLine("========================================================================================");
            ExecuteCommand(String.Format("Update ACADEMY set Stud_ID  = {0}, Stud_FirstName = '{1}',Stud_LastName = '{2}',Stud_Address = '{3}',Stud_Batch = '{4}',Stud_Trainer = '{5}',Stud_COMMUNICATIONSKILL = '{6}',Stud_Theory='{7}',Stud_Practical = '{8}',Total = {9},Stud_Per = {10},Stud_Result = '{11}' where Stud_ID = {0}", student.Stud_ID, student.Stud_FirstName, student.Stud_LastName, student.Stud_Address, student.Stud_Batch, student.Stud_Trainer, student.Stud_COMMUNICATIONSKILL, student.Stud_Theory, student.Stud_Practical, student.Total, student.Stud_Per, student.Stud_Result));

        }
        public void DeleteStudent()
        {

            Console.WriteLine("========================================================================================");
            Console.WriteLine("Delet Existing Student: ");
            Console.WriteLine("========================================================================================");
            Console.Write("Enter Stud_ID: ");
            int Stud_ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("========================================================================================");
            ExecuteCommand(String.Format("Delete from ACADEMY where Stud_ID = {0}", Stud_ID));
            Console.WriteLine("========================================================================================");
            Console.WriteLine("Student details deleted from the database!" + Environment.NewLine);
        }

        public Student GetInputFromUser()
        {
            int Stud_ID;
            string Stud_FirstName = string.Empty;
            string Stud_LastName = string.Empty;
            string Stud_Address = string.Empty;
            string Stud_Batch = string.Empty;
            string Stud_Trainer = string.Empty;
            int Stud_COMMUNICATIONSKILL;
            int Stud_Theory;
            int Stud_Practical;
            int Total;
            double Stud_Per;
            string Stud_Result = string.Empty;


            Console.WriteLine("=======================================================================================: ");
            Console.WriteLine(" student Details ");
            Console.WriteLine("========================================================================================");
            Console.Write("Enter Stud_ID: ");
            Stud_ID = Convert.ToInt32(Console.ReadLine());
            while (string.IsNullOrEmpty(Stud_FirstName))
            {
                //Console.WriteLine("Name cant be empty!");
                Console.WriteLine("Enter Student First name ");
                Stud_FirstName = Console.ReadLine();

            }

            while (string.IsNullOrEmpty(Stud_LastName))
            {
                //Console.WriteLine("Name cant be empty! ");
                Console.WriteLine("Enter Student Last name ");
                Stud_LastName = Console.ReadLine();

            }

            while (string.IsNullOrEmpty(Stud_Address))
            {

                //Console.WriteLine("Enter Student address once again");
                //Console.WriteLine("Name cant be empty! ");
                Console.WriteLine("Enter Student Address ");
                Stud_Address = Console.ReadLine();

            }
        batchh:
            Console.Write("Enter Stud_Batch: ");
            Stud_Batch = Console.ReadLine();

            if (Stud_Batch == "C#")
            {
                Stud_Trainer = "Nitya";
            }
            else if (Stud_Batch == "Java")
            {
                Stud_Trainer = "Nisha";
            }
            else if (Stud_Batch == "C")
            {
                Stud_Trainer = "Kirti";
            }
            else if (Stud_Batch == "C++")
            {
                Stud_Trainer = "Jayashree";
            }
            else
            {
                Console.WriteLine(Stud_Batch + " is not available please choose options from(C#,C,C++,Java)");
                goto batchh;
            }

            markss:
            Console.Write("Enter Stud_COMMUNICATIONSKILL: ");
            int marks = Convert.ToInt32(Console.ReadLine());
            if (marks <= 50)
            {
                Stud_COMMUNICATIONSKILL = marks;
            }
            else
            {
                Console.WriteLine("Enter marks out of 50... ");
                goto markss;
            }

            Stud_Per = (Convert.ToDouble(Stud_COMMUNICATIONSKILL) / 50) * 100;


            if (Stud_Per >= 50.00)
            {
                Stud_Result = "Pass";
            }
            else
            {
                Stud_Result = "Fail";
            }

        markss1:
            Console.Write("Enter Stud_Theory: ");
            int marks1 = Convert.ToInt32(Console.ReadLine());
            if (marks <= 50)
            {
                Stud_Theory = marks1;
            }
            else
            {
                Console.WriteLine("Enter marks out of 50... ");
                goto markss1;
            }

            Stud_Per = (Convert.ToDouble(Stud_Theory) / 50) * 100;


            if (Stud_Per >= 50.00)
            {
                Stud_Result = "Pass";
            }
            else
            {
                Stud_Result = "Fail";
            }

        markss2:
            Console.Write("Enter Stud_Practical: ");
            int marks2 = Convert.ToInt32(Console.ReadLine());
            if (marks <= 50)
            {
                Stud_Practical = marks2;
            }
            else
            {
                Console.WriteLine("Enter marks out of 50... ");
                goto markss2;
            }

            Stud_Per = (Convert.ToDouble(Stud_Practical) / 50) * 100;


            if (Stud_Per >= 50.00)
            {
                Stud_Result = "Pass";
            }
            else
            {
                Stud_Result = "Fail";
            }

            Console.WriteLine("========================================================================================");
            Console.WriteLine("Calculate percentage");
            Console.WriteLine("========================================================================================");
            Total = Stud_COMMUNICATIONSKILL + Stud_Theory + Stud_Practical;


            Student student = new Student()
            {
                Stud_ID = Stud_ID,
                Stud_FirstName = Stud_FirstName,
                Stud_LastName = Stud_LastName,
                Stud_Address = Stud_Address,
                Stud_Batch = Stud_Batch,
                Stud_Trainer = Stud_Trainer,
                Stud_COMMUNICATIONSKILL = Stud_COMMUNICATIONSKILL,
                Stud_Theory = Stud_Theory,
                Stud_Practical = Stud_Practical,
                Total = Total,
                Stud_Per = Stud_Per,
                Stud_Result = Stud_Result
             };

            return student;
        }


    }
}
