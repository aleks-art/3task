using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace _3task
{
    class Program
    {
//public static RandomNumberGenerator rngCsp = new RandomNumberGenerator();
        static void Main(string[] args)
        {
            int num = 0;
            string text = Console.ReadLine();
            string[] textArray = text.Split(new char[] { ' ' });

            for (int i = 0; i < textArray.Length; i++)
            {
                for (int j = i + 1; j < textArray.Length; j++)
                {
                    if ((textArray[i].Length == textArray[j].Length))
                    {
                        string a = textArray[i];
                        string b = textArray[j];
                        stringcomp(ref num, a, b);
                    }
                }
            }
            stringcheck(ref num, textArray.Length);
            if (num > 0)
            {
                Environment.Exit(0);
            }
            Random rnd = new Random();
            string hex="";
            int u = 0,us;
        ret:
            u = rnd.Next(0, textArray.Length);
            string l = textArray[u];
            var r = RandomNumberGenerator.Create();
            var data = new byte[4];
            r.GetBytes(data);
            var p = BitConverter.ToString(data).Replace("-", string.Empty).ToLower();
            RNG(ref hex,l,p);
            Console.WriteLine("HMAC : "+hex);
            massiv(textArray);
            Console.Write("Выберите ваш ход: ");
           us = Convert.ToInt32(Console.ReadLine());
            if (us > textArray.Length) {
                Console.WriteLine("Вы сделали не правильный выбор");
                goto ret; }
            if (us == 0) { Environment.Exit(0); }
            if (textArray[us - 1] == textArray[u])
            {
                Console.WriteLine("Ничья");
                goto ret;
            }
            game(us, u, textArray);
            u = u + 1;
            Console.WriteLine("Ход компьютера : " + u);
            Console.WriteLine("Hmac key : " + p);
            goto ret;
            Console.ReadKey();
        }
        public static void game(int us,int u, String [] array)
        {
            int modarray,i;
            us = us - 1;
            modarray = array.Length / 2;
            if (us + modarray >= array.Length)
            {
                for (i = us - 1; i >= us - modarray; i--)
                {
                    if (array[i] == array[u])
                    {
                        Console.WriteLine("Вы победили");
                        return;
                    } 
                }
                Console.WriteLine("Победил компьютер");
            } else { us++;
                for (i = us; i < us + modarray; i++)
                {
                    if (array[i] == array[u])
                    {
                        Console.WriteLine("Победил компьютер");
                        return;
                    }
                }
                Console.WriteLine("Вы победили");
            }
        }
        public static void RNG(ref string hex, string l,string p)
        {
            HMAC Hmac = new HMACSHA256(Encoding.UTF8.GetBytes(p));
            hex = BitConverter.ToString(Hmac.ComputeHash(Encoding.UTF8.GetBytes(l))).Replace("-", string.Empty).ToLower();
        }
        public static void massiv(string [] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i+1 + " - " + array[i]);
            }
            Console.WriteLine("0 - exit");
        }
public static void stringcomp(ref int num,string first, string second)
        {
            if (first == second)
            {

                num++;
                Console.WriteLine("Вы ввели 2 одинаковых аргумента");
                Console.ReadKey();
            }
        }
public static void stringcheck(ref int num,int number)
        {
            if ((number<3)||(number%2==0))
            {
                num++;
                Console.WriteLine("Вы ввели кол-во аргементов меньше 3 или четное кол-во");
                Console.ReadKey();
            }
        }
     }
    }
