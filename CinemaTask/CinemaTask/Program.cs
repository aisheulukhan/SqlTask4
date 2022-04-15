using System;
using System.Data;
using System.Data.SqlClient;

namespace CinemaTask
{
    class Program
    {
        private static string connectionString = @"Server = 213-17;Database = Cinema;Trusted_Connection = True;";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            //GetActorsInfo();
            //CreateActors("Vusal", "Abdurahmanov", 20);
            //DeleteActors(7);
            //UpdateActors();
            //GetGenresInfo();
            //CreateGenres("fdfhfg");
            //DeleteGenres(8);
            //GetFilmsInfo();
            //CreateFilms("sagsfg", "2022.04.13");
            //DeleteFilms(7);
            //GetFilmsGenresInfo();
            //CreateFilmsGenres(6,6);
            //UpdateFilmsGenres(5,6,10);
            //GetFilmsActorsInto();
            //CreateFilmsActors(6,7);
            //DeleteFilmsActors(6);
            //GetCustomersInto();
            //CreateCustomers("fgdgdg", "dgdggd", 45);
            //DeleteCustomers(7);
            //GetHallsInfo();
            //CreateHalls("Zal 7", 50);
            //DeleteHalls(7);
            //GetSessionsInfo();
            //CreateSessions("15:37:59");
            //DeleteSessions(7);
            //GetTickestInfo();
            //CreateTickests("2012-04-12 13:20:00", 20.30, 40, 7, 7, 7, 7);
            //DeleteTickest(6);
            //BuyTickest(3,3,3,3);
            GetBuyTickestInfo();

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
        static void UpdateActors(string Name, string Surname, int Age, int Id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string command = $"UPDATE FilmsGenres SET Name ='{Name}', Surname ='{Surname}', Surname ='{Age}'  WHERE Id = '{Id}' ";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("FilmsGenres Update");
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
        static void CreateFilmsGenres(int FilmsId, int GenresId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO FilmsGenres VALUES (N'{FilmsId}', N'{GenresId}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("FilmsGenres create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }
        static void UpdateFilmsGenres(int FilmsId, int GenresId,  int FilmsGenresId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                string command = $"UPDATE FilmsGenres SET FilmsId ='{FilmsId}', GenresId ='{GenresId}' WHERE Id = '{FilmsGenresId}' ";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("FilmsGenres Update");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetFilmsActorsInto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM FilmsActors";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["FilmsId"]} {dr["ActorsId"]}");
                    }
                }
            }
        }

        static void CreateFilmsActors(int FilmsId, int ActorsId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO FilmsActors VALUES (N'{FilmsId}', N'{ActorsId}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("FilmsActors create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteFilmsActors(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE FilmsActors WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("FilmsActors deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetCustomersInto()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Customers";
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

        static void CreateCustomers(string Name, string Surname, int Age)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Customers VALUES (N'{Name}', N'{Surname}', N'{Age}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Customers create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteCustomers(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Customers WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Customers deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetHallsInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Halls";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["Name"]} {dr["SeatCount"]}");
                    }
                }
            }
        }
        static void CreateHalls(string Name, int SeatCount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Halls VALUES (N'{Name}', '{SeatCount}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Halls create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteHalls(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Halls WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Halls deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetSessionsInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM [Sessions]";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["Time"]} ");
                    }
                }
            }
        }

        static void CreateSessions( string Time)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Sessions VALUES (N'{Time}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Sessions create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteSessions(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Sessions WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Sessions deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void GetTickestInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM Tickest";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["SoldDate"]} {dr["Price"]} {dr["Place"]} {dr["CustomersId"]} {dr["HallId"]} {dr["FilmId"]} {dr["SessionsId"]}");
                    }
                }
            }
        }

        static void CreateTickests(string TimeSoldDate, double Price, int Place, int CustomersId, int HallId, int FilmId, int SessionsId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Tickest VALUES (N'{TimeSoldDate}', N'{Price}', N'{Place}' , N'{CustomersId}' , N'{HallId}', N'{FilmId}', N'{SessionsId}'  )";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Tickest create");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void DeleteTickest(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Tickest WHERE Id ={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Tickest deleted");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
            }
        }

        static void BuyTickest(int HallId, int SessionsId, int FilmId, int CustomerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand("EXEC usp_BuyTicket", conn);
                
                conn.Open();
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["HallId"] + ",  " + sdr["SessionsId"] + ",  " + sdr["FilmId"] + ",  " + sdr["CustomerId"]);
                }

            }
        }
        static void GetBuyTickestInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = "SELECT * FROM BuyTickest";
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]} {dr["HallId"]} {dr["SessionsId"]} {dr["FilmId"]} {dr["CustomersId"]} {dr["HallId"]}");
                    }
                }
            }
        }

    }
}
