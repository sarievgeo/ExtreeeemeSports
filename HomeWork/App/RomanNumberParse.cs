using HomeWork.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEX.App
{
    public record class RomanNumber
    {
        private int _value;

        public int Value { get; set; }
        public static string[] Operations { get; } = new string[] { "+", "-" };

        #region Constructors

        public RomanNumber() => Value = 0;

        public RomanNumber(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException($"obj");
            }
            if (obj is int val)
            {
                this._value = val;
            }
            else if (obj is String str)
            {
                this._value = Parse(str);
            }
            else if (obj is RomanNumber rn)
            {
                this._value = rn._value;
            }
            else
            {
                throw new ArgumentException(Localise.GetInvalidTypeMessage(obj.GetType().ToString()));
            }
        }

        #endregion


        #region Operations

        public RomanNumber Add(object obj) => RomanNumber.Add(this, obj);
        public RomanNumber Sub(object obj) => RomanNumber.Sub(this, obj);

        #endregion

        #region StaticOperations

        public static RomanNumber Add(params object[] objects)
            => new RomanNumber(objects.Sum((o => new RomanNumber(o).Value)));

        public static RomanNumber Sub(object obj1, object obj2)
            => new RomanNumber(new RomanNumber(obj1).Value - new RomanNumber(obj2).Value);

        #endregion

        #region ParseRoman

        public static int Parse(String str)
        {
            if (str is null)
            {
                throw new ArgumentNullException();
            }

            if (str.Length < 1)
            {
                throw new ArgumentException(Localise.GetEmptyStringMessage());
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

        #endregion

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

        

        public RomanNumber Add(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }

            RomanNumber r = new();
            r.Value = rn.Value + this.Value;
            return r;
        }

        public RomanNumber Add(int rn)
        {
            return this.Add(new RomanNumber(rn));
        }

        public RomanNumber Add(String rn)
        {
            return this.Add(new RomanNumber(Parse(rn)));
        }

        public static RomanNumber Add(object rn1, object rn2)
        {
            if (rn1 is null || rn2 is null)
            {
                throw new ArgumentNullException();
            }

            if (rn1 is int && rn2 is int) return new RomanNumber((int)rn1).Add((int)rn2);
            else if (rn1 is String && rn2 is String) return new RomanNumber(RomanNumber.Parse((String)rn1)).Add((String)rn2);
            else if (rn1 is int && rn2 is String) return new RomanNumber((int)rn1).Add((String)rn2);
            else if (rn1 is String && rn2 is int) return new RomanNumber((int)rn2).Add((String)rn1);

            return new RomanNumber();
        }

        public RomanNumber Sub(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }
            return new RomanNumber(this.Add(rn.Value * (-1)));
        }

        public RomanNumber Mult(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }
            return new RomanNumber(this.Value * rn.Value);
        }

        public static RomanNumber Mult(object obj1, object obj2)
        {
            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Mult(rn2);
        }

        public RomanNumber Divide(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }
            return new RomanNumber(this.Value / rn.Value);
        }

        public static RomanNumber Divide(object obj1, object obj2)
        {
            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Divide(rn2);
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
