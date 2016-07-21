using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace fibonacci
{
    class Program
    {
        public static int fibo(int x)
        {
            if (x == 0)
                return 0;
            if (x < 2)
                return 1;
            return fibo(x - 1) + fibo(x - 2);
        }

        public static int tribo(int x)
        {
            return 0;
        }

        public static int tetra(int x)
        {
            return 0;
        }

        public static void tablica(int x)
        {
            int[] tab = new int[x + 1];
            if (x == 0)
            {
                tab[0] = 0;
            }
            if (x == 1)
            {
                tab[0] = 0;
                tab[1] = 1;
            }
            if (x > 1)
            {
                tab[0] = 0;
                tab[1] = 1;
                for (int i = 2; i <= x; i++)
                {
                    tab[i] = tab[i - 1] + tab[i - 2];
                }
            }
            Console.WriteLine("kolejne wyrazy ciagu:");
            for (int i = 0; i <= x; i++)
            {
                Console.WriteLine(i + ": " + tab[i]);
            }
        }

        public static int silnia(int x)
        {
            if (x == 0)
                return 1;
            return x * silnia(x - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 - ciag fibonacciego");
            Console.WriteLine("2 - silnia");
            Console.WriteLine("3 - logowanie do bazy");
            int znak;
            znak = int.Parse(Console.ReadLine());
            switch (znak)
            {
                case 1:
                    {
                        Console.Write("Podaj element ciągu: ");
                        int n = int.Parse(Console.ReadLine());
                        if (n >= 0)
                        {
                            int w = fibo(n);
                            Console.WriteLine(w);
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }
                        tablica(n); ;
                        break;
                    }
                case 2:
                    {
                        Console.Write("Podaj n: ");
                        int n = int.Parse(Console.ReadLine());
                        int sil = silnia(n);
                        Console.WriteLine(sil);
                        break;
                    }
                case 3:
                    {
                        Console.Write("login: ");
                        string login = Console.ReadLine();
                        Console.Write("hasło: ");
                        string haslo = Console.ReadLine();
                        try
                        {
                            using (SqlConnection conn = new SqlConnection())
                            {
                                conn.ConnectionString = "Server=dev.pwste.edu.pl;Database=db0119;User Id=s30807;Password = admin; ";
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("SELECT * FROM ICK where login='" + login + "' and haslo='" + haslo + "'");
                                cmd.Parameters.Add(new SqlParameter("0", 1));
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}", reader[0], reader[1], reader[2], reader[3]));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }
                default:
                    Console.WriteLine("## 22wqe2abbss");
                    Console.WriteLine("#weq2d");

                    break;
            }

            Console.Read();
        }

    }
}