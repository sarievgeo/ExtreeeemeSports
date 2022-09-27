using CalculatorEX.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App
{
    public class Calc
    {
        public void Run()
        {
            AskLang();
            RomanNumber res = null!;

            // repeats untill user enter valid expression
            do
            {
                // ask Expression
                Console.Write(Localise.EnterExpression());
                // user input expression
                String? userInput = Console.ReadLine() ?? "";

                try
                {
                    // evaluate expression
                    res = EvalExpression(userInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (res is null);

            // Show result
            Console.WriteLine(Resources.Ui.Result(res));
        }

        public RomanNumber EvalExpression(String expression)
        {
            // split expression on two numbers and operation
            string[] parts = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // expression is invalid
            if (parts.Length != 3)
                throw new ArgumentException(Resources.Ui.InvalidExpressionMessage(expression));

            // operation is invalid
            if (Array.IndexOf(RomanNumber.Operations, parts[1]) == -1)
                throw new ArgumentException(Resources.Ui.InvalidOperationMessage(parts[1]));

            var rn1 = new RomanNumber(RomanNumber.Parse(parts[0]));     // build roman number 1
            var rn2 = new RomanNumber(RomanNumber.Parse(parts[2]));     // build roman number 2
            var res = parts[1] == RomanNumber.Operations[0]             // counts result of expression
                ? rn1.Add(rn2)
                : rn1.Sub(rn2);

            return res;
        }

        private void AskLang()
        {
            while (true)
            {
                Console.Write(Resources.Ui.AskLang());
                var lang = Console.ReadLine();

                if (lang == "1")
                    Resources.Culture = "en-US";
                else if (lang == "2")
                    Resources.Culture = "uk-UA";

                Console.Clear();

                if (lang is "1" or "2")
                    return;
            }

        }
    }
}
