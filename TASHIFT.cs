using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Knuth - Morris - Pratt (KMP algorithm)

namespace MMT_Elitmus
{
    class TASHIFT
    {
        static void Maina(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string A =  Console.ReadLine();
            string B =  Console.ReadLine();

            int indexA = 0;
            int CPL = -1;
            int MPIS = -1;
            int GMPIS = -1;

            A = A + 'p';
            B = B + B[0] + 'l';
            bool trackBack=false;
            int iToStart = -1;
            int subIToStart = -1;
            int subIndexA = 0;
            int subIToStartInitial = -1;

            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] == A[indexA])
                {
                    if (MPIS == -1)
                    {
                        MPIS = i;
                    }
                    else if (!trackBack && B[i] == A[0])
                    {
                        subIToStartInitial = i;
                        iToStart = i;
                        trackBack = true;
                        subIToStart = 0;
                        subIToStart++;
                        subIndexA++;
                    }
                    else if (trackBack)
                    {
                        if (B[i] == A[subIToStart])
                        {
                            subIToStart++;
                            subIndexA++;
                        }
                        else
                        {
                            trackBack = false;
                            subIToStart = -1;
                            subIndexA = 0;
                            subIToStartInitial = -1;
                        }
                    }
                    
                    indexA++;
                }
                else
                {
                    if (indexA > CPL)
                    {
                        GMPIS = MPIS;
                        CPL = indexA;                        
                    }
                    if (iToStart != -1 && trackBack)
                    {
                        i--;
                        trackBack = false;
                        indexA = subIndexA;
                        MPIS = subIToStartInitial;
                        continue;
                    }
                    else if(MPIS !=-1)
                    {
                        i--;
                    }
                    indexA = 0;
                    MPIS = -1;
                    trackBack = false;

                    subIToStart = -1;
                    subIndexA = 0;
                    subIToStartInitial = -1;
                }
            }
            if (GMPIS == -1)
                GMPIS = 0;
            Console.WriteLine(GMPIS);

        }
    }
}
