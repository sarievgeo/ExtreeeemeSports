using CalculatorEX.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork.App
{
    internal class Localise
    {
        public static String Language { get; set; } = "en-US";

        public static String GetEmptyStringMessage(String? language = null)
        {
            if (language == null) language = Language;
            switch (language)
            {
                case "uk-UA": return "Порожній рядок неприпустимий";
                case "en-US": return "Empty string not allowed";
            }
            throw new Exception("Unsupported language");
        }

        public static String GetInvalidOperator(String? language = null)
        {
            if (language == null) language = Language;
            switch (language)
            {
                case "uk-UA": return "Операція неможлива";
                case "en-US": return "Unsupported operation";
            }
            throw new Exception("Unsupported language");
        }

        public static String GetInvalidLanguage(String? language = null)
        {
            if (language == null) language = Language;
            switch (language)
            {
                case "uk-UA": return "Не підтримуєтся";
                case "en-US": return "Unsupported language";
            }
            throw new Exception("Unsupported language");
        }

        public static String GetInvalidCharMessage(char c, String? language = null)
        {
            language ??= Language;
            switch (language)
            {
                case "uk-UA": return $"Недозволений символ {c}";
                case "en-US": return $"Invalid char {c}";
            }
            throw new Exception("Unsupported language");
        }
        public static String GetInvalidTypeMessage(String type, String? language = null)
        {
            language = language ?? Language;
            switch (language)
            {
                case "uk-UA": return $"тип '{type}' не підтримується";
                case "en-US": return $"type '{type}' unsupported";
            }
            throw new Exception("Unsupported language");
        }
        public static String GetMispalcedNMessage(String? language = null)
        {
            if (language == null) language = Language;
            switch (language)
            {
                case "uk-UA": return "'N' не дозволяється у даному контексті";
                case "en-US": return "'N' is not allowed in this context";
            }
            throw new Exception("Unsupported language");
        }

        public static class Ui
        {
            public static string AskLang()
                => "Choose language / Оберіть мову\n    1: English\n    2: Українська\n    -> ";

            public static string Number(int number, string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => $"Римське число #{number}: ",
                    "en-US" => $"Roman number #{number}: ",
                    _ => throw new ArgumentException()
                };

            public static string Result(RomanNumber res, string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => $"Результат -> {res} / {res.Value}",
                    "en-US" => $"Result -> {res} / {res.Value}",
                    _ => throw new ArgumentException()
                };

            public static string EnterNumber(string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => "Введіть число: ",
                    "en-US" => "Enter number: ",
                    _ => throw new ArgumentException()
                };

            public static string EnterOperation(string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => "Введіть операцію: ",
                    "en-US" => "Enter operation: ",
                    _ => throw new ArgumentException()
                };

            public static string EnterExpression(string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => $"Введіть вираз: ",
                    "en-US" => $"Input Expression: ",
                    _ => throw new ArgumentException()
                };

            public static string InvalidExpressionMessage(string expression, string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => $"Неприпустимий вираз: {expression}",
                    "en-US" => $"Invalid Expression: {expression}",
                    _ => throw new ArgumentException()
                };

            public static string InvalidOperationMessage(string operation, string? language = null)
                => (language ?? Language) switch
                {
                    "uk-UA" => $"Неприпустима операція {operation}",
                    "en-US" => $"Invalid Operation: {operation}",
                    _ => throw new ArgumentException()
                };
        }
    }
}
