using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        public static void Main()
        {
            //find out the prime numbers between 5 and 15
            Console.WriteLine("1. find out the prime numbers between 5 and 15 :");
            int a = 5, b = 25;
            printPrimeNumbers(a, b);

            //Print the output for the series:
            Console.WriteLine(); // add a new line -- end of first requirement
            Console.WriteLine("=============================");
            Console.WriteLine("2. Calculating series for 5 terms: 1/2 – 2!/3 + 3!/4 – 4!/5"); 
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);

            Console.WriteLine("=============================");
            Console.WriteLine("3. Converting decimal to Binary: 15 -> 1111");
            //Converting 15 to binary: 1111
            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);

            Console.WriteLine("=============================");
            Console.WriteLine("4. Converting  Binary to Decimal : 1111 -> 15");
            //Convert binary to decimal: 1111 -> 15
            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);

            Console.WriteLine("=============================");
            Console.WriteLine("5. Printing triangle..");
            //Print the triangle in 5 lines
            int n4 = 5;
            printTriangle(n4);

            Console.WriteLine("=============================");
            Console.WriteLine("6. Computing frequency of numbers in an array");
            //Print the number of times that the number appears in an array
            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            // write your self-reflection here as a comment
            /**
             * Learning: I have always computed the frequency of elements using dictionaries, as they are simple and easy to use, in 
             * this assignment, I have learned to make use of the same array to do the calculations without using any temporary  
             * place holder. 
             * Recommendation: We could have assignments having more methods focussing on arrays , different data types with
             * array: array of strings, double,finding the lower/upper bound etc,prime numbers in an array for comfort in use of arrays.
             *  
             **/

            Console.WriteLine("Press any key to exit ..");
            Console.ReadKey();

        } // End of Main

        /**Method to print all the prime numbers between the specified limits
           Input: x: lower limit , y: upper limit **/
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                //Invalid conditions : if the lower limit exceeds upper boundary limit 
                if (x > y)
                {
                    Console.WriteLine("No Prime Numbers !! Sorry!!!");
                    return;
                }
                else
                {
                    Boolean bPrime = true;
                    //Iterate from the lower to upper bounds
                    for (int i = x; i <= y; i++)
                    {
                        bPrime = true;

                        //case when the lower limit is 1
                        if (i <= 1)
                        {
                            bPrime = false;
                        }
                        //2 , 3 are both prime
                        else if( i <= 3)
                        {
                            bPrime = true;
                        }
                        else
                        {
                            //verify if the number is only divisible by 1 and itself by checking its divisibility 
                            //with respect to the numbers in between
                            for (int j = 2; j < i ; j++)
                            {
                                if (i % j == 0)
                                {
                                    bPrime = false;
                                    break;
                                }
                            }
                        }
                        if(bPrime == true)
                        {
                            Console.Write(i.ToString() + " ");
                        }
                    }
                }
            }//ENd of try
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }//End of catch
        }

        /**Method to print the series from 1 to the limit specified
           Input: n: desired number in the series 
           Output: the calculated results for n terms **/
        public static double getSeriesResult(int n)
        {
            double result = 0.000;
            double div, term;
            try
            {
                // iterate till the number of terms required.
                for (int i = 1; i <= n; ++i)
                {
                    div = i + 1;
                    //find out the individual term
                    term = factorial(i) / div;
                    //if term is even subtract else add the term to the final result
                    if (i % 2 == 0)
                    {
                        result -= term;
                    }
                    else
                    {
                        result += term;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return Math.Round(result, 3);
        }
        
        /**Method to calculate the factorial of a number
           Input: n: number to find the factorial
           Output: factorial: n! **/
        private static int factorial(int n)
        {
            int result = n;
            try
            {
                //0! = 1! = 1
                if (n == 0 || n == 1)
                {
                    return result;
                }
                else
                {
                    //iterate from n-1 to 1 to get the factorial.
                    for(int i = n - 1; i > 1; i--)
                    {
                        result *= i;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing factorial()");
            }
            return result;
        }

        /**Method to convert the number into binary format
           Input: n: decimal number
           Output: binary equivalent **/
        public static long decimalToBinary(long n)
        {
            try
            {
                //0, 1 binary equivalent remains the same
                if( n == 0 || n == 1)
                {
                    return n;
                }
                else
                {
                    long quot = n;
                    string remStr = ""; // remainder string: to store the remainders in each iteration
                    long res;

                    while(quot > 0)
                    {
                        //add the remainder to the previous result
                        remStr = (quot % 2).ToString() + remStr;
                        //continue for next digit
                        quot = quot / 2;
                    }

                    //parse the final result in long from string , return 0 if nothing is found
                    if (remStr != "")
                        res = long.Parse(remStr);
                    else
                        res = 0;

                    return res;
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        /**Method to convert the binary number into decimal format
          Input: n: binary number
          Output: decimal equivalent **/
        public static long binaryToDecimal(long n)
        {
            try
            {
                //temp number to extract the individual digits
                long quot = n;
                //multiplier: base : binary 2, res: output
                long multiplier = 1, res = 0;
                long temp = 0;
                while(quot > 0)
                {
                    temp = quot % 10; //extract the last digit
                    res += temp * multiplier;
                    // multiply by 2 to raise the power of binary base 2
                    multiplier *= 2;
                    quot = quot / 10;
                }

                return res;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        /**Method to print a triangle pattern for the number of lines specified
          Input: n: desired number of lines **/
        public static void printTriangle(int n)
        {
            try
            {
                int numStars = 1; // need to print odd number of stars
                for (int i = 1; i <= n; i++)
                {
                    //print spaces 
                    for (int k = i; k < n; k++)
                    {
                        Console.Write(" ");
                    }
                    //Print *
                    for (int j = 1; j <= numStars; j++)
                    {
                        Console.Write("*");
                    }
                    //Print odd number of stars
                    numStars += 2;
                    Console.WriteLine();
                }

            }//End of try
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }//End of catch
        }

        /**Method to calculate the frequency of number in an array
          Input: a: array of integers **/
        public static void computeFrequency(int[] a)
        {
            try
            {
                if(a.Length == 0)
                {
                    Console.WriteLine("Please input some elements in the array!!");
                }
                else
                {
                    int n = a.Length;
                    //Let arr[i] % n = index, add n, each time we encounter a duplicate
                    for (int i = 0; i < n; i++)
                    {
                        a[a[i] % n] = a[a[i] % n] + n;
                    }

                    Console.WriteLine("Number" + "\t" + "Frequency");
                    for (int i = 1; i < n; i++)
                    {
                        //Print all the elements that have atleast one count
                        if ((a[i] / n) > 0)
                        {
                            Console.WriteLine(i + "\t" + a[i] / n);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
    }
}

