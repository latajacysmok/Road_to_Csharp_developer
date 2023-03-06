using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    internal class ChoiceOptions
    {
        public void SelectOption()
        {
            bool rightNumber = true;

            Console.WriteLine("1: For print your word.");
            Console.WriteLine("2: Inverted word.");
            Console.WriteLine("3: For concatenate string using 'String.Join'.");
            Console.WriteLine("4: If you want to enlarge letters in your word.");
            Console.WriteLine("5: If you want to change the letters in your word to small ones.");
            Console.WriteLine("6: If you want the number of letters in your word.");
            Console.WriteLine("7: If you want to write each letter separately.");
            Console.WriteLine("8: For print the same sentance in diffrent way.");
            Console.WriteLine("9: If you want to compare words.");
            Console.WriteLine("10: For print your substring.");
            Console.WriteLine("11: For print write out specially separately from the sentence you wrote the words.");
            Console.WriteLine("12: For find index number occurrence of the character you selected from the sentence you wrote the words.");
            Console.Write("\nYou choose: ");

            while (true)
            {
                switch (EnterNumber())
                {
                    case 1:
                        Console.WriteLine($"Your word is: {TakeaWord()}");
                        break;
                    case 2:
                        Console.WriteLine(ReverseTheWord(TakeaWord()));
                        break;
                    case 3:
                        Console.WriteLine(ConcatenateWords(ChangeWordToArray(TakeaWord())));
                        break;
                    case 4:
                        Console.WriteLine(EnlargeLetters(TakeaWord()));
                        break;
                    case 5:
                        Console.WriteLine(LettersSmaller(TakeaWord()));
                        break;
                    case 6:
                        Console.WriteLine(CountNumberOfLettersInGivenWord(TakeaWord()));
                        break;
                    case 7:
                        SpellWord(TakeaWord());
                        break;
                    case 8:
                        ConcatenateString(TakeaWord());
                        break;
                    case 9:
                        CompareWord(TakeaWord(), TakeaWord());
                        break;
                    case 10:
                        PrintSubstringFromTo(TakeaWord());
                        break;
                    case 11:
                        SplitsString(TakeaWord());
                        break;
                    case 12:
                        ReturnPositionOfIndicatedCharacter(TakeaWord());
                        break;

                    default:
                        Console.Write("The selected number is not from 1 to 10. Please try again: ");
                        rightNumber = false;
                        break;
                }
                if (rightNumber) break;
                else rightNumber = true;

            }

        }

        public string TakeaWord()
        {
            string word;
            while (true)
            {
                Console.Write("My dear user, I am asking you to enter a some text, it can be a word/-s or an insignificant string of characters: ");
                word = Console.ReadLine();
                if (word != null) break;
                else Console.WriteLine("My dear user, provide not empty string.");
            }
            return word;
        }

        public int EnterNumber()
        {
            int numberCandidate;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numberCandidate)) break;
                else Console.Write($"Dear User, this is not a number, please try again: ");
            }
            return numberCandidate;
        }
    }
}
