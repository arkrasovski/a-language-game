using System;
using System.Globalization;
using System.Text;

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay"
        /// </example>
        /// 
        public static string TranslateWord(string word)
        {
            StringBuilder sb = new StringBuilder();
            char firstLetter = char.ToLower(word[0], CultureInfo.CurrentCulture);
            if (firstLetter == 'a' || firstLetter == 'o' || firstLetter == 'u' || firstLetter == 'e' || firstLetter == 'i')
            {
                sb.Append(word);
                sb.Append("yay");
            }
            else
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                try
                {
                    while (word[i] != 'a' && word[i] != 'o' && word[i] != 'u' && word[i] != 'e' && word[i] != 'i')
                    {
                        buffer.Append(word[i]);
                        i++;
                    }
                }
                catch
                {
                    Console.WriteLine("its not a word");
                    if (word.Length > 1) 
                    { 
                        return word + "ay"; 
                    }

                    return word;
                    
                }

                sb.Append(word);
                sb.Remove(0, i);
                char punctSign = '\0';
                if (word[word.Length - 1] == '!' || word[word.Length - 1] == ',' || word[word.Length - 1] == '.')
                {
                    punctSign = word[word.Length - 1];
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append(buffer.ToString().ToLower(CultureInfo.CurrentCulture));
                sb.Append("ay");
                if (word[word.Length - 1] == '!' || word[word.Length - 1] == ',' || word[word.Length - 1] == '.')
                    sb.Append(punctSign);
                if ((int)word[0] > 64 && (int)word[0] < 91)
                {
                    sb.Remove(0, 1);
                    sb.Insert(0, char.ToUpper(word[i], CultureInfo.CurrentCulture));
                }
            }

            return sb.ToString();
        }

        public static string TranslateToPigLatin(string phrase)
        {

            Console.WriteLine(phrase);
            if (phrase == null)
            {
                throw new ArgumentException("string cannot be null");
            }
            
            if (phrase.Length == 0)
            {
                throw new ArgumentException("string cannot be empty");
            }

            if (phrase.Replace(" ", string.Empty, 0).Length == 0)
            {
                throw new ArgumentException("string cannot be whitespace");
            }

            string[] arr = phrase.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = TranslateWord(arr[i]);
            }
            Console.WriteLine(string.Join(' ', arr));

            return string.Join(' ', arr) ;
            
        }
    }
}
