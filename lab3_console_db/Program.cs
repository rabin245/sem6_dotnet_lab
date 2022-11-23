using MySql.Data.MySqlClient;
using System;

namespace ConsoleDB
{
    class Program
    {
        static string conStr = "server=localhost;user=late;password=Sqlp@ssw0rd;database=sem6_dotnet;port=3306";

        static void Main(string[] args)
        {
            string name, email;
            int choice;


            while (true) { 
                Console.WriteLine("\nEnter option:\n1: Add record\n2: List records\n3: Exit\n");
                choice = Convert.ToInt32(Console.ReadLine());
                
                if (choice == 1)
                {
                    Console.Write("Enter name:\t");
                    name = Console.ReadLine();
                    Console.Write("Enter email:\t");
                    email = Console.ReadLine();

                    EnterRecords(name, email);
                }
                else if (choice == 2)
                {
                    ListRecords();
                }
                else if (choice == 3)
                {
                    break;
                }
                
            }

        }
        public static void ListRecords()
        {
            var sql = "SELECT * FROM consoleappdb_table";

            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                Console.WriteLine("\nid\t|name\t\t|email\t|");
                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr[0]}\t|{rdr[1]}\t\t|{rdr[2]}\t|");
                }
                rdr.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            conn.Close();
        }

        public static void EnterRecords(string name, string email)
        {
            var sql = "INSERT INTO consoleappdb_table (name, email) " +
            $"VALUES ('{name}', '{email}')";
            MySqlConnection conn = new MySqlConnection(conStr);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records added successfully.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            conn.Close();
        }
    }


}