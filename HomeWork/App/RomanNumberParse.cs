using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public class RomanNumber
    {
        public static int Parse(String str)
        {
            
            var digits = new Dictionary<char, int>()
            {
                { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 },
                { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
            };
            
            // validation input data
            if (str == null)
                throw new ArgumentNullException();
        
            if (str == string.Empty)
                throw new ArgumentException("Empty string not allowed");
            
            foreach (var inputSymbol in str)
            {
                if (!digits.ContainsKey(inputSymbol))
                    throw new ArgumentException($"{inputSymbol} among us");
            }

            var digit = str[str.Length - 1];

            var res = digits[digit];

            for (var i = str.Length - 2; i >= 0; i--)
            {
                if (digits[digit] > digits[str[i]])
                {
                    res -= digits[str[i]];
                }
                else
                {
                    res += digits[str[i]];
                }
                digit = str[i];
            }

            return res;
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
