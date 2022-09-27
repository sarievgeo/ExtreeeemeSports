using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
