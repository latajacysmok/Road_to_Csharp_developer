/*Zadanie 3 - stwórz aplikację w której:
użytkownika wprowadza jakiś tekst
tekst zostanie zmanipulowany - odwrócony, wypisany dużymi literami, wypisany małymi literami
ilość znaków w tekście zostanie policzona i wypisana
podzielony na litery i wypisany
skorzystaj z różnych możliwości do łączenia stringów w kodzie
użyj 2 innych metod do manipulacji na stringu*/
using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace String
{
    class Program
    {
        static string word;
        static string word1;
        static string word2;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome my dear user to a program showing what can be done with a string in C#.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("\nFirst select the operation you want to perform on the string:");
            }
        }

        static void SelectOptions(int option)
        {
            Console.WriteLine("1: For print your word.");

            Console.WriteLine("2: For print your word.");
            Console.WriteLine("3: For print your word.");
            Console.WriteLine("4: For print your word.");
            Console.WriteLine("5: For print your word.");
            Console.WriteLine("6: For print your word.");
            Console.WriteLine("7: For print your word.");
            Console.WriteLine("8: For print your word.");
            Console.WriteLine("9: For print your word.");
            Console.WriteLine("10: For print your word.");
            
                switch (EnterNumber())
            {
                case 1:
                    Console.WriteLine($"Your word is: {TakeaWord()}");
                    break;
                case 2:
                    Console.WriteLine($"Your inverted word word is: {ReverseTheWord(TakeaWord())}");
                    break;
                case 3:
                    Console.WriteLine($"Concatenate string using 'String.Join' method: {ConcatenateWords(ChangeWordToArray(TakeaWord()))}");
                    break;
                case 4:
                    Console.WriteLine($"###: {EnlargeLetters(TakeaWord())}");
                    break;
                case 5:
                    Console.WriteLine($"###: {LettersSmaller(TakeaWord())}");
                    break;
                case 6:
                    Console.WriteLine($"Number of characters in your text: {CountNumberOfLettersInGivenWord(TakeaWord())}");
                    break;
                case 7:
                    //Console.WriteLine($"###: {SpellWord(TakeaWord())}");
                    break;
                case 8:
                    //Console.WriteLine($"###: {ConcatenateString(TakeaWord())}");
                    break;
                case 9:
                    //Console.WriteLine($"Your word is: {CompareWord(TakeaWord(), TakeaWord())}");
                    break;
                case 10:
                    //Console.WriteLine($"###: {ReturnsSubstringOfString(TakeaWord())}");
                    break;
                default:
                    // code block
                    break;
            }
        }

        static string TakeaWord()
        {
            Console.Write("My dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
            word = Console.ReadLine();
            return word;
        }
        static string ReverseTheWord(string word)
        {
            return (string)(word.Reverse());//? word nie jest stringiem
        }

        static char[] ChangeWordToArray(string word)
        {
            char[] wordArray = word.ToCharArray();
            return wordArray;
        }
        //Concatenate string using String.Join method 
        static string ConcatenateWords(char[] wordArray)
        {
            return ($"Inverted yours text: {string.Join("-", wordArray)}\n");
        }

        static string EnlargeLetters(string word)
        {
            return ($"Your text in capital letters: {word.ToUpper()}\n");
        }

        static string LettersSmaller(string word)
        {
            return ($"Your text in lowercase: {word.ToLower()}\n");
        }

        static int CountNumberOfLettersInGivenWord(string word)
        {
            return word.Count();
        }

        static void SpellWord(string word)
        {
            Console.WriteLine("Here is your word divided into separate characters: ");
            for (int c = 0; c < word.Count(); c++)
            {
                if (c < word.Count() - 1) Console.Write(word[c] + ", ");
                else if (c == word.Count() - 1) Console.Write(word[c] + ".\n");
            }
        }

        static void ConcatenateString(string word)
        {
            //Concatenate String Using + Operator
            Console.WriteLine("Print below string use: 'Concatenate String Using + Operator'");
            Console.WriteLine("Hello Dear user, " + "your string is: " + word + ".");

            //String Interpolation
            Console.WriteLine("Print below string use: 'String Interpolation'");
            Console.WriteLine($"Hello Dear user, your string is: {word}.");

            //Concatenate string method
            Console.WriteLine("Print below string use: 'Concatenate string method'");
            Console.WriteLine("Hello Dear user, your string is: {0}.", word);

            // Use StringBuilder for concatenation in tight loops.          
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 20; i++) sb.AppendLine(i.ToString());
            Console.WriteLine("Print below string use: 'StringBuilder for concatenation in tight loops'");
            Console.WriteLine(sb.ToString());

            //Concatenate string using String.Concate method
            string first = "CokolwiekDoPrzykładu";
            Console.WriteLine("Print below string use: 'String.Concate method'");
            string.Concat(first, word);
        }

        // compare word and usreName
        static void CompareWord(string word1, string word2)
        {
            Boolean result1 = word1.Equals(word2);
            Console.WriteLine($"Comparing whether \"{word1}\" is equal to \"{word2}\":\t {result1}");
        }

        //returns the position of the specified character in the string
        static void ReturnPositionOfIndicatedCharacter(string word)
        {
            char letterLookingFor;
            while (true)
            {
                Console.Write("We are looking for the index of the first occurrence of the letter you provided, dear user: ");
                if (char.TryParse(Console.ReadLine(), out letterLookingFor))
                {
                    if (Char.IsNumber(letterLookingFor))
                    {
                        break;
                    }
                    else Console.WriteLine("Dear User, you have not entered a letter but a number, please try again.");
                }
                else Console.WriteLine("Dear User, you have not entered a letter, please try again.");
            }
            Console.Write($"We are looking for the index of the first occurrence of the letter '{letterLookingFor}': ");
            if (word.IndexOf(letterLookingFor) < 0) Console.WriteLine($"The specified letter \"{letterLookingFor}\" is missing in the string: {word}");
            else Console.WriteLine(word.IndexOf(letterLookingFor));
        }

        //returns substring of a string
        static void ReturnsSubstringOfString(string word)
        {
            Console.WriteLine("We print now substring which start from index what you want position: ");
            int startIndex = EnterNumber();

            Console.WriteLine("We print now substring which end in what you want position: ");
            int endIndex = EnterNumber();

            Console.WriteLine($"We print now substring which start from index {startIndex} and end in {endIndex} position: {word.Substring(startIndex, endIndex)} ");
        }

        static int EnterNumber()
        {
            int numberCandidate;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numberCandidate))
                {
                    if (numberCandidate <= word.Length) break;
                    else Console.WriteLine("Dear User, you entered a number greater than the number of letters in the word '{word}', please try again.");
                }
                else Console.WriteLine($"Dear User, {numberCandidate} is not a number , please try again.");
            }
            return numberCandidate;
        }


        //splits the string into substring
        static void SplitsString(string word)
        {
            Console.WriteLine($"We print now our string but splits a letter: ");
            foreach (string letter in word.Split("")) Console.Write(letter);
        }
    }
}


