using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class codeJamDiceStraight
    {
        public static void Main()
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\ja13\Desktop\DEE_Output\output.txt");
            StreamReader reader = new StreamReader(@"C:\Users\ja13\Desktop\DEE_Output\A-large-practice.in"); //A-small-practice.in    input.txt
            int cases = Convert.ToInt32(reader.ReadLine());
            int caseNumber = 1;
            string[,] matrix = null;
            while (cases > 0)
            {
                List<int> rc = reader.ReadLine().Split(' ').Select(t => int.Parse(t.ToString())).ToList<int>();
                int r = rc[0];
                int c = rc[1];
                int l = 0;
                matrix = new string[r, c];
                string[] startingRowsCharacter = new string[r];
                string[] startingColumnsCharacter = new string[c];
                int[] colsRowsIndex = new int[c];
                while (l < r)
                {
                    string[] line = reader.ReadLine().ToCharArray().Select(t => t.ToString()).ToArray();
                    for (int ke = 0; ke < c; ke++)
                    {
                        matrix[l, ke] = line[ke];
                    }
                    l++;
                }
                matrix = SolveRows(matrix, r, c);
                matrix = SolveColumns(matrix, r, c);
                Console.WriteLine("Case #" + caseNumber + ":");
                writer.WriteLine("Case #" + caseNumber + ": ");
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        if (j == c - 1)
                        {
                            Console.WriteLine(matrix[i, j]);
                            writer.WriteLine(matrix[i, j]);
                        }
                        else
                        {
                            Console.Write(matrix[i, j]);
                            writer.Write(matrix[i, j]);
                        }
                    }
                }
                caseNumber++;
                cases--;
            }
            writer.Flush();
            writer.Close();
            reader.Close();
            Console.ReadLine();
        }

        public static string[,] SolveRows(string[,] matrix, int r, int c)
        {
            for (int i = 0; i < r; i++)
            {
                bool repeatQuestions = false;
                bool isChar = false;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] == "?")
                    {
                        if (j > 0 && matrix[i, j - 1] != "?")
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                        else
                        {
                            repeatQuestions = true;
                        }
                    }
                    else
                    {
                        isChar = true;
                    }
                }
                if (isChar && repeatQuestions)
                {
                    for (int j = c - 1; j >= 0; j--)
                    {
                        if (j < c - 1 && matrix[i, j] == "?")
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                    }
                }
            }
            return matrix;
        }

        private static string[,] SolveColumns(string[,] matrix, int r, int c)
        {
            for (int j = 0; j < c; j++)
            {
                bool repeat = false;
                for (int i = 0; i < r; i++)
                {
                    if (matrix[i, j] == "?")
                    {
                        if (i > 0 && matrix[i - 1, j] != "?")
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                        else 
                        {
                            repeat = true;
                        }
                    }
                }
                if (repeat)
                {
                    for (int i = r - 1; i >= 0; i--)
                    {
                        if (i < r - 1 && matrix[i, j] == "?")
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
