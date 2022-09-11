using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class RomanNumber
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public RomanNumber()
        {
            this._value = 0;
        }

        public RomanNumber(int value)
        {
            this._value = value;
        }

        public override string ToString()
        {
            if(this._value == 0)
            {
                return "N";
            }

            int n = this._value < 0 ? -this._value : this._value;
            String res = this._value < 0 ? "-" : "";
            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };


            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];

                }
            }

            return res;
        }

        private static readonly Dictionary<char, int> Digits = new()
        {
                { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 },
                { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
        };

        public static int Parse(String str)
        {
            if (str is null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Empty string not allowed");
            }

            foreach (var inputSymbol in str)
            {
                if (!Digits.ContainsKey(inputSymbol))
                    throw new ArgumentException($"Invalid input data: {inputSymbol} in {str}");
            }



            var num = 0;

            for (var i = 0; i < str.Length - 1; i++)
            {
                var symbol_f = str[i];
                var symbol_s = str[i + 1];

                if (Digits[symbol_s] > Digits[symbol_f])
                {
                    num -= Digits[symbol_f];
                }
                else
                {
                    num += Digits[symbol_f];
                }
            }

            num += Digits[str[^1]];

            return num;
        }
        
    }

    // public static int Parse(String str)
    // {
    //     char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
    //     int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
    //     // Якщо наступна цифра числа більша за поточну, то
    //     // вона віднімається від результату, інакше додається
    //     // IX : -1 + 10;  XC : -10 + 100;  XX : +10+10; CX : +100+10
    //     // XIV : +10-1+5; XIIII : 10+1+1+1+1
    //
    //     int pos = str.Length - 1;  // позиція останньої цифри числа
    //     char digit = str[pos];     // символ цифри
    //     int ind = Array.IndexOf(digits, digit);  // позиція цифри у масиві
    //     if(ind == -1)
    //     {
    //         throw new ArgumentException($"Invalid char {digit}");
    //     }
    //     int val = digitValues[ind];  // величина цифри
    //     int res = val;
    //
    //     pos -= 1;  // передостання цифра у числі
    //     // Визначаємо величину цифри
    //     // порівнюємо з наступною (останньою) цифрою (одержана вище)
    //     // додаємо або віднімаємо в залежності від рез. порівняння
    //     // продовжуємо доки pos не дійде до 0
    //
    //     return 1;
    // }
}
