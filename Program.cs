/*
Sieve of Eratosthenes from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-03

Sieve of Eratosthenes is one of the most efficient algorithms for finding all prime numbers less than a given number. 
A prime is a number which is not divisible by any number except 1 and itself. 

The Algorithm 
The algorithm iteratively marks as not prime the multiples of each prime, starting with the first prime number, 2. 
Here are the steps for finding all primes less than n: 
1. List out all the numbers from 2 to n. 
2. The first number of the list is a prime, take it as p. 
3. Remove all the multiples of p from the list (2p, 3p, etc.). p itself should not be removed. 
4. Find the first number greater than p in the list. If there was no such number, stop. Otherwise, let p now equal this new number (which is the next prime), and repeat from step 3. 
5. When the algorithm terminates, the numbers remaining in the list are all the primes below n. 

An Example 87
Let's demonstrate the algorithm and find all primes less than 10: 
1. List out all the numbers from 2 to 10:  
List = [2 3 4 5 6 7 8 9 10] 
2. The first number (2) is a prime. 
3. Remove all the multiples of 2: 
List = [2 3 5 7 9] 
4. Take the next number => 3. 
5. Remove all the multiples of 3: 
List = [2 3 5 7] 
6. Take the next number => 5. 
7. Remove all the multiples of 5: 
List = [2 3 5 7] 
6. Take the next number => 7. 
7. Remove all the multiples of 7: 
List = [2 3 5 7] 
8. No more numbers left. All the primes are in the List.  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes
{
    class Program
    {
        static int endNumber = 1000; // Insert last number
        static int[] numbers;

        static void Main(string[] args)
        {
            InitList();

            int p = 2;

            while (true)
            {
                RemoveMultipleOf(p);

                p = FindNext(p);

                if (p == -1) break;
            }

            PrintList();
        }

        static void InitList()
        {
            numbers = new int[endNumber + 1];

            for (int i = 0; i <= endNumber; i++)
            {
                numbers[i] = i;
            }
        }

        static void RemoveMultipleOf(int p)
        {
            for (int i = 2; i <= (endNumber / p); i++)
            {
                numbers[p * i] = -1;
            }
        }

        static int FindNext(int p)
        {
            for (int i = p+1; i <= endNumber; i++)
            {
                if (numbers[i] != -1) return i;
            }

            return -1;
        }

        static void PrintList()
        {
            string s = String.Empty;

            for (int i = 2; i <= endNumber; i++)
            {
                if (numbers[i] != -1) s += numbers[i] + " ";
            }

            Console.WriteLine($"List of prime numbers less than {endNumber} = [{s.TrimEnd(' ')}]");
        }
    }
}