using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Not solved
namespace MMT_Elitmus
{
    class CHEFTET
    {
        static string[] B = null;
        static string[] A = null;
        static void Main1(string[] srgs)
        {
            int t = Convert.ToInt32(Console.ReadLine());
         
            while (t-- > 0)
            {
                 B = Console.ReadLine().Split(' ');
                 A = Console.ReadLine().Split(' ');

                 Dictionary<string, int> possiblevals = new Dictionary<string, int>();

                for (int i = 0; i < A.Length; i++)
                {
                    if (i == 0)
                    {
                        possiblevals.Add("AboveRight", Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]) + Convert.ToInt32(B[i + 1]));
                        possiblevals.Add("Alone", Convert.ToInt32(A[i]));
                        possiblevals.Add("Above", Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]));
                        possiblevals.Add("Right", Convert.ToInt32(A[i]) + Convert.ToInt32(B[i + 1]));
                    }
                    if (i == A.Length - 1)
                    {

                    }
                    else
                    {
                        Dictionary<string, int> Newpossiblevals = new Dictionary<string, int>();
                        List<string> valsToDelete = new List<string>();
                        foreach (var item in possiblevals)
                        {
                            switch(item.Key)
                            {
                                case "AboveRight":
                                    int f = addRightElement(i);
                                    if (f == item.Value)
                                    {
                                        Newpossiblevals.Add("Right", item.Value);
                                        valsToDelete.Add("AboveRight");
                                    }
                                    if (item.Value == Convert.ToInt32(A[i]))
                                    {
                                       // Newpossiblevals.Add("Alone", item.Value);
                                       // valsToDelete.Add("AboveRight");
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        static int addAboveElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]);
        }
        static int addLeftElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i -1]);
        }
        static int addLeftAboveElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]) + Convert.ToInt32(B[i - 1]);
        }
        static int addRightElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i + 1]);
        }
        static int addRightAboveElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]) + Convert.ToInt32(B[i + 1]);
        }
        static int addLeftRightAboveElement(int i)
        {
            return Convert.ToInt32(A[i]) + Convert.ToInt32(B[i]) + Convert.ToInt32(B[i + 1]) + Convert.ToInt32(B[i - 1]);
        }
    }
}
