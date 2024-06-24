using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        private readonly static string connectionString = "Server=DESKTOP-NIJAT;Database=DMA03;Integrated Security = true";
        private readonly static SqlConnection connection = new SqlConnection(connectionString);
        static void Main(string[] args)
        {
            //1)Setup and Connection:
            //Create a simple database with one table(e.g., Persons with columns Id, Name, and Age).

            //Write a C# console application that connects to the database using ADO.NET.
            //Basic Select Query:
            //Extend the application to execute a SELECT query to retrieve all rows from the Persons table.
            //Display the results in the console.

            //Insert Data:
            //Write a method in the console application to insert a new student into the Persons table.
            //Prompt the user to enter the student's name and age, then save it to the database.

            //Parameterized Queries:
            //Modify the insert method to use parameterized queries to prevent SQL injection.
            //Ensure the user inputs are correctly handled and inserted into the database.

            //Medium
            //Update Data:
            //Write a method to update the age of a person given their Id.
            //Use parameterized queries for this operation.

            //Delete Data:
            //Write a method to delete a student record based on the Id.
            //Confirm the deletion with the user before executing it.


            string Menu = "1.Insert Person\n" +
                "2.Update Person\n" +
                "3.Delete Person\n" +
                "4.Show All Persons\n" +
                "5.Show Person by Id\n" +
                "6.Exit";

            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine(Menu);
                Console.Write("Enter Oper. Number:");
                int.TryParse(Console.ReadLine(), out int ope);
                Console.Clear();

                switch (ope)
                {
                    case 1:
                        Console.Write("Enter name:");
                        string name = Console.ReadLine();
                        Console.Write("Age:");
                        int.TryParse(Console.ReadLine(), out int age);
                        InsertData(name, age);
                        break;
                    case 2:
                        Console.Write("Enter Id:");
                        int.TryParse(Console.ReadLine(), out int id);
                        Console.Write("Enter name:");
                        name = Console.ReadLine();
                        Console.Write("Age:");
                        int.TryParse(Console.ReadLine(), out age);
                        UpdateData(id, name, age);
                        break;
                    case 3:
                        Console.Write("Enter Id:");
                        int.TryParse(Console.ReadLine(), out id);
                        DeleteData(id);
                        break;
                    case 4:
                        ShowDatas();
                        break;
                    case 5:
                        Console.Write("Enter Id:");
                        int.TryParse(Console.ReadLine(), out id);
                        ShowData(id);
                        break;
                    case 6:
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Enter valid operation number");
                        break;
                }
            }
        }
        public static void InsertData(string name, int age)
        {

            string cmdText = $"Insert into Persons Values('{name}',{age})";


            SqlCommand command = new SqlCommand(cmdText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        public static void ShowDatas()
        {
            string cmdText = "Select * from Persons";
            SqlCommand command = new SqlCommand(cmdText, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID:{reader["Id"]}  Name:{reader["Name"]}  Age:{reader["Age"]}");
            }
            connection.Close();

        }
        public static void UpdateData(int id, string name, int age)
        {
            string cmdText = $"Update Persons Set Age ={age} ,Name='{name}' Where Id ={id}";

            SqlCommand command = new SqlCommand(cmdText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        public static void DeleteData(int id)
        {
            string cmdText = $"Delete from Persons Where Id ={id}";

            SqlCommand command = new SqlCommand(cmdText, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
        public static void ShowData(int id)
        {
            string cmdText = $"Select * from Persons Where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID:{reader["Id"]}  Name:{reader["Name"]}  Age:{reader["Age"]}");
            }
            connection.Close();

        }
    }
}
