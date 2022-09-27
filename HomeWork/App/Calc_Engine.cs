using CalculatorEX.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App
{
    internal class Calc_Engine
    {
        private static RomanNumber num1;
        private static RomanNumber num2;
        private static String operation;

        private static void GetOperation()
        {
            operation = User_Interface.Operator();
        }



        private static void GetNumbers()
        {
            String val1;
            String val2;


            bool flag = true;
            do
            {
                try
                {
                    val1 = User_Interface.Number();
                    num1 = new RomanNumber(val1);
                    flag = false;
                }
                catch (ArgumentNullException) { Console.WriteLine("System error. Program termunated"); }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            } while (flag);
            flag = true;
            do
            {
                try
                {
                    val2 = User_Interface.Number();
                    num2 = new RomanNumber(val2);
                    flag = false;
                }
                catch (ArgumentNullException) { Console.WriteLine("System error. Program termunated"); }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            } while (flag);


        }

        public static void GetRezult()
        {
            switch (operation)
            {
                case "+": Console.WriteLine($"{num1.ToString()} + {num2.ToString()} = {(num1.Add(num2)).ToString()}"); break;  //  выводим результат выбранной операции
                case "*": Console.WriteLine($"{num1.ToString()} * {num2.ToString()} = {(num1.Mult(num2)).ToString()}"); break;  //  выводим результат выбранной операции  //  выводим результат выбранной операции
                case "-": Console.WriteLine($"{num1.ToString()} - {num2.ToString()} = {(num1.Sub(num2)).ToString()}"); break;  //  выводим результат выбранной операции

            }


        }

        public static RomanNumber EvalExpression(String expression)
        {
            var Operations = new String[] { "+", "-" };



            String[] parts = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid expression");
            }
            if (Array.IndexOf(Operations, parts[1]) == -1)
            {
                throw new ArgumentException("Invalid operation");
            }
            RomanNumber rn1 = new(RomanNumber.Parse(parts[0]));
            RomanNumber rn2 = new(RomanNumber.Parse(parts[2]));
            RomanNumber res =
                parts[1] == Operations[0]
                ? rn1.Add(rn2)
                : rn1.Sub(rn2);



            return res;
        }

        public static void Work1()    
        {


            User_Interface.GetCulture();
            GetOperation();
            GetNumbers();
            GetRezult();
        }

        public static void Work2()
        {
            User_Interface.GetCulture();

            String? userInput;
            RomanNumber res = null!;
            do
            {
                Console.Write("Enter expression (like XC + CD): ");


                userInput = Console.ReadLine() ?? "";
                try
                {
                    res = EvalExpression(userInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (res is null);



            Console.WriteLine($"{userInput} = {res}");
        }

    }
}
