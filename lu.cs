using System;

namespace LuDecomposition
{
    class Program
    {
        static void LUdecomposition(float[,] a, float[,] l, float[,] u, int n)
        {
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i <= j)
                    {
                        u[i, j] = a[i, j];
                        for (int k = 0; k <= i - 1; k++)
                            u[i, j] -= l[i, k] * u[k, j];
                        if (i == j)
                            l[i, j] = 1;
                        else
                            l[i, j] = 0;
                    }
                    else
                    {
                        l[i, j] = a[i, j];
                        for (int k = 0; k <= j - 1; k++)
                            l[i, j] -= u[i, k] * l[k, j];
                        l[i, j] /= u[j, j];
                        u[i, j] = 0;
                    }
                }
            }
        }
        static void Lu()
        {
            float[,] a = new float[10, 10];
            float[,] l = new float[10, 10];
            float[,] u = new float[10, 10];
            float[] b = new float[10];
            float[] x = new float[10];
            float[] y = new float[10];
            int n, i, j;

            Console.WriteLine("YOU SELECTED [1] LU Decomposition Solver\n");
            Console.Write("Enter size of square Matrix A: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("Enter element a[" + (i + 1) + "," + (j + 1) + "]:");
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Write("\nEnter the constant terms: ");
            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                Console.Write("B[" + (i + 1) + "]", i);
                b[i] = Convert.ToInt32(Console.ReadLine());
            }

            LUdecomposition(a, l, u, n);
            Console.WriteLine("\nMatrix A:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nL Decomposition:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{l[i, j]:0.#}" + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("\nU Decomposition:");

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{u[i, j]:0.#}" + " ");
                }
                Console.WriteLine();
            }

            for (i = 0; i < n; i++)
            {
                y[i] = b[i];
                for (j = 0; j < i; j++)
                {
                    y[i] -= l[i, j] * y[j];
                }
            }
            Console.WriteLine("\n[Y]: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("Y" + (i + 1) + ":");
                Console.WriteLine($"{y[i]:0.#}");
            }
            for (i = n - 1; i >= 0; i--)
            {
                x[i] = y[i];
                for (j = i + 1; j < n; j++)
                {
                    x[i] -= u[i, j] * x[j];
                }
                x[i] /= u[i, i];
            }
            Console.WriteLine("\n[X]: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("X" + (i + 1) + ":");
                Console.WriteLine($"{x[i]:0.#}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNote: If the value is NaN (Not a Number), there is no solution.");
        }
        static void AboutLu()
        {
            Console.WriteLine("\nYOU SELECTED [2] About the LU Decomposition\n");
            Console.WriteLine("Lower-Upper (LU) decomposition factors a matrix as the product of
            lower triangular matrix and ");
            Console.WriteLine(" an upper triangular matrix.It was introduced by Polish
            mathematician Tadeusz Banachiewicz in 1938.");
        }
        static void AboutAuthor()
        {
            Console.WriteLine("\nYOU SELECTED [3] About the Author\n");
            Console.WriteLine("This program is created by:\n vitamin-abc");
        }
        static void Menu()
        {
            string choice;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\n======== LU DECOMPOSITION ========\n");
            Console.Write("\n============== MENU ==============\n\n[1] LU Decomposition
            Solver\n[2] About the LU Decomposition\n[3] About the Author\n[4] Exit\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nCHOICE: ");
            Console.ResetColor();
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Lu();
                    validation();
                    break;
                case "2":
                    Console.Clear();
                    AboutLu();
                    validation();
                    break;
                case "3":
                    Console.Clear();
                    AboutAuthor();
                    validation();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("YOU SELECTED [4] Exit\n");
                    Console.WriteLine("Thank you for using the program");
                    Console.ReadKey();
                    break;
                default: //VALIDATION
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Error! '{choice}' is an invalid choice. Please select
                    again.".PadRight(Console.WindowWidth));
                    Console.ResetColor();
                    Menu();
                    break;
            }
        }
        static void validation()
        {
            string mainchoice;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n[1] Back to Menu [2] Exit program\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nCHOICE: ");

            mainchoice = Console.ReadLine();

            switch (mainchoice)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("YOU SELECTED [2] Exit\n");
                    Console.WriteLine("Thank you for using the program");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Error! '{mainchoice}' is an invalid choice. Please select
                    again.".PadRight(Console.WindowWidth));
                    Console.ResetColor();
                    validation();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}