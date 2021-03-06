﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBarld.ProjectEuler
{
    public class Problem12 : IProblem
    {
        public string ProblemDescription => @"The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

Let us list the factors of the first seven triangle numbers:

 1: 1
 3: 1,3
 6: 1,2,3,6
10: 1,2,5,10
15: 1,3,5,15
21: 1,3,7,21
28: 1,2,4,7,14,28
We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?";

        public long GetAnswer()
        {
            int triangle = 0;
            int diviserscoumt = 0;
            for (UInt16 i = 1;diviserscoumt<500 ; i++)
            {
                triangle += i;
                diviserscoumt = 0;
                int sqrt = (int)Math.Sqrt(triangle);
                if (sqrt * sqrt == triangle)
                    diviserscoumt--;
                if (triangle%2==0)
                    for (int j = 1; j <= sqrt; j++)
                    {
                        if (triangle % j == 0)
                            diviserscoumt += 2;
                    }
                else
                    for (int j = 1; j <= sqrt; j+=2)
                    {
                        if (triangle % j == 0)
                            diviserscoumt += 2;
                    }
            }
            return (long)triangle;
        }

        public long GetAnswer2()
        {
            long triangle = 0;
            for (int i = 1; ; i++)
            {
                triangle += i;
                int diviserscoumt = 0;
                int sqrt = (int)Math.Sqrt(triangle);
                for (long j = sqrt; j > 0; j--)
                {
                    if (triangle % j == 0)
                        diviserscoumt+=2;
                }
                if (sqrt * sqrt == triangle)
                    diviserscoumt--;
                if (diviserscoumt > 500)
                    return triangle;
            }
        }

        /// <summary>
        /// methode werkt maar heeft erg slechte performance
        /// </summary>
        /// <returns></returns>
        public long GetAnswer3()
        {
            long triangle = 0;
            for (int i = 1; ; i++)
            {
                triangle += i;
                int diviserscoumt = 1;
                for (long j = triangle / 2; j > 0; j--)
                {
                    if (triangle % j == 0)
                        diviserscoumt++;
                }
                if (diviserscoumt > 500)
                    return triangle;
            }
        }
    }
}
