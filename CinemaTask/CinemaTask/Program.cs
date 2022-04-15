using System;
using System.Data;
using System.Data.SqlClient;

namespace CinemaTask
{
    class Program
    {
        private static string connectionString = @"Server = DESKTOP-29JJS7D\WINCC;Database = Cinema;Trusted_Connection = True;";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //GetActorsInfo();
            //CreateActors("Vusal", "Abdurahmanov", 20);
            //DeleteActors(7);
            //GetGenresInfo();
            //CreateGenres("fdfhfg");
            //DeleteGenres(8);
            //GetFilmsInfo();
            //CreateFilms("sagsfg", "2022.04.13");
            //DeleteFilms(7);
            GetFilmsGenresInfo();
        }
        static void GetActorsInfo()
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Actors";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["Name"]} {dr["Surname"]} {dr["Age"]}");
                    }
                }
            }
        }
        static void CreateActors(string Name, string Surname, int Age)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Actors VALUES (N'{Name}', N'{Surname}', N'{Age}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Actors create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }
        static void DeleteActors(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Actors WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Actors deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }
        static void GetGenresInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Genres";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["Name"]}");
                    }
                }
            }
        }
        static void CreateGenres(string Name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Genres VALUES (N'{Name}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if(comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Genres create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteGenres (int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Genres WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Genres deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetFilmsInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Films";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["Name"]} {dr["RelaseDate"]}");
                    }
                }
            }
        }

        static void CreateFilms(string Name, string RelaseDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Films VALUES (N'{Name}', N'{RelaseDate}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Films create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteFilms(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Films WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Films deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetFilmsGenresInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM FilmsGenres";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["FilmsId"]} {dr["GenresId"]}");
                    }
                }
            }
        }


    }
}
